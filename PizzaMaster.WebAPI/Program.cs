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
using Azure.Identity;
using Microsoft.Extensions.Configuration.AzureKeyVault;

var builder = WebApplication.CreateBuilder(args /*new WebApplicationOptions { EnvironmentName = "Production"}*/);


if(builder.Environment.IsProduction())
{
    string keyVaultUrl = builder.Configuration.GetValue<string>("KeyVault:KeyVaultURL");
    var keyVaultUri = new Uri(keyVaultUrl);

    var azureCredentials = new DefaultAzureCredential();


    builder.Configuration.AddAzureKeyVault(keyVaultUri, azureCredentials);

}


builder.Services.AddControllers(options => 
{  
    options.Conventions.Add(new RouteConvention());
});
builder.Services.AddEndpointsApiExplorer();

if (builder.Environment.IsDevelopment())
{

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


}

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    string signingKey = builder.Configuration.GetValue<string>("Tokens:Key");
    byte[] signingKeyBytes = System.Text.Encoding.UTF8.GetBytes(signingKey);
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

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});




builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 100 * 1024 * 1024; // 50 MB
});





builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var connectionStr = builder.Environment.IsDevelopment() ? builder.Configuration.GetConnectionString("DefaultConnection") :  builder.Configuration.GetSection("ProdConnection").Value;

    options.UseSqlServer(connectionStr, x => x.UseNetTopologySuite());
});
builder.Services.AddSingleton<IUnitOfWorkFactory, UnitOfWorkFactory>();

builder.Services.AddScoped<IRestoranService,RetoranService>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IErrorService,ErrorService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IHomeService,HomeService>();
builder.Services.AddScoped<IProizvodiService, ProizvodiService>();
builder.Services.AddScoped<IGeolocationService, GeolocationService>();
builder.Services.AddScoped<IDropdownService, DropdownService>();

builder.Services.AddHttpContextAccessor();


builder.Services.AddTransient<GlobalExceptionHandlingMiddleware>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
builder.Services.AddTransient<FileService>();



builder.Services.AddLogging(logging =>
{
    Log.Logger = new LoggerConfiguration()
           .ReadFrom.Configuration(builder.Configuration)
           .Enrich.WithThreadId()
           .WriteTo.File(
               Directory.GetCurrentDirectory() + "\\Logs\\log.txt",
               rollingInterval: RollingInterval.Infinite,
               outputTemplate: "{Timestamp:MM/dd/yyyy H:mm:ss zzzz} {ThreadId} {Level} {SourceContext} {Message:lj}{NewLine}{Exception}"            
           )
           .CreateLogger();

    logging.AddConsole(); // Adds console logging
    logging.AddDebug(); // Adds debug logging
    logging.AddSerilog();

});



ServiceLocator.Initialize(builder.Services);

var app = builder.Build();





if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v3/swagger.json", "Swagger Pizza Master Solution v3");
    });
}
app.UseHttpsRedirection();


app.UseRouting();

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<LocalizationMiddleware>();

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
