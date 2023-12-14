using CVLookup_WebAPI.Middleware;
using CVLookup_WebAPI.Services.AccountService;
using CVLookup_WebAPI.Services.AccountUserService;
using CVLookup_WebAPI.Services.AuthService;
using CVLookup_WebAPI.Services.CandidateService;
using CVLookup_WebAPI.Services.CurriculumService;
using CVLookup_WebAPI.Services.EmployerService;
using CVLookup_WebAPI.Services.ExperienceService;
using CVLookup_WebAPI.Services.FileService;
using CVLookup_WebAPI.Services.JobAddressService;
using CVLookup_WebAPI.Services.JobCareerService;
using CVLookup_WebAPI.Services.JobFieldService;
using CVLookup_WebAPI.Services.JobFormService;
using CVLookup_WebAPI.Services.JobPositionService;
using CVLookup_WebAPI.Services.JwtService;
using CVLookup_WebAPI.Services.MailService;
using CVLookup_WebAPI.Services.NotificationService;
using CVLookup_WebAPI.Services.RecruitmentCVService;
using CVLookup_WebAPI.Services.RecruitmentService;
using CVLookup_WebAPI.Services.RefreshTokenService;
using CVLookup_WebAPI.Services.RoleService;
using CVLookup_WebAPI.Services.SignalRService;
using CVLookup_WebAPI.Services.UserRoleService;
using CVLookup_WebAPI.Services.UserService;
using CVLookup_WebAPI.Utilities;
using FirstWebApi.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

//services to the container.

builder.Services.AddDbContext<AppDBContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("Connection");
    options.UseSqlServer(connectionString);
});



//automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//service
builder.Services.AddScoped<IAccountUserService, AccountUserService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ICandidateService, CandidateService>();
builder.Services.AddScoped<ICurriculumViateService, CurriculumVitaeService>();
builder.Services.AddScoped<IEmployerService, EmployerService>();
builder.Services.AddScoped<IExperienceService, ExperienceService>();
builder.Services.AddScoped<IJobAddressService, JobAddressService>();
builder.Services.AddScoped<IJobCareerService, JobCareerService>();
builder.Services.AddScoped<IJobFieldService, JobFieldService>();
builder.Services.AddScoped<IJobFormService, JobFormService>();
builder.Services.AddScoped<IJobPositionService, JobPositionService>();
builder.Services.AddScoped<IRecruitmentCVService, RecruitmentCVService>();
builder.Services.AddScoped<IRecruitmentService, RecruitmentService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IUserRoleService, UserRoleService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IMailService, MailService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddTransient<IJwtService, JwtService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<NotificationHub>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddSignalR(options =>
{
    options.EnableDetailedErrors = true;
});

//custom data validate error
builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
        {
            var messages = context.ModelState.Keys.Select(key =>
            {
                return new[]
                {
                    context.ModelState[key]?.Errors.Select(error => error.ErrorMessage)
                };
            });

            var response = new ApiResponse
            {
                Success = false,
                Code = 400,
                Message = messages
            };
            return new OkObjectResult(response);
        };
    });

//Cors
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("http://localhost:3000")
                   .AllowAnyMethod()
                   .AllowAnyHeader()
                   .AllowCredentials();
        });
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "CVLooup API", Version = "v1" });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    // Sử dụng XML Comments
    var dir = new DirectoryInfo(AppContext.BaseDirectory);
    foreach (var fi in dir.EnumerateFiles("*.xml"))
    {
        options.IncludeXmlComments(fi.FullName);
    }

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "CVLookup API V1");
    });
    app.UseDeveloperExceptionPage();
}


app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.MapControllers();
app.UseCors();
app.MapHub<NotificationHub>("/notification/hub");

app.Run();
