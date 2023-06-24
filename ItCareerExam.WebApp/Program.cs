using ItCareerExam.Data;
using ItCareerExam.Data.Models;
using ItCareerExam.WebApp.Seed;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContextFactory<AppDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services
    .AddDefaultIdentity<AppUser>(
        options =>
        {
            options.SignIn.RequireConfirmedAccount = true;
        })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddRazorPages();

builder.Services.AddAutoMapper(typeof(ItCareerExam.Service.Mappings.MappingProfile));

ItCareerExam.Service.ContainerRegistrations.ConfigureServices(builder.Services);
ItCareerExam.Data.ContainerRegistrations.ConfigureServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.SeedDatabase();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

//////////////////////////////////////////////////////////////////////////////////
//
// to create initial migration use package manager console to run:
// add-migration -Name CreateSchemaMigration -Context AppDbContext -StartupProject ItCareerExam.WebApp -Project ItCareerExam.Data
//
// to apply migrations to a database
// dotnet ef database update --project ItCareerExam.WebApp --context AppDbContext
//
// to seed database:
// INSERT INTO AspNetRoles (Id, Name, NormalizedName, ConcurrencyStamp)
// VALUES('eec4ddaf-d038-4532-9999-9ab3857f427f', 'Admin', 'ADMIN', '246753e9-62f5-4aad-915e-64df2a4a75bd');
//
// INSERT INTO AspNetUserRoles (UserId, RoleId)
// VALUES('76e94d15-b7e7-4d0c-83c8-79911c79648b', 'eec4ddaf-d038-4532-9999-9ab3857f427f');
//
//