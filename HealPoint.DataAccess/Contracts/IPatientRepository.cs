﻿namespace HealPoint.DataAccess.Contracts;
public interface IPatientRepository : IRepository<Patient>
{
	IQueryable<Patient> GetAllWithDetails();
}
