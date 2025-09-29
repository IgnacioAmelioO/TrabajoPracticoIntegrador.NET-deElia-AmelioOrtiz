using Domain.Services;
using DTOs;

namespace TrabajoPracticoIntegrador
{
    public static class ComisionEndpoints
    {
        public static void MapComisionEndpoints(this WebApplication app)
        {
            app.MapGet("/comisiones/{id_comision}", (int id_comision) =>
            {
                ComisionService comisionService = new ComisionService();
                ComisionDTO dto = comisionService.Get(id_comision);
                if (dto == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(dto);
            })
            .WithName("GetComision")
            .Produces<ComisionDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

            app.MapGet("/comisiones", () =>
            {
                ComisionService comisionService = new ComisionService();
                var comisiones = comisionService.GetAll();
                return Results.Ok(comisiones);
            })
            .WithName("GetAllComisiones")
            .Produces<List<ComisionDTO>>(StatusCodes.Status200OK);

            app.MapPost("/comisiones", (ComisionDTO dto) =>
            {
                try
                {
                    var comisionService = new ComisionService();
                    ComisionDTO comisionDto = comisionService.Add(dto);
                    return Results.Created($"/comisiones/{comisionDto.Id_comision}", comisionDto);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddComision")
            .Produces<ComisionDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);

            app.MapPut("/comisiones", (ComisionDTO dto) =>
            {
                try
                {
                    var comisionService = new ComisionService();
                    bool updated = comisionService.Update(dto);
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
            .WithName("UpdateComision")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound);

            app.MapDelete("/comisiones/{id_comision}", (int id_comision) =>
            {
                var comisionService = new ComisionService();
                bool deleted = comisionService.Delete(id_comision);
                if (!deleted)
                {
                    return Results.NotFound();
                }
                return Results.NoContent();
            })
            .WithName("DeleteComision")
            .Produces(StatusCodes.Status204NoContent);
        }
    }
}