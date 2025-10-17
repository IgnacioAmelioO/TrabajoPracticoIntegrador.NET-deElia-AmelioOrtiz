using DTOs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Clients
{
    public class AuthApiClient : BaseApiClient
    {
        public async Task<LoginResponse?> LoginAsync(LoginRequest request)
        {
            try
            {
                using var httpClient = await CreateHttpClientAsync();

                var json = JsonSerializer.Serialize(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Add timeout to prevent long waits
                httpClient.Timeout = TimeSpan.FromSeconds(10);

                Debug.WriteLine($"[DEBUG] Sending login request for user: {request.Username}");
                Debug.WriteLine($"[DEBUG] API URL: {httpClient.BaseAddress}auth/login");

                var response = await httpClient.PostAsync("/auth/login", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine($"[DEBUG] Login successful, response length: {responseContent.Length}");
                    
                    // Log response content (sanitized for security)
                    if (!string.IsNullOrEmpty(responseContent))
                    {
                        var sanitized = responseContent.Length > 100 
                            ? responseContent.Substring(0, 20) + "..." + responseContent.Substring(responseContent.Length - 20)
                            : responseContent;
                        Debug.WriteLine($"[DEBUG] Response preview: {sanitized}");
                    }
                    else
                    {
                        Debug.WriteLine("[WARN] Received empty response content");
                    }

                    try
                    {
                        var options = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        };
                        
                        var result = JsonSerializer.Deserialize<LoginResponse>(responseContent, options);
                        
                        if (result == null)
                        {
                            Debug.WriteLine("[ERROR] Deserialized result is null");
                            throw new InvalidOperationException("La respuesta del servidor no se pudo interpretar correctamente");
                        }
                        
                        // Validate token
                        if (string.IsNullOrEmpty(result.Token))
                        {
                            Debug.WriteLine("[ERROR] Token is empty in response");
                            throw new InvalidOperationException("El servidor no devolvió un token válido");
                        }
                        
                        Debug.WriteLine($"[DEBUG] Token received, length: {result.Token.Length}");
                        Debug.WriteLine($"[DEBUG] Token expiration: {result.ExpiresAt}");
                        return result;
                    }
                    catch (JsonException ex)
                    {
                        Debug.WriteLine($"[ERROR] JSON deserialization error: {ex.Message}");
                        Debug.WriteLine($"[ERROR] Response content: {responseContent}");
                        throw new InvalidOperationException("Error al procesar la respuesta del servidor. Formato de respuesta inválido.", ex);
                    }
                }
                else
                {
                    // Get more details about the error
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine($"[ERROR] API responded with status: {response.StatusCode}, Content: {errorContent}");
                    
                    // Handle specific status codes
                    if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        Debug.WriteLine("[ERROR] Authentication failed: Unauthorized");
                        return null; // Credentials incorrect
                    }
                    
                    // For other status codes, throw an exception with details
                    throw new HttpRequestException($"Error del servidor: {response.StatusCode} - {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                // This catches connection issues
                Debug.WriteLine($"[ERROR] Connection error: {ex.Message}");
                throw new Exception($"No se pudo conectar al servidor: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                // This catches timeouts
                Debug.WriteLine($"[ERROR] Request timed out: {ex.Message}");
                throw new Exception("La solicitud al servidor ha tomado demasiado tiempo. Verifique que el servidor esté en ejecución.", ex);
            }
            catch (Exception ex)
            {
                // Any other exception
                Debug.WriteLine($"[ERROR] Unexpected error: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Debug.WriteLine($"[ERROR] Inner exception: {ex.InnerException.Message}");
                }
                throw new Exception($"Error al comunicarse con el servidor: {ex.Message}", ex);
            }
        }
    }
}
