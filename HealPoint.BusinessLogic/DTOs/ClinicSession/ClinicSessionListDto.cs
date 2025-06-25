namespace HealPoint.BusinessLogic.DTOs;
public class ClinicSessionListDto
{
    public IEnumerable<ClinicSessionDto> ClinicSessions { get; set; }
    public int ClinicId { get; set; }
}
