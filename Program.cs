using Microsoft.OpenApi.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
// Agregar servicios de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ToDo API",
        Description = "API para gestionar tareas"
    });
});

var app = builder.Build();

// Configurar Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "ToDo API V1");
        options.RoutePrefix = string.Empty; // Abre Swagger en la raíz
    });
}



app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

