using AutoMapper;
using BLL;
using BLL.Authorization;
using BLL.Helpers;
using BLL.Interfaces;
using BLL.Services;
using BLL.Validators;
using DAL.Data;
using FluentValidation;
using kinolog.Middleware;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NLog;
using NLog.Web;
using Swashbuckle.AspNetCore.SwaggerUI;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Info("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddControllers();

    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    builder.Services.AddEndpointsApiExplorer();

    builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "KinoLog API",
            Contact = new OpenApiContact
            {
                Name = "Taras Kshyvak",
                Email = "shkivac@gmail.com"
            }
        });
    });

    // Db context
    builder.Services.AddDbContext<KinologDbContext>(opts => opts
        .UseSqlServer(builder.Configuration.GetConnectionString("kinolog")));

    // Automapper
    var mapperConfig = new MapperConfiguration(mc =>
    {
        mc.AddProfile(new AutomapperProfile());
    });

    IMapper mapper = mapperConfig.CreateMapper();
    builder.Services.AddSingleton(mapper);

    // Strongly typed settings object
    builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

    // BLL.Services
    builder.Services.AddScoped<IMovieService, MovieService>();
    builder.Services.AddScoped<ICreatorService, CreatorService>();
    builder.Services.AddScoped<ICountryService, CountryService>();
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<IJwtUtils, JwtUtils>();

    // Fluent validation
    builder.Services.AddValidatorsFromAssemblyContaining<CreatorModelValidator>();

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(opts => opts.DocExpansion(DocExpansion.None));
    }

    // kinolog.Middleware
    app.UseMiddleware<ErrorHandlerMiddleware>();
    app.UseMiddleware<JwtMiddleware>();

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit
    NLog.LogManager.Shutdown();
}
