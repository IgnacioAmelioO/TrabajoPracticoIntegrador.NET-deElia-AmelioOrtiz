using Domain.Services;
using DTOs;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace TrabajoPracticoIntegrador
{
    public static class AlumnoInscripcionEndpoints
    {
        public static void MapAlumnoInscripcionEndpoints(this WebApplication app)
        {
            app.MapGet("/alumnoinscripciones/{id_inscripcion}", (int id_inscripcion) =>
            {
                var service = new AlumnoInscripcionService();
                var dto = service.Get(id_inscripcion);
                if (dto == null) return Results.NotFound();
                return Results.Ok(dto);
            })
            .WithName("GetAlumnoInscripcion")
            .Produces<AlumnoInscripcionDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

            // Endpoint para obtener inscripciones por Id_alumno usando el servicio dedicado
            app.MapGet("/alumnoinscripciones/alumno/{id_alumno}", (int id_alumno) =>
            {
                var service = new AlumnoInscripcionService();
                var list = service.GetByAlumno(id_alumno);

                if (list == null || !list.Any()) return Results.NotFound();
                return Results.Ok(list);
            })
            .WithName("GetAlumnoInscripcionesByAlumno")
            .Produces<List<AlumnoInscripcionDTO>>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

            app.MapGet("/alumnoinscripciones", () =>
            {
                var service = new AlumnoInscripcionService();
                var list = service.GetAll();
                return Results.Ok(list);
            })
            .WithName("GetAllAlumnoInscripciones")
            .Produces<List<AlumnoInscripcionDTO>>(StatusCodes.Status200OK);

            app.MapPost("/alumnoinscripciones", (AlumnoInscripcionDTO dto) =>
            {
                try
                {
                    var service = new AlumnoInscripcionService();
                    var created = service.Add(dto);
                    return Results.Created($"/alumnoinscripciones/{created.Id_inscripcion}", created);
                }
                catch (KeyNotFoundException ex)
                {
                    // curso no encontrado -> 404
                    return Results.NotFound(new { error = ex.Message });
                }
                catch (InvalidOperationException ex)
                {
                    // sin cupo -> 409 Conflict (o 400 si prefieres)
                    return Results.Conflict(new { error = ex.Message });
                }
                catch (ArgumentException ex)
                {
                    // violaciones de negocio -> 400
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddAlumnoInscripcion")
            .Produces<AlumnoInscripcionDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status409Conflict);

            app.MapPut("/alumnoinscripciones", (AlumnoInscripcionDTO dto) =>
            {
                try
                {
                    var service = new AlumnoInscripcionService();
                    var updated = service.Update(dto);
                    if (!updated) return Results.NotFound();
                    return Results.NoContent();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("UpdateAlumnoInscripcion")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound);

            app.MapDelete("/alumnoinscripciones/{id_inscripcion}", (int id_inscripcion) =>
            {
                var service = new AlumnoInscripcionService();
                var deleted = service.Delete(id_inscripcion);
                if (!deleted) return Results.NotFound();
                return Results.NoContent();
            })
            .WithName("DeleteAlumnoInscripcion")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound);
        }
    }
}