namespace HealPoint.BusinessLogic.DTOs;
public class ClinicSessionDto
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public int ClinicId { get; set; }
    public string ClinicName { get; set; }
}
