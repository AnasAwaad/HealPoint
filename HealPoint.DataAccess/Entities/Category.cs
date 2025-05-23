namespace HealPoint.DataAccess.Entities;
public class Category : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string? ImagePath { get; set; }
    public bool IsFeatured { get; set; }
    public bool Status { get; set; } = true;
    public int? ParentCategoryId { get; set; }
    public Category ParentCategory { get; set; }
}
