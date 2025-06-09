using AutoMapper;
using HealPoint.BusinessLogic.DTOs;
using HealPoint.DataAccess.Entities;

namespace HealPoint.BusinessLogic.Mapping;
public class DomainProfile : Profile
{
    public DomainProfile()
    {
        // Categories
        CreateMap<CategoryDto, Category>().ReverseMap()
            .ForMember(src => src.ParentCategoryName, opt => opt.MapFrom(dest => dest.ParentCategory.Name));
        CreateMap<CategoryFormDto, Category>().ReverseMap();
        CreateMap<CategoryFormDto, CategoryDto>().ReverseMap();

        // Specialization
        CreateMap<SpecializationDto, Specialization>().ReverseMap()
            .ForMember(src => src.CategoryName, opt => opt.MapFrom(dest => dest.Category.Name));

        CreateMap<SpecializationFormDto, Specialization>().ReverseMap();
        CreateMap<SpecializationFormDto, CategoryDto>().ReverseMap();


        // Clinics
        CreateMap<Clinic, ClinicListDto>()
            .ForMember(src => src.Speciality, opt => opt.MapFrom(dest => dest.Specialization.Name)); ;
        CreateMap<CreateClinicDto, Clinic>();
        CreateMap<Clinic, UpdateClinicDto>().ReverseMap();

        // ClinicSessions
        CreateMap<ClinicSession, ClinicSessionDto>()
            .ForMember(src => src.ClinicId, opt => opt.MapFrom(dest => dest.Clinic.Id))
            .ForMember(src => src.ClinicName, opt => opt.MapFrom(dest => dest.Clinic.Name));

    }
}
