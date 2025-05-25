using System.ComponentModel.DataAnnotations.Schema;

namespace HealPoint.DataAccess.Entities;
public class Clinic : BaseEntity
{
	public string Name { get; set; } = null!;
	public string Description { get; set; } = null!;
	public string? ImagePath { get; set; }
	public string Email { get; set; } = null!;
	public string ContactNumber { get; set; } = null!;
	public int? SpecializationId { get; set; }
	[ForeignKey("SpecializationId")]
	public Specialization? Specialization { get; set; }
	public int TimeSlotInMinutes { get; set; } // 15, 30, 60 minutes
	public bool Status { get; set; } = true;

	// Address Details
	public string Address { get; set; } = null!;
	public string Country { get; set; } = null!;
	public string State { get; set; } = null!;
	public string City { get; set; } = null!;
	public string PostalCode { get; set; } = null!;
	public double? Latitude { get; set; }
	public double? Longitude { get; set; }
}
