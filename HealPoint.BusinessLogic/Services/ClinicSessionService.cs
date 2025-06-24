using AutoMapper;
using HealPoint.BusinessLogic.Contracts;
using HealPoint.BusinessLogic.DTOs;
using HealPoint.DataAccess.Contracts;
using HealPoint.DataAccess.Entities;

namespace HealPoint.BusinessLogic.Services;
internal class ClinicSessionService : IClinicSessionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ClinicSessionService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public ClinicSessionListDto GetSessionsByClinicId(int clinicId)
    {
        var sessions = _unitOfWork.ClinicSessions.GetAllSessionsByClinicId(clinicId);


        return new ClinicSessionListDto
        {
            ClinicSessions = _mapper.Map<IEnumerable<ClinicSessionDto>>(sessions),
            ClinicId = clinicId,
        };
    }

    public void SaveClinicSessions(IEnumerable<ClinicSessionDto> clinicSessionDtos)
    {
        var clinicId = clinicSessionDtos.First().ClinicId;
        var existingSessions = _unitOfWork.ClinicSessions.GetAllSessionsByClinicId(clinicId);

        if (existingSessions.Any())
            _unitOfWork.ClinicSessions.RemoveRange(existingSessions);

        var sessions = _mapper.Map<IEnumerable<ClinicSession>>(clinicSessionDtos);

        foreach (var session in sessions)
        {
            _unitOfWork.ClinicSessions.Insert(session);
        }
        _unitOfWork.SaveChanges();
    }
}
