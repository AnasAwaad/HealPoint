using AutoMapper;
using HealPoint.DataAccess.Entities;

namespace HealPoint.BusinessLogic.Mapping;
internal class ServiceProfile : Profile
{
	public ServiceProfile()
	{
		CreateMap<Service, ServiceDto>()
			.ReverseMap();

		CreateMap<ServiceFormDto, Service>()
			.ReverseMap();
	}
}
