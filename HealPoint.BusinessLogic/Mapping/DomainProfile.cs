using AutoMapper;
using HealPoint.BusinessLogic.DTOs.Doctor;
using HealPoint.BusinessLogic.DTOs.DoctorSchedule;
using HealPoint.BusinessLogic.DTOs.Specialization;
using HealPoint.DataAccess.Entities;

namespace HealPoint.BusinessLogic.Mapping;
public class DomainProfile : Profile
{
	public DomainProfile()
	{
		// Departments
		CreateMap<DepartmentDto, Department>().ReverseMap();
		CreateMap<DepartmentFormDto, Department>().ReverseMap();
		CreateMap<DepartmentFormDto, DepartmentDto>().ReverseMap();

		// Specialization
		CreateMap<SpecializationDto, Specialization>().ReverseMap()
			.ForMember(src => src.DepartmentName, opt => opt.MapFrom(dest => dest.Department.Name));

		CreateMap<SpecializationFormDto, Specialization>().ReverseMap();
		CreateMap<SpecializationFormDto, DepartmentDto>().ReverseMap();
		CreateMap<Specialization, DoctorSpecializationItemDto>();

		// Clinics
		CreateMap<Clinic, ClinicListDto>()
			.ForMember(src => src.Speciality, opt => opt.MapFrom(dest => dest.Specialization.Name)); ;
		CreateMap<CreateClinicDto, Clinic>();
		CreateMap<Clinic, UpdateClinicDto>().ReverseMap();

		// ClinicSessions
		CreateMap<ClinicSession, ClinicSessionDto>()
			.ForMember(src => src.ClinicId, opt => opt.MapFrom(dest => dest.Clinic.Id))
			.ForMember(src => src.ClinicName, opt => opt.MapFrom(dest => dest.Clinic.Name));


		CreateMap<ClinicSessionDto, ClinicSession>();

		CreateMap<Doctor, DoctorDto>()
			.ForMember(src => src.UserId, opt => opt.MapFrom(dest => dest.ApplicationUserId))
			.ForMember(src => src.FirstName, opt => opt.MapFrom(dest => dest.ApplicationUser!.FirstName))
			.ForMember(src => src.LastName, opt => opt.MapFrom(dest => dest.ApplicationUser!.LastName))
			.ForMember(src => src.SpecializationName, opt => opt.MapFrom(dest => dest.Specialization!.Name))
			.ForMember(src => src.PhoneNumber, opt => opt.MapFrom(dest => dest.ApplicationUser!.PhoneNumber))
			.ReverseMap();


		CreateMap<DoctorFormDto, Doctor>();

		CreateMap<Doctor, DoctorFormDto>()
			.ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.ApplicationUser!.FirstName))
			.ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.ApplicationUser!.LastName))
			.ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.ApplicationUser!.UserName))
			.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.ApplicationUser!.Email))
			.ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.ApplicationUser!.PhoneNumber));


		CreateMap<DoctorSchedule, DoctorOverviewScheduleDto>()
			.ForMember(dest => dest.DoctorScheduleDetails,
	opt => opt.MapFrom(src => src.DoctorScheduleDetails.Where(d => !d.IsDeleted)));

		CreateMap<DoctorScheduleDetails, DoctorOverviewScheduleDetailDto>();

		CreateMap<Doctor, DoctorOverviewDto>()
			.ForMember(dest => dest.FirstName,
				opt => opt.MapFrom(src => src.ApplicationUser.FirstName))
			.ForMember(dest => dest.LastName,
				opt => opt.MapFrom(src => src.ApplicationUser.LastName))
			.ForMember(dest => dest.ProfilePhotoUrl,
				opt => opt.MapFrom(src => src.ProfilePhotoPath))
			.ForMember(dest => dest.Specialization,
				opt => opt.MapFrom(src => src.Specialization.Name))
			.ForMember(dest => dest.Schedules,
				opt => opt.MapFrom(src => src.Schedules.Where(s => !s.IsDeleted)));


		CreateMap<RegisterPatientDto, ApplicationUser>();

		CreateMap<DoctorScheduleDto, DoctorSchedule>()
			.ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => DateTime.Parse(src.StartDate)))
			.ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => DateTime.Parse(src.EndDate)))
			.ForMember(dest => dest.DoctorScheduleDetails, opt => opt.MapFrom(src => src.DoctorScheduleDetails))
			.ReverseMap()
			.ForMember(dest => dest.Recurrence, opt => opt.MapFrom(src => (int)src.Recurrence));

		CreateMap<DoctorScheduleDetailsDto, DoctorScheduleDetails>()
			.ForMember(dest => dest.DayOfWeek, opt => opt.MapFrom(src => Enum.Parse<System.DayOfWeek>(src.DayOfWeek)))
			.ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => TimeSpan.Parse(src.StartTime)))
			.ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => TimeSpan.Parse(src.EndTime)))
			.ReverseMap();

	}
}
