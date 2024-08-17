using Microsoft.EntityFrameworkCore;
using WebApiPerson.Context;
using WebApiPerson.Repositories;
using WebApiPerson.Services;

var builder = WebApplication.CreateBuilder(args);

// Crear variables para la cadena de conexión
var connectionString = builder.Configuration.GetConnectionString("Connection");

// Registrar el servicio para la conexión
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(connectionString)
);

// Registrar el repositorio y el servicio
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPersonService, PersonService>();

// Configurar CORS para permitir solicitudes desde tu aplicación React
builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactPolicy",
        builder => builder.WithOrigins("http://localhost:5173") // Cambia esto por la URL de tu app React
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

builder.Services.AddControllers();
// Configurar Swagger para documentación de la API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar el pipeline de solicitud HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}




// Usar CORS
app.UseCors("ReactPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
