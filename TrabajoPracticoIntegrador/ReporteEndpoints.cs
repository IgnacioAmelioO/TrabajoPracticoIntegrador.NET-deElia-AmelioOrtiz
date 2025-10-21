using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Text;
using Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.EntityFrameworkCore;

namespace TrabajoPracticoIntegrador
{
    public static class ReporteEndpoints
    {
        public static void MapReporteEndpoints(this WebApplication app)
        {
            app.MapGet("/reports/promedioCurso/{idCurso}", async (int idCurso) =>
            {
                string rutaArchivo = null;
                try
                {
                    // Crear una instancia del contexto de base de datos
                    var context = new TPIContext();

                    // Crear una instancia del servicio de reportes
                    var reportService = new ReportService(context);

                    // Generar el reporte
                    rutaArchivo = await reportService.GenerarReportePromedioCurso(idCurso);

                    // Leer el archivo generado
                    if (!File.Exists(rutaArchivo))
                    {
                        return Results.NotFound("El archivo del reporte no se generó correctamente.");
                    }

                    // Leer los bytes del archivo PDF usando FileStream para control explícito
                    byte[] fileBytes;
                    using (var fileStream = new FileStream(rutaArchivo, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        fileBytes = new byte[fileStream.Length];
                        await fileStream.ReadAsync(fileBytes, 0, fileBytes.Length);
                    }

                    // Devolver el PDF como un archivo para descargar
                    return Results.File(
                        fileBytes,
                        "application/pdf",
                        $"ReportePromedioCurso_{idCurso}.pdf");
                }
                catch (Exception ex) when (ex.Message.Contains("No se encontró el curso"))
                {
                    return Results.NotFound(ex.Message);
                }
                catch (Exception ex) when (ex.Message.Contains("No hay notas cargadas"))
                {
                    return Results.BadRequest(ex.Message);
                }
                catch (Exception ex)
                {
                    return Results.Problem($"Error al generar el reporte: {ex.Message}");
                }
                finally
                {
                    // Intentar eliminar el archivo temporal después de un breve retraso
                    if (rutaArchivo != null && File.Exists(rutaArchivo))
                    {
                        try
                        {
                            // Esperar un poco para asegurar que otros procesos hayan terminado de usar el archivo
                            await Task.Delay(500);
                            File.Delete(rutaArchivo);
                        }
                        catch
                        {
                            // Ignorar errores de eliminación
                        }
                    }
                }
            })
            .WithName("GenerarReportePromedioCurso")
            .Produces<FileContentResult>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status500InternalServerError);
        }
    }
}
