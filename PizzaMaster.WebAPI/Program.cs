using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using PizzaMaster.Application;
using PizzaMaster.Data.SQLConnection;
using PizzaMaster.DatabaseAccess.UnitOfWork;
using PizzaMaster.Infrastructure.System;
using Serilog;
using Serilog.Formatting.Compact;
using PizzaMaster.BussinessLogic.Services;
using PizzaMaster.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using PizzaMaster.Domain.Entities;
using PizzaMaster.Data.EF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger Pizza Master Solution", Version = "v1" });

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
        



builder.Services.AddSwaggerGen();
var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

builder.Services.AddSingleton<IConfiguration>(config);

builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddSingleton<IUnitOfWorkFactory, UnitOfWorkFactory>();
builder.Services.AddSingleton<ISqlConnectionFactory, SqlConnectionFactory>();

builder.Services.AddScoped<IRestoranService,RetoranService>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IErrorService,ErrorService>();



builder.Services.AddMvc(options => options.Conventions.Add(new RouteConvention()));

builder.Services.AddTransient<GlobalExceptionHandlingMiddleware>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));


var logger = new LoggerConfiguration()
 .ReadFrom.Configuration(builder.Configuration)
 .Enrich.FromLogContext().WriteTo.File(new CompactJsonFormatter(), "log.txt")
 .CreateLogger();

//builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Pizza Master Solution v1");
    });
}

app.UseHttpsRedirection();




app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
