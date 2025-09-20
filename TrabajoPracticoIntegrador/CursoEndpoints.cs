using Domain.Services;
using DTOs;

namespace TrabajoPracticoIntegrador
{
    public static class CursoEndpoints
    {
        public static void MapCursoEndpoints(this WebApplication app)
        {
            app.MapGet("/cursos/{id_curso}", (int id_curso) =>
            {
                CursoService cursoService = new CursoService();
                CursoDTO dto = cursoService.Get(id_curso);
                if (dto == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(dto);
            })
            .WithName("GetCurso")
            .Produces<CursoDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

            app.MapGet("/cursos", () =>
            {
                CursoService cursoService = new CursoService();
                var cursos = cursoService.GetAll();
                return Results.Ok(cursos);
            })
            .WithName("GetAllCursos")
            .Produces<List<CursoDTO>>(StatusCodes.Status200OK);

            app.MapPost("/cursos", (CursoDTO dto) =>
            {
                try
                {
                    var cursoService = new CursoService();
                    CursoDTO cursoDto = cursoService.Add(dto);
                    return Results.Created($"/cursos/{cursoDto.Id_curso}", cursoDto);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddCurso")
            .Produces<CursoDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);

            app.MapPut("/cursos", (CursoDTO dto) =>
            {
                try
                {
                    var cursoService = new CursoService();
                    bool updated = cursoService.Update(dto);
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
            .WithName("UpdateCurso")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound);

            app.MapDelete("/cursos/{id_curso}", (int id_curso) =>
            {
                var cursoService = new CursoService();
                bool deleted = cursoService.Delete(id_curso);
                if (!deleted)
                {
                    return Results.NotFound();
                }
                return Results.NoContent();
            })
            .WithName("DeleteCurso")
            .Produces(StatusCodes.Status204NoContent);
        }
    }
}

