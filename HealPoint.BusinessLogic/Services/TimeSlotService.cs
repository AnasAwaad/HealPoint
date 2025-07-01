using AutoMapper;
using HealPoint.BusinessLogic.Contracts;
using HealPoint.DataAccess.Contracts;

namespace HealPoint.BusinessLogic.Services;
internal class TimeSlotService(IUnitOfWork unitOfWork,
							   IMapper mapper) : ITimeSlotService
{
	public IEnumerable<TimeSlotDto> GetTimeSlots(string userId, DayOfWeek day)
	{
		var doctor = unitOfWork.Doctors.GetDoctorByUserId(userId);

		if (doctor is null)
			throw new KeyNotFoundException($"Doctor with userId : {userId} not found");

		var timeSlots = unitOfWork.TimeSlots.GetByDayAndDoctorIdAsync(doctor.Id, day);

		return mapper.Map<IEnumerable<TimeSlotDto>>(timeSlots);
	}
}
