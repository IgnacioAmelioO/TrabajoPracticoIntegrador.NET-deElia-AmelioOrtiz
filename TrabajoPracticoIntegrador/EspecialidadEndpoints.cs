using Domain.Services;
using DTOs;

namespace TrabajoPracticoIntegrador
{
    public static class EspecialidadEndpoints
    {
        public static void MapEspecialidadEndpoints(this WebApplication app) {
            app.MapGet("/especialidades/{id_esp}", (int id_esp) =>
            {
                EspecialidadService especialidadService = new EspecialidadService();

                EspecialidadDTO dto = especialidadService.Get(id_esp);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            })
            .WithName("GetEspecialidad")
            .Produces<EspecialidadDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

            app.MapGet("/especialidades", () =>
            {
                EspecialidadService especialidadService = new EspecialidadService();

                var especialidades = especialidadService.GetAll();

                return Results.Ok(especialidades);
            })
            .WithName("GetAllEspecialidades")
            .Produces<List<EspecialidadDTO>>(StatusCodes.Status200OK);

            app.MapPost("/especialidades", (EspecialidadDTO dto) =>
            {
                try
                {
                    var especialidadService = new EspecialidadService();

                    EspecialidadDTO especialidadDto = especialidadService.Add(dto);

                    return Results.Created($"/especialidades/{especialidadDto.Id_especialidad}", especialidadDto);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddEspecialidad")
            .Produces<EspecialidadDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);

            app.MapPut("/especialidades", (EspecialidadDTO dto) =>
            {
                try
                {
                    var especialidadService = new EspecialidadService();

                    var found = especialidadService.Update(dto);

                    if (!found)
                        return Results.NotFound();

                    return Results.NoContent();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("UpdateEspecialidad")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest);

            app.MapDelete("/especialidades/{id_especialidad}", (int id_especialidad) =>
            {
                var especialidadService = new EspecialidadService();

                var deleted = especialidadService.Delete(id_especialidad);

                if (!deleted)
                    return Results.NotFound();

                return Results.NoContent();
            })
            .WithName("DeleteEspecialidad")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound);

            app.MapGet("/especialidades/criteria", (string texto) =>
            {
                try
                {
                    var especialidadService = new EspecialidadService();
                    var criteriaDTO = new EspecialidadCriteriaDTO { Texto = texto };
                    var especialidades = especialidadService.GetByCriteria(criteriaDTO);

                    return Results.Ok(especialidades);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("GetEspecialidadesByCriteria")
            .Produces<List<EspecialidadDTO>>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest);
        }
    }
}
