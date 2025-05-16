using System.ComponentModel.DataAnnotations.Schema;

namespace HealPoint.DataAccess.Entities;
public class Category : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string? ImagePath { get; set; }
    public int? ParentCategoryId { get; set; }

    [ForeignKey("ParentCategoryId")]
    public Category ParentCategory { get; set; }
}
