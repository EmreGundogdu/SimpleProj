using API.Extensions;
using API.Valdations;
using DataModels;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient("garantiAPI", config =>
{
    config.BaseAddress = new Uri("http://www.garanti.com");
    config.DefaultRequestHeaders.Add("Authorization", "Bearer 1212121");
});
builder.Services.ConfigureMapping();
builder.Services.AddTransient<IValidator<ContactDVO>, ContactValidator>();
builder.Services.AddHealthChecks();
builder.Services.AddScoped<IContactService,ContactService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCustomHealthCheck();

app.UseResponseCaching();
//uygulamanýn aktif olarak çalýþýp çalýþmadýðýný denetler
app.UseAuthorization();

app.MapControllers();

app.Run();
