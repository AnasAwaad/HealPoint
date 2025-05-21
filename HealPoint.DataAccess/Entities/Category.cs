using System.ComponentModel.DataAnnotations.Schema;

namespace HealPoint.DataAccess.Entities;
[Index(nameof(Name), IsUnique = true)]
public class Category : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string? ImagePath { get; set; }
    public bool IsFeatured { get; set; }
    public bool Status { get; set; } = true;
    public int? ParentCategoryId { get; set; }

    [ForeignKey("ParentCategoryId")]
    public Category ParentCategory { get; set; }
}
