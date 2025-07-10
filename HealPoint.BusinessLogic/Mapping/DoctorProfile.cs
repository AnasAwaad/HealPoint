using AutoMapper;
using HealPoint.BusinessLogic.DTOs.Doctor;
using HealPoint.BusinessLogic.DTOs.DoctorSchedule;
using HealPoint.DataAccess.Entities;

namespace HealPoint.BusinessLogic.Mapping;
internal class DoctorProfile : Profile
{
	public DoctorProfile()
	{
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

		CreateMap<Doctor, DoctorDetailsDto>()
			.ForMember(d => d.FullName, opt => opt.MapFrom(src => $"{src.ApplicationUser.FirstName} {src.ApplicationUser.LastName}"))
			.ForMember(d => d.SpecializationName, opt => opt.MapFrom(src => src.Specialization.Name));
	}
}
