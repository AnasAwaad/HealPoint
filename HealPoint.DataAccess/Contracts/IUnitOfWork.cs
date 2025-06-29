﻿namespace HealPoint.DataAccess.Contracts;
public interface IUnitOfWork : IDisposable
{
    ICategoryRepository Categories { get; }
    IClinicRepository Clinics { get; }
    IClinicSessionRepository ClinicSessions { get; }
    ISpecializationRepository Specializations { get; }

    void SaveChanges();
}
