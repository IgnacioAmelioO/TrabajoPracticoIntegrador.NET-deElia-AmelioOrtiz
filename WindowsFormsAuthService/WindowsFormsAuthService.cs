using Api.Clients;
using DTOs;
using System.Diagnostics;

namespace Api.Auth.WindowsForms
{
    public class WindowsFormsAuthService : IAuthService
    {
        private static string? _currentToken;
        private static DateTime _tokenExpiration;
        private static string? _currentUsername;

        public event Action<bool>? AuthenticationStateChanged;

        public async Task<bool> IsAuthenticatedAsync()
        {
            return !string.IsNullOrEmpty(_currentToken) && DateTime.UtcNow < _tokenExpiration;
        }

        public async Task<string?> GetTokenAsync()
        {
            var isAuth = await IsAuthenticatedAsync();
            return isAuth ? _currentToken : null;
        }

        public async Task<string?> GetUsernameAsync()
        {
            var isAuth = await IsAuthenticatedAsync();
            return isAuth ? _currentUsername : null;
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            try
            {
                Debug.WriteLine($"[DEBUG] Login attempt for user: {username}");
                
                var request = new LoginRequest
                {
                    Username = username,
                    Password = password
                };

                var authClient = new AuthApiClient();
                var response = await authClient.LoginAsync(request);

                if (response != null && !string.IsNullOrEmpty(response.Token))
                {
                    Debug.WriteLine($"[DEBUG] Login successful for user: {username}");
                    Debug.WriteLine($"[DEBUG] Token received, length: {response.Token.Length}");
                    Debug.WriteLine($"[DEBUG] Token expiration: {response.ExpiresAt}");
                    
                    // Validate token format (simple check)
                    if (!response.Token.Contains("."))
                    {
                        Debug.WriteLine("[ERROR] Invalid token format");
                        throw new InvalidOperationException("El token recibido no tiene un formato JWT válido");
                    }
                    
                    if (response.ExpiresAt <= DateTime.UtcNow)
                    {
                        Debug.WriteLine("[ERROR] Token already expired");
                        throw new InvalidOperationException("El token recibido ya ha expirado");
                    }

                    _currentToken = response.Token;
                    _tokenExpiration = response.ExpiresAt;
                    _currentUsername = response.Username;

                    AuthenticationStateChanged?.Invoke(true);
                    return true;
                }
                
                Debug.WriteLine("[ERROR] Login failed: null response or empty token");
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR] Login exception: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Debug.WriteLine($"[ERROR] Inner exception: {ex.InnerException.Message}");
                }
                
                // Re-throw the exception to be handled by the UI layer
                throw;
            }
        }

        public async Task LogoutAsync()
        {
            Debug.WriteLine("[DEBUG] Logging out user");
            _currentToken = null;
            _tokenExpiration = default;
            _currentUsername = null;

            AuthenticationStateChanged?.Invoke(false);
        }

        public async Task CheckTokenExpirationAsync()
        {
            if (!string.IsNullOrEmpty(_currentToken) && DateTime.UtcNow >= _tokenExpiration)
            {
                Debug.WriteLine("[DEBUG] Token expired, logging out");
                await LogoutAsync();
            }
        }
    }
}
