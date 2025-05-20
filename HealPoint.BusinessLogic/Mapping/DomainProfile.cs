using AutoMapper;
using HealPoint.BusinessLogic.DTOs;
using HealPoint.DataAccess.Entities;

namespace HealPoint.BusinessLogic.Mapping;
public class DomainProfile : Profile
{
	public DomainProfile()
	{
		CreateMap<CategoryDto, Category>().ReverseMap()
			.ForMember(src => src.ParentCategoryName, opt => opt.MapFrom(dest => dest.ParentCategory.Name));
		CreateMap<CategoryFormDto, Category>().ReverseMap();
		CreateMap<CategoryFormDto, CategoryDto>().ReverseMap();
	}
}
