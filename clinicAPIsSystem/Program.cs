using clinicAPIsSystem.Data;
using clinicAPIsSystem.Interfaces.IUserService;
using clinicAPIsSystem.Interfaces.IUserService.IMedicalStaffService;
using clinicAPIsSystem.Models;
using clinicAPIsSystem.Services.UserService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using clinicAPIsSystem.Services.UserService.MedicalStaffService;
using clinicAPIsSystem.Services.UserService.NonMedicalStaffService; 
using System.Text;
using clinicAPIsSystem.Interfaces.IUserService.INonMedicalStaffService;
using clinicAPIsSystem.Interfaces;
using clinicAPIsSystem.Services;

var builder = WebApplication.CreateBuilder(args);

#region Controllers

builder.Services.AddControllers();

#endregion

#region Database

builder.Services.AddDbContext<ClinicDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

#endregion

#region Identity

builder.Services.AddIdentity<ApplicationUser, IdentityRole<int>>(options =>
{
    // Password Settings
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 8;

    // User Settings
    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<ClinicDbContext>()
.AddDefaultTokenProviders();

#endregion

#region Authentication (JWT)

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            // Validate JWT
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            // JWT Configuration
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidAudience = builder.Configuration["JWT:Audience"],

            // Secret Key
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]!)
            ),

            // Remove default 5-minute tolerance
            ClockSkew = TimeSpan.Zero
        };
    });

#endregion

#region Authorization

builder.Services.AddAuthorization();

#endregion

#region Dependency Injection

builder.Services.AddScoped<IApplicationUserService, ApplicationUserService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped < IPatientService, PatientService>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<INurseServices,NurseService>();
builder.Services.AddScoped<IAccountantService,AccountantService>();
builder.Services.AddScoped<ICleanerService, CleanerService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>(); 
builder.Services.AddScoped<IAuthServices,AuthService>();
builder.Services.AddScoped<IMedicalService, MedicalService>();
builder.Services.AddScoped<IOperationService,OperationService>();
builder.Services.AddScoped<IPrescriptionService, PrescriptionService>();
builder.Services.AddScoped<IQualificationService,QualificationService>();
builder.Services.AddScoped<ISpecializationService,SpecializationService>();



#endregion

#region OpenAPI

builder.Services.AddOpenApi();

#endregion

var app = builder.Build();

#region Middleware

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

#endregion