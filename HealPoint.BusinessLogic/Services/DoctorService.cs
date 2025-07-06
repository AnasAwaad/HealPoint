using AutoMapper;
using HealPoint.BusinessLogic.Contracts;
using HealPoint.DataAccess.Contracts;
using HealPoint.DataAccess.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace HealPoint.BusinessLogic.Services;
internal class DoctorService(IUnitOfWork unitOfWork,
							 IMapper mapper,
							 UserManager<ApplicationUser> userManager,
							 IFileStorageService fileStorage,
							 IWebHostEnvironment webHostEnvironment,
							 IEmailSender emailSender,
							 IHttpContextAccessor httpContextAccessor,
							 IUrlHelperFactory urlHelperFactory) : IDoctorService
{
	#region Actions

	public IEnumerable<DoctorDto> GetAll()
	{
		var doctors = unitOfWork.Doctors.GetAllWithDetails();

		return mapper.ProjectTo<DoctorDto>(doctors).ToList();
	}


	public DoctorFormDto? GetById(int id)
	{
		var doctor = unitOfWork.Doctors.GetDoctorByIdWithDetails(id);
		return doctor is not null
			? mapper.Map<DoctorFormDto>(doctor)
			: null;
	}

	public async Task CreateAsync(DoctorFormDto dto)
	{
		// Creates a new doctor with user account and saves profile photo if provided

		var user = new ApplicationUser
		{
			UserName = dto.UserName ?? dto.Email,
			Email = dto.Email,
			FirstName = dto.FirstName,
			LastName = dto.LastName,
			PhoneNumber = dto.PhoneNumber
		};


		// Use provided password or generate a default one if not supplied
		string password = dto.Password ?? $"Dr#{Guid.NewGuid().ToString().Substring(0, 8)}";

		await userManager.CreateAsync(user, password);
		var result = await userManager.AddToRoleAsync(user, "Doctor");

		if (!result.Succeeded)
			throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));


		var doctor = mapper.Map<Doctor>(dto);

		doctor.CreatedOn = DateTime.Now;

		if (dto.ImageFile is not null)
			doctor.ProfilePhotoPath = await fileStorage.UploadFileAsync(dto.ImageFile, "doctors");
		else
			doctor.ProfilePhotoPath = "/images/doctors/default-doctor.jpg";

		doctor.ApplicationUserId = user.Id;

		unitOfWork.Doctors.Insert(doctor);
		unitOfWork.SaveChanges();


		//Send email notification to the new doctor

		string activationLink = await GenerateActivationLinkAsync(user);

		var emailBody = PrepareEmailBody(user, password, activationLink);

		await emailSender.SendEmailAsync(user.Email, "Confirm your email", emailBody);

	}

	private string PrepareEmailBody(ApplicationUser user, string password, string activationLink)
	{
		var templatePath = $"{webHostEnvironment.WebRootPath}/templates/doctor-confirm-email.html";
		StreamReader stream = new(templatePath);

		var body = stream.ReadToEnd();
		stream.Close();

		body = body
			 .Replace("[doctorName]", $"Dr. {user.FirstName} {user.LastName}")
			.Replace("[userName]", user.UserName)
			.Replace("[temporaryPassword]", password)
			.Replace("[activationLink]", activationLink)
			.Replace("[year]", DateTime.Now.Year.ToString())
			.Replace("[header]", $"Hello {user.FirstName}, thank you for joining to us!")
			.Replace("[body]", "This is a email from Heal Point")
			.Replace("[url]", activationLink)
			.Replace("[linkTitle]", "Click Here");

		return body;
	}

	private async Task<string> GenerateActivationLinkAsync(ApplicationUser user)
	{
		var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
		code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

		var httpContext = httpContextAccessor.HttpContext;

		var urlHelper = urlHelperFactory.GetUrlHelper(
		   new ActionContext(httpContext, new RouteData(), new ControllerActionDescriptor()));

		var callbackUrl = urlHelper.Page(
			"/Account/ConfirmEmail",
			pageHandler: null,
			values: new { area = "Identity", userId = user.Id, code },
			protocol: httpContext.Request.Scheme
		);


		return callbackUrl;
	}

	public async Task UpdateAsync(DoctorFormDto dto)
	{

		var doctor = unitOfWork.Doctors.FindById(dto.Id.Value);
		if (doctor is null)
			throw new KeyNotFoundException($"Doctor with ID {dto.Id} not found.");

		var user = await userManager.FindByIdAsync(doctor.ApplicationUserId!);
		if (user is null)
			throw new KeyNotFoundException($"User with ID {doctor.ApplicationUserId} not found.");

		// Update ApplicationUser properties
		user.UserName = dto.UserName ?? dto.Email;
		user.Email = dto.Email;
		user.FirstName = dto.FirstName;
		user.LastName = dto.LastName;
		user.PhoneNumber = dto.PhoneNumber;

		var result = await userManager.UpdateAsync(user);

		if (!result.Succeeded)
			throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));

		// If a new password was entered, update the password
		if (!string.IsNullOrWhiteSpace(dto.Password))
		{
			var removedPasswordResult = await userManager.RemovePasswordAsync(user);
			if (!removedPasswordResult.Succeeded)
				throw new Exception("Failed to remove old password: " + string.Join(", ", removedPasswordResult.Errors.Select(e => e.Description)));

			var addResult = await userManager.AddPasswordAsync(user, dto.Password);
			if (!addResult.Succeeded)
				throw new Exception("Failed to set new password: " + string.Join(", ", addResult.Errors.Select(e => e.Description)));
		}


		var oldProfilePhotoPath = doctor.ProfilePhotoPath;
		mapper.Map(dto, doctor);

		// Handle Profile Photo update

		if (dto.ImageFile is not null)
		{
			// Delete the old photo if it's not the default one
			if (!string.IsNullOrEmpty(oldProfilePhotoPath) && oldProfilePhotoPath != "/images/doctors/default-doctor.jpg")
				fileStorage.DeleteFile(oldProfilePhotoPath);

			// Upload the new photo
			doctor.ProfilePhotoPath = await fileStorage.UploadFileAsync(dto.ImageFile, "doctors");
		}
		else
		{
			// If no new photo is provided, keep the old one
			doctor.ProfilePhotoPath = oldProfilePhotoPath;
		}

		doctor.LastUpdatedOn = DateTime.Now;
		unitOfWork.Doctors.Update(doctor);
		unitOfWork.SaveChanges();
	}

	public async Task ToggleDoctorStatusAsync(int id)
	{
		var doctor = unitOfWork.Doctors.GetByIdWithUser(id);

		if (doctor is null)
			throw new KeyNotFoundException($"Doctor with ID {id} not found.");

		doctor.IsDeleted = !doctor.IsDeleted;
		doctor.LastUpdatedOn = DateTime.Now;

		doctor.ApplicationUser.IsDeleted = !doctor.IsDeleted;
		doctor.ApplicationUser.LastUpdatedOn = DateTime.Now;




		var result = await userManager.UpdateAsync(doctor.ApplicationUser);

		if (!result.Succeeded)
			throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));

		unitOfWork.Doctors.Update(doctor);
		unitOfWork.SaveChanges();
	}

	public bool IsAllowedMobileNumber(string phoneNumber, int? id)
	{
		var doctor = userManager.Users
			.Where(u => u.PhoneNumber == phoneNumber)
			.Select(u => new { DoctorId = u.Doctor.Id })
			.FirstOrDefault();

		return doctor is null || doctor.DoctorId.Equals(id);
	}

	public bool IsAllowedContactEmail(string email, int? id)
	{
		var doctor = unitOfWork.Doctors.GetDoctorByContactEmail(email);
		return doctor is null || doctor.Id.Equals(id);
	}

	public bool IsAllowedEmergencyContactPhone(string emergencyContactPhone, int? id)
	{
		var doctor = unitOfWork.Doctors.GetDoctorByEmergencyContactPhone(emergencyContactPhone);
		return doctor is null || doctor.Id.Equals(id);
	}

	public bool IsAllowedUserName(string userName, int? id)
	{
		var user = userManager.Users
			.Where(u => u.UserName == userName && u.Doctor != null)
			.Select(u => new { DoctorId = u.Doctor.Id })
			.FirstOrDefault();

		return user is null || user.DoctorId.Equals(id);
	}

	public bool IsAllowedEmail(string email, int? id)
	{
		var user = userManager.Users
			.Where(u => u.Email == email && u.Doctor != null)
			.Select(u => new { DoctorId = u.Doctor.Id })
			.FirstOrDefault();

		return user is null || user.DoctorId.Equals(id);
	}

	public Doctor? GetWithSymptomsByUserId(string userId)
	{
		return unitOfWork.Doctors.GetDoctorWithSymptomsByUserId(userId);
	}

	public void ChangeService(int doctorId, int selectedServiceId)
	{
		var doctor = unitOfWork.Doctors.FindById(doctorId);

		if (doctor is null)
			throw new KeyNotFoundException($"Doctor with ID {doctorId} not found.");

		doctor.ServiceId = selectedServiceId;

		unitOfWork.SaveChanges();
	}

	public void ChangeSpecialization(int doctorId, int selectedSpecializationId)
	{
		var doctor = unitOfWork.Doctors.FindById(doctorId);

		if (doctor is null)
			throw new KeyNotFoundException($"Doctor with ID {doctorId} not found.");

		doctor.SpecializationId = selectedSpecializationId;

		unitOfWork.SaveChanges();
	}

	public void UpdateSymptoms(int doctorId, IList<int> selectedSymptoms)
	{
		var doctor = unitOfWork.Doctors.GetDoctorWithSymptomsByDoctorId(doctorId);

		if (doctor is null)
			throw new KeyNotFoundException($"Doctor with ID {doctorId} not found.");

		doctor.LastUpdatedOn = DateTime.Now;

		doctor.Symptoms = new List<DoctorSymptom>();

		foreach (var symptomId in selectedSymptoms)
		{
			doctor.Symptoms.Add(new DoctorSymptom { SymptomId = symptomId });
		}

		unitOfWork.SaveChanges();
	}

	#endregion
}
