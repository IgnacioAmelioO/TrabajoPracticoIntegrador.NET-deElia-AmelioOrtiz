using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Api.Clients
{
    public class ReporteApiClient : BaseApiClient
    {
        public static async Task<string> GenerarReportePromedioCursoAsync(int idCurso)
        {
            try
            {
                await EnsureAuthenticatedAsync();
                using var httpClient = await CreateHttpClientAsync();

                // Llamada a la API para generar el reporte
                HttpResponseMessage response = await httpClient.GetAsync($"reports/promedioCurso/{idCurso}");

                if (response.IsSuccessStatusCode)
                {
                    // Recibir el PDF como un array de bytes
                    byte[] pdfBytes = await response.Content.ReadAsByteArrayAsync();

                    // Guardar el archivo localmente con un nombre único
                    string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                    string fileName = $"ReporteCurso_{idCurso}_{timestamp}.pdf";
                    string filePath = Path.Combine(Path.GetTempPath(), fileName); // Usar carpeta temporal del sistema

                    // Escribir el archivo utilizando un bloque using para asegurar que se liberen recursos
                    using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        await fileStream.WriteAsync(pdfBytes, 0, pdfBytes.Length);
                    }
                    
                    return filePath;
                }
                else
                {
                    // Manejar errores específicos según el código de estado
                    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        throw new Exception("No se encontró el curso especificado.");
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        string errorContent = await response.Content.ReadAsStringAsync();
                        throw new Exception($"Error al generar el reporte: {errorContent}");
                    }
                    else
                    {
                        await HandleUnauthorizedResponseAsync(response);
                        string errorContent = await response.Content.ReadAsStringAsync();
                        throw new Exception($"Error del servidor al generar reporte. Status: {response.StatusCode}, Detalle: {errorContent}");
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al generar reporte: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al generar reporte: {ex.Message}", ex);
            }
            catch (UnauthorizedAccessException)
            {
                throw; // Reenviar excepciones de autenticación para manejo en la UI
            }
            catch (Exception ex) when (!(ex is UnauthorizedAccessException))
            {
                throw new Exception($"Error al generar reporte: {ex.Message}", ex);
            }
        }
    }
}