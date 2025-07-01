using AutoMapper;
using HealPoint.BusinessLogic.Contracts;
using HealPoint.DataAccess.Contracts;
using HealPoint.DataAccess.Entities;

namespace HealPoint.BusinessLogic.Services;
internal class TimeSlotService(IUnitOfWork unitOfWork,
							   IMapper mapper) : ITimeSlotService
{
	public TimeSlotDto CreateTimeSlot(TimeSlotDto dto, string userId)
	{
		if (!dto.IsValidTimeRange())
			throw new ArgumentException("Start time must be earlier than end time.");


		var doctor = unitOfWork.Doctors.GetDoctorByUserId(userId);

		if (doctor is null)
			throw new KeyNotFoundException($"Doctor with userId : {userId} not found");

		var timeSlot = mapper.Map<TimeSlot>(dto);
		timeSlot.DoctorId = doctor.Id;
		timeSlot.DayOfWeek = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), dto.DayOfWeek!);

		unitOfWork.TimeSlots.Insert(timeSlot);
		unitOfWork.SaveChanges();

		return dto;
	}

	public IEnumerable<TimeSlotDto> GetTimeSlots(string userId, DayOfWeek day)
	{
		var doctor = unitOfWork.Doctors.GetDoctorByUserId(userId);

		if (doctor is null)
			throw new KeyNotFoundException($"Doctor with userId : {userId} not found");

		var timeSlots = unitOfWork.TimeSlots.GetByDayAndDoctorIdAsync(doctor.Id, day);

		return mapper.Map<IEnumerable<TimeSlotDto>>(timeSlots);
	}
}
