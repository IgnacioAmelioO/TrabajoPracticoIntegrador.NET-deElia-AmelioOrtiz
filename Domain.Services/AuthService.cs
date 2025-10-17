using DTOs;
using Data;
using Domain.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Domain.Services
{
    public class AuthService
    {
        private readonly UsuarioRepository usuarioRepository;
        private readonly IConfiguration configuration;

        public AuthService(IConfiguration configuration)
        {
            usuarioRepository = new UsuarioRepository();
            this.configuration = configuration;
        }

        public async Task<LoginResponse?> LoginAsync(LoginRequest request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
                    return null;

                var usuario = usuarioRepository.GetByUsername(request.Username);

                if (usuario == null || !usuario.ValidatePassword(request.Password))
                    return null;

                var token = GenerateJwtToken(usuario);
                var expiresAt = DateTime.UtcNow.AddMinutes(GetExpirationMinutes());

                return new LoginResponse
                {
                    Token = token,
                    ExpiresAt = expiresAt,
                    Username = usuario.Username
                };
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR] Login failed: {ex.Message}");
                // Re-throw to let calling code handle the exception
                throw;
            }
        }

        private string GenerateJwtToken(Usuario usuario)
        {
            try
            {
                var jwtSettings = configuration.GetSection("Jwt");
                
                var secretKey = jwtSettings["Key"];
                if (string.IsNullOrEmpty(secretKey))
                {
                    Debug.WriteLine("[ERROR] JWT Key is null or empty in configuration");
                    throw new InvalidOperationException("La clave JWT no está configurada correctamente");
                }

                var issuer = jwtSettings["Issuer"];
                var audience = jwtSettings["Audience"];

                Debug.WriteLine($"[DEBUG] JWT Key length: {secretKey.Length}");
                Debug.WriteLine($"[DEBUG] JWT Issuer: {issuer}");
                Debug.WriteLine($"[DEBUG] JWT Audience: {audience}");

                // Ensure the key meets minimum length requirements (at least 256 bits / 32 bytes)
                if (secretKey.Length < 32)
                {
                    Debug.WriteLine($"[ERROR] JWT Key is too short: {secretKey.Length} chars");
                    throw new InvalidOperationException("La clave JWT es demasiado corta, debe tener al menos 32 caracteres");
                }

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                    new Claim(ClaimTypes.Name, usuario.Username),
                    new Claim(ClaimTypes.Email, usuario.Email),
                    new Claim("jti", Guid.NewGuid().ToString())
                };

                var token = new JwtSecurityToken(
                    issuer: issuer,
                    audience: audience,
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(GetExpirationMinutes()),
                    signingCredentials: credentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                Debug.WriteLine($"[DEBUG] JWT Token generated successfully, length: {tokenString.Length}");
                return tokenString;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR] Failed to generate JWT token: {ex.Message}");
                throw new InvalidOperationException($"Error al generar el token JWT: {ex.Message}", ex);
            }
        }

        public bool ValidateToken(string token)
        {
            try
            {
                var jwtSettings = configuration.GetSection("Jwt");
                var secretKey = jwtSettings["Key"];
                var issuer = jwtSettings["Issuer"];
                var audience = jwtSettings["Audience"];

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!));

                var tokenHandler = new JwtSecurityTokenHandler();
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = audience,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ClockSkew = TimeSpan.Zero
                };

                tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR] Token validation failed: {ex.Message}");
                return false;
            }
        }

        public int? GetUserIdFromToken(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jsonToken = tokenHandler.ReadJwtToken(token);

                var userIdClaim = jsonToken.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
                if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
                {
                    return userId;
                }
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR] Failed to get user ID from token: {ex.Message}");
                return null;
            }
        }

        private int GetExpirationMinutes()
        {
            var jwtSettings = configuration.GetSection("Jwt");
            if (int.TryParse(jwtSettings["ExpirationMinutes"], out int minutes) && minutes > 0)
                return minutes;
            return 60; // Default 60 minutes
        }
    }
}