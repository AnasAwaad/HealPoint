namespace HealPoint.BusinessLogic.DTOs;
public class ClinicListDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string? ImagePath { get; set; }
    public string ContactNumber { get; set; } = null!;
    public string Speciality { get; set; } = null!;
    public string ClinicAdmin { get; set; } = null!;
    public bool Status { get; set; }


}
