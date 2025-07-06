using AutoMapper;
using HealPoint.DataAccess.Entities;

namespace HealPoint.BusinessLogic.Mapping;
internal class SymptomProfile : Profile
{
	public SymptomProfile()
	{
		CreateMap<SymptomDto, Symptom>().ReverseMap();

		CreateMap<SymptomFormDto, Symptom>().ReverseMap();
		CreateMap<SymptomFormDto, SymptomDto>().ReverseMap();

	}
}
