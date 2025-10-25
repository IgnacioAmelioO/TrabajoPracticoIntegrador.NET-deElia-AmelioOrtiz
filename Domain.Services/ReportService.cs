using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.EntityFrameworkCore;
using Data;
using Domain.Model;

namespace Services
{
    public class ReportService
    {
        private readonly TPIContext _context;

        public ReportService(TPIContext context)
        {
            _context = context;
        }

        public async Task<string> GenerarReportePromedioCurso(int idCurso)
        {

            var curso = await _context.Cursos
                .FirstOrDefaultAsync(c => c.Id_curso == idCurso);

            if (curso == null)
                throw new Exception("No se encontró el curso especificado.");

            var inscripciones = await _context.AlumnosInscripciones
                .Where(ai => ai.Id_curso == idCurso && ai.Nota != null)
                .ToListAsync();

            if (inscripciones.Count == 0)
                throw new Exception("No hay notas cargadas para este curso.");

           
            double promedio = inscripciones.Average(ai => ai.Nota!.Value);

            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");

            string projectDirectory = GetProjectDirectory();
            
            string reportsDir = Path.Combine(projectDirectory, "TempReports");
            if (!Directory.Exists(reportsDir))
            {
                Directory.CreateDirectory(reportsDir);
            }
            
            string rutaArchivo = Path.Combine(reportsDir, $"ReporteCurso_{idCurso}_{timestamp}.pdf");

            Document doc = new Document(PageSize.A4);

            using (var fileStream = new FileStream(rutaArchivo, FileMode.Create))
            {
                PdfWriter.GetInstance(doc, fileStream);
                doc.Open();

                var fontHeading = FontFactory.GetFont(FontFactory.HELVETICA, 18, Font.BOLD);
                var titulo = new Paragraph($"Reporte de Promedio - Curso {idCurso}\n\n", fontHeading);
                titulo.Alignment = Element.ALIGN_CENTER;
                doc.Add(titulo);

                doc.Add(new Paragraph($"Fecha: {DateTime.Now.ToShortDateString()}\n\n"));
                doc.Add(new Paragraph($"Cantidad de alumnos con nota: {inscripciones.Count}\n"));
                doc.Add(new Paragraph($"Promedio general: {promedio:F2}\n\n"));

                PdfPTable tabla = new PdfPTable(3);
                tabla.WidthPercentage = 100;
                tabla.AddCell("Legajo");
                tabla.AddCell("Alumno");
                tabla.AddCell("Nota");

                foreach (var insc in inscripciones)
                {
                    var alumno = await _context.Personas.FindAsync(insc.Id_alumno);
                    tabla.AddCell(alumno?.Legajo ?? "");
                    tabla.AddCell($"{alumno?.Apellido}, {alumno?.Nombre}");
                    tabla.AddCell(insc.Nota?.ToString() ?? "");
                }

                doc.Add(tabla);
                doc.Close();
            } 

            return rutaArchivo;
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
