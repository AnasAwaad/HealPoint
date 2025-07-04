﻿namespace HealPoint.DataAccess.Contracts;
public interface IDoctorRepository : IRepository<Doctor>
{
	IQueryable<Doctor> GetAllWithDetails();
	Doctor? GetDoctorByContactEmail(string email);
	Doctor? GetDoctorByEmergencyContactPhone(string emergencyContactNumber);
	Doctor? GetDoctorByIdWithDetails(int id);
	Doctor? GetByIdWithUser(int id);
	Doctor? GetDoctorByUserId(string userId);
}
