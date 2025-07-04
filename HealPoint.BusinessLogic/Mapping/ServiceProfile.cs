using AutoMapper;
using HealPoint.DataAccess.Entities;

namespace HealPoint.BusinessLogic.Mapping;
internal class ServiceProfile : Profile
{
	public ServiceProfile()
	{
		CreateMap<Service, ServiceDto>();

		CreateMap<ServiceFormDto, Service>();
	}
}
