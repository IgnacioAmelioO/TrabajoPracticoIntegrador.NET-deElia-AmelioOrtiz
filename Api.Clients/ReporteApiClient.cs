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

                HttpResponseMessage response = await httpClient.GetAsync($"reports/promedioCurso/{idCurso}");

                if (response.IsSuccessStatusCode)
                {

                    byte[] pdfBytes = await response.Content.ReadAsByteArrayAsync();

                    string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                    string randomSuffix = Guid.NewGuid().ToString("N")[..8]; 
                    string fileName = $"ReporteCurso_{idCurso}_{timestamp}_{randomSuffix}.pdf";

                    string projectDirectory = GetProjectDirectory();
                    string reportsDirectory = Path.Combine(projectDirectory, "Reportes");
                    string filePath = Path.Combine(reportsDirectory, fileName);

                    if (!Directory.Exists(reportsDirectory))
                    {
                        Directory.CreateDirectory(reportsDirectory);
                    }

                    using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    {
                        await fileStream.WriteAsync(pdfBytes, 0, pdfBytes.Length);
                        await fileStream.FlushAsync();
                    }

                    return filePath;
                }
                else
                {
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
                throw; 
            }
            catch (Exception ex) when (!(ex is UnauthorizedAccessException))
            {
                throw new Exception($"Error al generar reporte: {ex.Message}", ex);
            }
        }

        private static string GetProjectDirectory()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string searchDir = currentDirectory;
            
            while (searchDir != null && !string.IsNullOrEmpty(searchDir))
            {
                if (Path.GetFileName(searchDir) == "TrabajoPracticoIntegrador.NET-deElia-AmelioOrtiz")
                {
                    return searchDir;
                }              
                DirectoryInfo parentDir = Directory.GetParent(searchDir);
                searchDir = parentDir?.FullName;
            }
            return currentDirectory;
        }
    }
}