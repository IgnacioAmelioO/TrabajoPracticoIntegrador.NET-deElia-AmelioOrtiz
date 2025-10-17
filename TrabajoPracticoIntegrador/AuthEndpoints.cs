using DTOs;
using Domain.Services;
using System.Diagnostics;

namespace TrabajoPracticoIntegrador
{
    public static class AuthEndpoints
    {
        public static void MapAuthEndpoints(this WebApplication app)
        {
            app.MapPost("/auth/login", async (LoginRequest request, IConfiguration configuration) =>
            {
                try
                {
                    Debug.WriteLine($"[DEBUG] Login request received for user: {request.Username}");
                    
                    if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
                    {
                        Debug.WriteLine("[ERROR] Login attempt with empty username or password");
                        return Results.BadRequest(new { error = "El nombre de usuario y la contraseña son obligatorios" });
                    }
                    
                    var authService = new AuthService(configuration);
                    var response = await authService.LoginAsync(request);

                    if (response == null)
                    {
                        Debug.WriteLine($"[ERROR] Authentication failed for user: {request.Username}");
                        return Results.Unauthorized();
                    }

                    // Validate response before returning
                    if (string.IsNullOrEmpty(response.Token))
                    {
                        Debug.WriteLine("[ERROR] Generated token is empty");
                        return Results.Problem("Error interno del servidor: el token generado es inválido");
                    }

                    Debug.WriteLine($"[DEBUG] Login successful for user: {request.Username}");
                    Debug.WriteLine($"[DEBUG] Token length: {response.Token.Length}");
                    return Results.Ok(response);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"[ERROR] Exception during login: {ex.Message}");
                    if (ex.InnerException != null)
                    {
                        Debug.WriteLine($"[ERROR] Inner exception: {ex.InnerException.Message}");
                    }
                    return Results.Problem($"Error durante el login: {ex.Message}");
                }
            })
            .WithName("Login")
            .Produces<LoginResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status401Unauthorized)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .AllowAnonymous(); // Este endpoint NO requiere autenticación
        }
    }
}
