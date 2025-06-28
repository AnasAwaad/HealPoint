using AutoMapper;
using HealPoint.BusinessLogic.Contracts;
using HealPoint.DataAccess.Contracts;
using HealPoint.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;

namespace HealPoint.BusinessLogic.Services;
internal class DoctorService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<ApplicationUser> userManager, IFileStorageService fileStorage) : IDoctorService
{
	#region Actions

	public IEnumerable<DoctorDto> GetAll()
	{
		var doctors = unitOfWork.Doctors.GetAllWithDetails();

		return mapper.Map<IEnumerable<DoctorDto>>(doctors);
	}

	public async Task CreateAsync(CreateDoctorDto dto)
	{
		// Creates a new doctor with user account and saves profile photo if provided

		var user = new ApplicationUser
		{
			UserName = dto.UserName ?? dto.Email,
			Email = dto.Email,
			FirstName = dto.FirstName,
			LastName = dto.LastName,
		};

		await userManager.CreateAsync(user, dto.Password);
		var result = await userManager.AddToRoleAsync(user, "Doctor");

		if (!result.Succeeded)
			throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));


		var doctor = mapper.Map<Doctor>(dto);

		doctor.CreatedOn = DateTime.Now;

		if (dto.ImageFile is not null)
			doctor.ProfilePhotoPath = await fileStorage.UploadFileAsync(dto.ImageFile, "doctors");
		else
			doctor.ProfilePhotoPath = "/images/doctors/default-doctor.png";

		doctor.ApplicationUserId = user.Id;

		unitOfWork.Doctors.Insert(doctor);
		unitOfWork.SaveChanges();
	}

	public bool IsAllowedMobileNumber(string phoneNumber, int id)
	{
		var doctor = unitOfWork.Doctors.FindById(id);
		return doctor is null || doctor.Id.Equals(id);
	}

	public bool IsAllowedContactEmail(string email, int id)
	{
		var doctor = unitOfWork.Doctors.GetDoctorByContactEmail(email);
		return doctor is null || doctor.Id.Equals(id);
	}

	public bool IsAllowedEmergencyContactPhone(string emergencyContactPhone, int id)
	{
		var doctor = unitOfWork.Doctors.GetDoctorByEmergencyContactPhone(emergencyContactPhone);
		return doctor is null || doctor.Id.Equals(id);
	}

	public bool IsAllowedUserName(string userName, int id)
	{
		var user = userManager.Users
			.Where(u => u.UserName == userName)
			.Select(u => new { DoctorId = u.Doctor.Id })
			.FirstOrDefault();

		return user is null || user.DoctorId.Equals(id);
	}

	public bool IsAllowedEmail(string email, int id)
	{
		var user = userManager.Users
			.Where(u => u.Email == email)
			.Select(u => new { DoctorId = u.Doctor.Id })
			.FirstOrDefault();

		return user is null || user.DoctorId.Equals(id);
	}

	#endregion
}
