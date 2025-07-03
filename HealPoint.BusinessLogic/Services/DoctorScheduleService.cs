using AutoMapper;
using HealPoint.BusinessLogic.Contracts;
using HealPoint.DataAccess.Contracts;
using HealPoint.DataAccess.Entities;

namespace HealPoint.BusinessLogic.Services;
internal class DoctorScheduleService(IUnitOfWork unitOfWork, IMapper mapper) : IDoctorScheduleService
{
	public void Create(DoctorScheduleDto doctorScheduleDto, string userId)
	{
		var doctorSchedule = mapper.Map<DoctorSchedule>(doctorScheduleDto);

		var doctor = unitOfWork.Doctors.GetDoctorByUserId(userId);

		if (doctor == null)
			throw new Exception($"Doctor with userId = {userId} not found");

		doctorSchedule.DoctorId = doctor.Id;

		unitOfWork.DoctorSchedules.Insert(doctorSchedule);
		unitOfWork.SaveChanges();
	}

	public DoctorScheduleDto GetAllWithDetails(string userId)
	{
		var doctor = unitOfWork.Doctors.GetDoctorByUserId(userId);

		if (doctor == null)
			throw new Exception($"Doctor with userId = {userId} not found");


		var doctorSchedules = unitOfWork.DoctorSchedules.GetDoctorScheduleWithDetails(doctor.Id);

		return mapper.Map<DoctorScheduleDto>(doctorSchedules);
	}

	public void Update(DoctorScheduleDto model, string userId)
	{
		var doctor = unitOfWork.Doctors.GetDoctorByUserId(userId);

		if (doctor == null)
			throw new Exception($"Doctor with userId = {userId} not found");

		var doctorSchedules = unitOfWork.DoctorSchedules.GetDoctorScheduleWithDetails(doctor.Id);

		mapper.Map(model, doctorSchedules);
		doctorSchedules.DoctorId = doctor.Id;

		if (model.DoctorScheduleDetails is not null)
		{
			doctorSchedules.DoctorScheduleDetails.Clear();
			foreach (var detail in model.DoctorScheduleDetails)
			{
				var scheduleDetail = mapper.Map<DoctorScheduleDetails>(detail);
				doctorSchedules.DoctorScheduleDetails.Add(scheduleDetail);
			}
		}

		unitOfWork.SaveChanges();
	}
}
