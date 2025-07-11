﻿using HealPoint.BusinessLogic.Contracts;
using HealPoint.BusinessLogic.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HealPoint.BusinessLogic;
public static class AddBusinessLogicExtensions
{
	public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services)
	{

		services.AddScoped<IDepartmentService, DepartmentService>();
		services.AddScoped<ISpecializationService, SpecializationService>();
		services.AddScoped<IClinicService, ClinicService>();
		services.AddScoped<IClinicSessionService, ClinicSessionService>();
		services.AddScoped<IDoctorService, DoctorService>();
		services.AddScoped<IDoctorScheduleService, DoctorScheduleService>();
		services.AddScoped<IAuthService, AuthService>();
		services.AddScoped<IServiceManager, ServiceManager>();
		services.AddScoped<ISymptomService, SymptomService>();
		services.AddScoped<IPatientService, PatientService>();



		services.AddTransient<IFileStorageService, FileStorageService>();
		services.AddTransient<IEmailSender, EmailSender>();

		services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

		return services;
	}
}
