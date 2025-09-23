using Domain.Services;
using DTOs;

namespace TrabajoPracticoIntegrador
{
    public static class MateriaEndpoints
    {
        public static void MapMateriaEndpoints(this WebApplication app)
        {
            app.MapGet("/materias/{id_materia}", (int id_materia) =>
            {
                MateriaService materiaService = new MateriaService();
                MateriaDTO dto = materiaService.Get(id_materia);
                if (dto == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(dto);
            })
            .WithName("GetMateria")
            .Produces<MateriaDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

            app.MapGet("/materias", () =>
            {
                MateriaService materiaService = new MateriaService();
                var materias = materiaService.GetAll();
                return Results.Ok(materias);
            })
            .WithName("GetAllMaterias")
            .Produces<List<MateriaDTO>>(StatusCodes.Status200OK);

            app.MapPost("/materias", (MateriaDTO dto) =>
            {
                try
                {
                    var materiaService = new MateriaService();
                    MateriaDTO materiaDto = materiaService.Add(dto);
                    return Results.Created($"/materias/{materiaDto.Id_materia}", materiaDto);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddMateria")
            .Produces<MateriaDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);

            app.MapPut("/materias", (MateriaDTO dto) =>
            {
                try
                {
                    var materiaService = new MateriaService();
                    bool updated = materiaService.Update(dto);
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
            .WithName("UpdateMateria")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound);

            app.MapDelete("/materias/{id_materia}", (int id_materia) =>
            {
                var materiaService = new MateriaService();
                bool deleted = materiaService.Delete(id_materia);
                if (!deleted)
                {
                    return Results.NotFound();
                }
                return Results.NoContent();
            })
            .WithName("DeleteMateria")
            .Produces(StatusCodes.Status204NoContent);
        }
    }
}