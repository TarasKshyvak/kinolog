using AutoMapper;
using BLL;
using BLL.Interfaces;
using BLL.Services;
using BLL.Validators;
using DAL.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

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

//dbcontext
builder.Services.AddDbContext<KinologDbContext>(opts => opts
    .UseSqlServer(builder.Configuration.GetConnectionString("kinolog")));

//automapper
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutomapperProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

//BLL.Services
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<ICreatorService, CreatorService>();

//fluent validation
builder.Services.AddValidatorsFromAssemblyContaining<CreatorModelValidator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opts => opts.DocExpansion(DocExpansion.None));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
