using BackHero_CRUD.Application.Services;
using BackHero_CRUD.Domain.Entities;
using BackHero_CRUD.Domain.Interfaces;
using BackHero_CRUD.Infrastructure;
using BackHero_CRUD.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IHeroiRepository, HeroRepository>();
builder.Services.AddScoped<ISuperpoderRepository, SuperpoderRepository>();

builder.Services.AddScoped<IHeroiService, HeroiService>();
builder.Services.AddScoped<ISuperpoderService, SuperpoderService>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<HeroDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("BackHero_CRUD.Infrastructure"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()    
                  .AllowAnyMethod();   
        });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<HeroDbContext>();
    if (!context.Superpoderes.Any())
    {
        context.Superpoderes.AddRange(
            new Superpoderes { Superpoder = "Elasticidade", Descricao = "Todo o seu corpo ganha as propiedades de borracha." },
            new Superpoderes { Superpoder = "Teleporte", Descricao = "Consegue se teleportar para qualquer lugar que ja tenha visto." },
            new Superpoderes { Superpoder = "Invisibilidade", Descricao = "Ficar invisível aos olhos." }
        );
        await context.SaveChangesAsync();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
