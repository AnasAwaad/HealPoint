namespace HealPoint.DataAccess.Entities;
public class BaseEntity
{
    public int Id { get; set; }
    // user id
    public int? CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    // user id
    public int? LastUpdatedBy { get; set; }
    public DateTime? LastUpdatedOn { get; set; }
    // soft delete
    public bool IsDeleted { get; set; }
}
