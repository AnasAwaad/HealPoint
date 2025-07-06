using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HealPoint.BusinessLogic.DTOs;
public class SymptomFormDto
{
	public int Id { get; set; }
	[MaxLength(100, ErrorMessage = "Max length can't be more than 100 characters.")]
	[Remote("AllowedSymptomName", "Symptoms", AdditionalFields = "Id", ErrorMessage = "Symptom with the same name is already exists.")]
	public string Name { get; set; } = null!;
}
