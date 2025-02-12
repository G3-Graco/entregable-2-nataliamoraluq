using Core.Interfaces;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Services;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Services.Services;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//examen 1 pregunta B - swagger y como implementarlo - natalia ml
//Program.cs field > Web project

builder.Services.AddSwaggerGen(options =>{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        //info a presentar en la doc.
        Version = "v1",
        Title = "API rpg to do",
        Description = "An ASP.NET Core Web API for an rpg game",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",Url = new Uri("https://example.com/license")
        }
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    
});

//Program.cs field > Web project





builder.Services.AddControllers();

builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
builder.Services.AddScoped(typeof(IPersonajeService), typeof(PersonajeService));
builder.Services.AddScoped(typeof(IHabilidadService), typeof(HabilidadService));
builder.Services.AddScoped(typeof(IPersonajeRepository), typeof(PersonajeRepository));
builder.Services.AddScoped(typeof(IHabilidadRepository), typeof(HabilidadRepository));
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

builder.Services.AddDbContext<AppDbContext>(patata =>
        patata.UseNpgsql("Host=dpg-cu8lfdhu0jms738cjl4g-a;Server=dpg-cu8lfdhu0jms738cjl4g-a.oregon-postgres.render.com;Port=5432;Database=netcore2025graco;Username=netcore2025graco_user;Password=poip27oYyj7iu9y7oxpkXezLliJrsyIh",
        b => b.MigrationsAssembly("Infrastructure")
        ));


//builder.Services.AddDbContext<AppDbContext>(options =>
//                    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
//            );

var app = builder.Build();

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.Run();

