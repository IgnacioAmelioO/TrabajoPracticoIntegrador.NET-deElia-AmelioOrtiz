using Domain.Services;
using DTOs;
using Microsoft.EntityFrameworkCore;

namespace TrabajoPracticoIntegrador
{
    public static class PlanEndpoints
    {
        public static void MapPlanEndpoints(this WebApplication app) {
            app.MapGet("/planes/{id_plan}", (int id_plan) =>
            {
                PlanService planService = new PlanService();

                PlanDTO dto = planService.Get(id_plan);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            })
            .WithName("GetPlan")
            .Produces<PlanDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

            app.MapGet("/planes", () =>
            {
                PlanService planService = new PlanService();

                var dtos = planService.GetAll();

                return Results.Ok(dtos);
            })
            .WithName("GetAllPlanes")
            .Produces<List<PlanDTO>>(StatusCodes.Status200OK);

            app.MapPost("/planes", (PlanDTO dto) =>
            {
                try
                {
                    PlanService planService = new PlanService();

                    PlanDTO planDto = planService.Add(dto);

                    return Results.Created($"/planes/{planDto.Id_plan}", planDto);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddPlan")
            .Produces<PlanDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);

            app.MapPut("/planes", (PlanDTO dto) =>
            {
                try
                {
                    var planService = new PlanService();

                    var found = planService.Update(dto);

                    if (!found)
                        return Results.NotFound();

                    return Results.NoContent();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("UpdatePlan")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest);

            app.MapDelete("/planes/{id_plan}", (int id_plan) =>
            {
                try
                {
                    var planService = new PlanService();
                    var deleted = planService.Delete(id_plan);

                    if (!deleted)
                        return Results.NotFound();

                    return Results.NoContent();
                }
                catch (DbUpdateException ex) when (ex.InnerException?.Message.Contains("REFERENCE constraint") ?? false)
                {
                    return Results.BadRequest(new
                    {
                        error = "No se puede eliminar este plan porque está siendo utilizado por otros registros."
                    });
                }
            })
            .WithName("DeletePlan")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest);

            app.MapGet("/planes/criteria", (string texto) =>
            {
                try
                {
                    var planService = new PlanService();
                    var criteriaDTO = new PlanCriteriaDTO { Texto = texto };
                    var planes = planService.GetByCriteria(criteriaDTO);

                    return Results.Ok(planes);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("GetPlanesByCriteria")
            .Produces<List<PlanDTO>>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest);
        }
    }
}
