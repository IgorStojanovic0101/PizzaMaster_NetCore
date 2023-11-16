using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using PizzaMaster.Application;
using PizzaMaster.Infrastructure.System;
using Serilog;
using Serilog.Formatting.Compact;
using PizzaMaster.BussinessLogic.Services;
using PizzaMaster.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using PizzaMaster.Domain.Entities;
using PizzaMaster.Infrastructure.Utilities;
using Microsoft.AspNetCore.Http.Features;
using PizzaMaster.DataAccess.EF;
using PizzaMaster.DataAccess.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v3", new OpenApiInfo { Title = "Swagger Pizza Master Solution", Version = "v3" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,
                        },
                        new List<string>()
        }
    });
});

string issuer = builder.Configuration.GetValue<string>("Tokens:Issuer");
string signingKey = builder.Configuration.GetValue<string>("Tokens:Key");
byte[] signingKeyBytes = System.Text.Encoding.UTF8.GetBytes(signingKey);

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = false,
     //   ValidIssuer = issuer,
        ValidateAudience = false,
        //ValidAudience = issuer,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ClockSkew = System.TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes)
    };
});

builder.Services.AddCors();



builder.Services.AddSwaggerGen();
var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 100 * 1024 * 1024; // 50 MB
});

builder.Services.AddSingleton<IConfiguration>(config);

builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddSingleton<IUnitOfWorkFactory, UnitOfWorkFactory>();

builder.Services.AddScoped<IRestoranService,RetoranService>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IErrorService,ErrorService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IHomeService,HomeService>();
builder.Services.AddScoped<IProizvodiService, ProizvodiService>();
builder.Services.AddScoped<IGeolocationService, GeolocationService>();


builder.Services.AddMvc(options => options.Conventions.Add(new RouteConvention()));

builder.Services.AddTransient<GlobalExceptionHandlingMiddleware>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
builder.Services.AddTransient<FileService>();


var logger = new LoggerConfiguration()
 .ReadFrom.Configuration(builder.Configuration)
  .Enrich.WithThreadId().WriteTo.File(Directory.GetCurrentDirectory() + "\\Logs\\log.txt", rollingInterval: RollingInterval.Infinite, outputTemplate: "{Timestamp:MM/dd/yyyy H:mm:ss zzzz} {ThreadId} {Level} {SourceContext} {Message:lj}{NewLine}{Exception}")

 .CreateLogger();

//builder.Logging.ClearProviders();
builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddSerilog(logger);   // Add Serilog to the LoggingBuilder for Winforms
});
var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI(c =>
//    {
//        c.SwaggerEndpoint("/swagger/v2/swagger.json", "Swagger Pizza Master Solution v2");
//    });
//}


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v3/swagger.json", "Swagger Pizza Master Solution v3");
});

app.UseHttpsRedirection();


app.UseRouting();

app.UseCors(options =>
{
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
