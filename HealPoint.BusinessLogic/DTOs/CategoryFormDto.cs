using System.ComponentModel.DataAnnotations;

namespace HealPoint.BusinessLogic.DTOs;
public class CategoryFormDto
{
    public int Id { get; set; }
    [MaxLength(100, ErrorMessage = "Max length can't be more than 100 characters")]
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
}
