using DbViewChallenge.Api.Aplication.Interfaces;
using DbViewChallenge.Api.Aplication.Services;
using DbViewChallenge.Api.Domain.Interfaces;
using DbViewChallenge.Api.Infrastructure.Context;
using DbViewChallenge.Api.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddSingleton(new DBcontext(connectionString!));
builder.Services.AddScoped<IRelatorioPesoViewRepository, RelatorioPesoViewRepository>();
builder.Services.AddScoped<IRelatorioPesoService, RelatorioPesoService>();

// Blazor
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazor", b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowBlazor");
app.MapControllers();
app.Run();