using AutoMapper;
using HealPoint.BusinessLogic.DTOs;
using HealPoint.DataAccess.Entities;

namespace HealPoint.BusinessLogic.Mapping;
public class DomainProfile : Profile
{
	public DomainProfile()
	{
		CreateMap<Category, CategoryDto>().ReverseMap();
		CreateMap<CategoryFormDto, Category>().ReverseMap();
	}
}
