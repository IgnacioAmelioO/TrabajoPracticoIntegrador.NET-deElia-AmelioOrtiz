using Domain.Model;
using Domain.Services;
using DTOs;
using TrabajoPracticoIntegrador;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpLogging(o => { });

// Add CORS for Blazor WebAssembly
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorWasm",
        policy =>
        {
            policy.WithOrigins("https://localhost:7003", "http://localhost:5255")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //Falta configurar de manera correcta        
    app.UseHttpLogging();
}

app.UseHttpsRedirection();

// Use CORS
app.UseCors("AllowBlazorWasm");

// ================= PERSONAS CRUD =================

app.MapPersonaEndpoints();

// ================= PLANES CRUD =================

app.MapPlanEndpoints();

// ================= ESPECIALIDADES CRUD =================

app.MapEspecialidadEndpoints();

// ================= CRUSOS CRUD =================

app.MapCursoEndpoints();

app.Run();
