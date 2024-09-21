using Application.Validators;
using FluentValidation.AspNetCore;
using Infrastructure.Context;
using Infrastructure.Utils;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

InjectorDependencies.Registrer(builder.Services);

builder.Services.AddControllers().AddFluentValidation(fv =>
{
    fv.RegisterValidatorsFromAssemblyContaining<PhotoValidator>();
});

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

try
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    using (var connection = new SqlConnection(connectionString))
    {
        connection.Open();
        Console.WriteLine("Conexão bem-sucedida com o banco de dados!");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Erro ao conectar ao banco de dados: {ex.Message}");
}

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
