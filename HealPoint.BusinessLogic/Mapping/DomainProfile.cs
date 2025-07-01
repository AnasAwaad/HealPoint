using AutoMapper;
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

		CreateMap<RegisterPatientDto, ApplicationUser>();

		CreateMap<TimeSlot, TimeSlotDto>();
	}
}
