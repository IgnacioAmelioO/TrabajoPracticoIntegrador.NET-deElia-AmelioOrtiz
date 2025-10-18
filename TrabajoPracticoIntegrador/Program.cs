using Domain.Model;
using Domain.Services;
using DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.Text;
using TrabajoPracticoIntegrador;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpLogging(o => { });

// Configure JWT
var jwtSettings = builder.Configuration.GetSection("Jwt");
var secretKey = jwtSettings["Key"];
var issuer = jwtSettings["Issuer"];
var audience = jwtSettings["Audience"];

// Validate JWT settings
if (string.IsNullOrEmpty(secretKey))
{
    throw new InvalidOperationException("JWT Key is not configured in appsettings.json");
}

if (secretKey.Length < 32)
{
    throw new InvalidOperationException("JWT Key is too short. It should be at least 32 characters long.");
}

Debug.WriteLine($"[DEBUG] JWT Key length: {secretKey.Length}");
Debug.WriteLine($"[DEBUG] JWT Issuer: {issuer}");
Debug.WriteLine($"[DEBUG] JWT Audience: {audience}");

// Add Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = issuer,
        ValidateAudience = true,
        ValidAudience = audience,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!)),
        ClockSkew = TimeSpan.Zero
    };
    
    // Add event handling for better debugging
    options.Events = new JwtBearerEvents
    {
        OnAuthenticationFailed = context =>
        {
            Debug.WriteLine($"[ERROR] JWT Authentication failed: {context.Exception.Message}");
            return Task.CompletedTask;
        },
        OnTokenValidated = context =>
        {
            Debug.WriteLine("[DEBUG] JWT Token validated successfully");
            return Task.CompletedTask;
        },
        OnMessageReceived = context =>
        {
            Debug.WriteLine("[DEBUG] JWT Token received");
            return Task.CompletedTask;
        },
        OnChallenge = context =>
        {
            Debug.WriteLine("[DEBUG] JWT Challenge issued");
            return Task.CompletedTask;
        }
    };
});

// Add Authorization
builder.Services.AddAuthorization();

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
    app.UseHttpLogging();
}

app.UseHttpsRedirection();

// Use CORS
app.UseCors("AllowBlazorWasm");

// Configure authentication and authorization middleware
// These lines are important and must be before the endpoint mappings
app.UseAuthentication();
app.UseAuthorization();

// ================= AUTH ENDPOINTS =================
app.MapAuthEndpoints();

// ================= PERSONAS CRUD =================
app.MapPersonaEndpoints();

// ================= PLANES CRUD =================
app.MapPlanEndpoints();

// ================= ESPECIALIDADES CRUD =================
app.MapEspecialidadEndpoints();

// ================= CURSOS CRUD =================
app.MapCursoEndpoints();

app.MapComisionEndpoints();

app.MapMateriaEndpoints();

// ================= USUARIOS CRUD =================
app.MapUsuarioEndpoints();

// ================= ALUMNO INSCRIPCIONES CRUD =================
app.MapAlumnoInscripcionEndpoints();

app.Run();
