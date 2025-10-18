using Domain.Services;
using DTOs;

namespace TrabajoPracticoIntegrador
{
    public static class DocenteCursoEndpoints
    {
        public static void MapDocenteCursoEndpoints(this WebApplication app)
        {
            app.MapGet("/docentecursos/{id_dictado}", (int id_dictado) =>
            {
                DocenteCursoService docenteCursoService = new DocenteCursoService();
                DocenteCursoDTO dto = docenteCursoService.Get(id_dictado);
                if (dto == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(dto);
            })
            .WithName("GetDocenteCurso")
            .Produces<DocenteCursoDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

            app.MapGet("/docentecursos", () =>
            {
                DocenteCursoService docenteCursoService = new DocenteCursoService();
                var docentesCursos = docenteCursoService.GetAll();
                return Results.Ok(docentesCursos);
            })
            .WithName("GetAllDocentesCursos")
            .Produces<List<DocenteCursoDTO>>(StatusCodes.Status200OK);

            app.MapGet("/docentecursos/docente/{id_docente}", (int id_docente) =>
            {
                DocenteCursoService docenteCursoService = new DocenteCursoService();
                var docentesCursos = docenteCursoService.GetByDocente(id_docente);
                return Results.Ok(docentesCursos);
            })
            .WithName("GetDocenteCursosByDocente")
            .Produces<List<DocenteCursoDTO>>(StatusCodes.Status200OK);

            app.MapGet("/docentecursos/curso/{id_curso}", (int id_curso) =>
            {
                DocenteCursoService docenteCursoService = new DocenteCursoService();
                var docentesCursos = docenteCursoService.GetByCurso(id_curso);
                return Results.Ok(docentesCursos);
            })
            .WithName("GetDocenteCursosByCurso")
            .Produces<List<DocenteCursoDTO>>(StatusCodes.Status200OK);

            app.MapPost("/docentecursos", (DocenteCursoDTO dto) =>
            {
                try
                {
                    var docenteCursoService = new DocenteCursoService();
                    DocenteCursoDTO docenteCursoDto = docenteCursoService.Add(dto);
                    return Results.Created($"/docentecursos/{docenteCursoDto.Id_dictado}", docenteCursoDto);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddDocenteCurso")
            .Produces<DocenteCursoDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);

            app.MapPut("/docentecursos", (DocenteCursoDTO dto) =>
            {
                try
                {
                    var docenteCursoService = new DocenteCursoService();
                    bool updated = docenteCursoService.Update(dto);
                    if (!updated)
                    {
                        return Results.NotFound();
                    }
                    return Results.NoContent();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("UpdateDocenteCurso")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound);

            app.MapDelete("/docentecursos/{id_dictado}", (int id_dictado) =>
            {
                var docenteCursoService = new DocenteCursoService();
                bool deleted = docenteCursoService.Delete(id_dictado);
                if (!deleted)
                {
                    return Results.NotFound();
                }
                return Results.NoContent();
            })
            .WithName("DeleteDocenteCurso")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound);
        }
    }
}
