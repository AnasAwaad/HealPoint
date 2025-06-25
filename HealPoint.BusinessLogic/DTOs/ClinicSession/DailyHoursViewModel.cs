namespace HealPoint.BusinessLogic.DTOs.ClinicSession;
public class DailyHoursViewModel
{
    public string Day { get; set; }
    public bool IsOpen { get; set; }
    public string OpenTime { get; set; } // Consider using TimeSpan or DateTime for better handling
    public string CloseTime { get; set; } // Consider using TimeSpan or DateTime for better handling
}