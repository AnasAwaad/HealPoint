namespace HealPoint.BusinessLogic.Contracts;
public interface ISymptomService
{
	IEnumerable<SymptomDto> GetAllSymptoms();
	SymptomFormDto? GetSymptomById(int id);
	IEnumerable<SymptomDto> GetSymptomsLookup();
	SymptomDto CreateSymptom(SymptomFormDto department);
	SymptomDto? UpdateSymptom(SymptomFormDto department);
	(bool? isDeleted, string? lastUpdatedOn) UpdateSymptomStatus(int id);
	bool DeleteSymptom(int id);
	bool IsSymptomAllowed(SymptomFormDto department);
	IEnumerable<SymptomDto> GetActiveSymptoms();
}
