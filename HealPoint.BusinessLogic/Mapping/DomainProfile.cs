using AutoMapper;
using HealPoint.BusinessLogic.DTOs;
using HealPoint.DataAccess.Entities;

namespace HealPoint.BusinessLogic.Mapping;
public class DomainProfile : Profile
{
    public DomainProfile()
    {
        CreateMap<Category, CategoryListDto>();
        CreateMap<CreateCategoryDto, Category>();
    }
}
