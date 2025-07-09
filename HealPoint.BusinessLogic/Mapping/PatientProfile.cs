using AutoMapper;
using HealPoint.DataAccess.Entities;

namespace HealPoint.BusinessLogic.Mapping;
internal class PatientProfile : Profile
{
	public PatientProfile()
	{
		CreateMap<Patient, PatientDto>()
			.ForMember(src => src.UserId, opt => opt.MapFrom(dest => dest.ApplicationUserId))
			.ForMember(src => src.FirstName, opt => opt.MapFrom(dest => dest.User!.FirstName))
			.ForMember(src => src.LastName, opt => opt.MapFrom(dest => dest.User!.LastName))
			.ForMember(src => src.PhoneNumber, opt => opt.MapFrom(dest => dest.User!.PhoneNumber))
			.ForMember(src => src.Email, opt => opt.MapFrom(dest => dest.User!.Email))
			.ReverseMap();

	}
}
