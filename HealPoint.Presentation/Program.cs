using HealPoint.BusinessLogic;
using HealPoint.DataAccess;
using HealPoint.DataAccess.Common;
using HealPoint.DataAccess.Data;
using HealPoint.Presentation.Seeds;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HealPoint.Presentation;

public class Program
{
	public static async Task Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);
		var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found."); ;

		builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

		builder.Services.AddIdentity<ApplicationUser, IdentityRole>(option => option.SignIn.RequireConfirmedAccount = false)
		   .AddEntityFrameworkStores<ApplicationDbContext>()
		   .AddDefaultUI()
		   .AddDefaultTokenProviders();
		builder.Services.ConfigureApplicationCookie(options =>
		{
			options.LoginPath = "/Account/Register";
		});

		builder.Services.Configure<IdentityOptions>(options =>
		{
			// Default Password settings.
			options.Password.RequireDigit = false;
			options.Password.RequireLowercase = false;
			options.Password.RequireNonAlphanumeric = false;
			options.Password.RequireUppercase = false;
			options.Password.RequiredLength = 1;
			options.Password.RequiredUniqueChars = 0;
		});

		builder.Services.Configure<MailSettings>(builder.Configuration.GetSection(nameof(MailSettings)));

		#region Add services to the container.

		builder.Services.AddControllersWithViews();

		builder.Services
			.AddBusinessLogicServices()
			.AddDataAccessServices(builder.Configuration);

		#endregion

		var app = builder.Build();

		// Configure the HTTP request pipeline.
		if (!app.Environment.IsDevelopment())
		{
			app.UseExceptionHandler("/Home/Error");
			// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
			app.UseHsts();
		}

		app.UseHttpsRedirection();
		app.UseStaticFiles();

		app.UseRouting();

		app.UseAuthorization();

		var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
		using var scope = scopeFactory.CreateScope();

		var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
		var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

		await DefaultRoles.SeedRoles(roleManager);
		await DefaultUsers.SeedUsers(userManager);

		app.MapRazorPages();
		app.MapControllerRoute(
			name: "default",
			pattern: "{controller=Home}/{action=Index}/{id?}");

		app.Run();
	}
}
