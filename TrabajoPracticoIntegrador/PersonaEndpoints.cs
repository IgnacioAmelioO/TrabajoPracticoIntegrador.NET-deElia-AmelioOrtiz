using Domain.Services;
using DTOs;

namespace TrabajoPracticoIntegrador
{
    public static class PersonaEndpoints
    {
        public static void MapPersonaEndpoints(this WebApplication app)
        {
            app.MapGet("/personas/{id}", (int id) =>
            {
                PersonaService personaService = new PersonaService();

                PersonaDTO dto = personaService.Get(id);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            })
            .WithName("GetPersona")
            .Produces<PersonaDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

            app.MapGet("/personas", () =>
            {
                PersonaService personaService = new PersonaService();

                var personas = personaService.GetAll();

                return Results.Ok(personas);
            })
            .WithName("GetAllPersonas")
            .Produces<List<PersonaDTO>>(StatusCodes.Status200OK);

            app.MapPost("/personas", (PersonaDTO dto) =>
            {
                try
                {
                    var personaService = new PersonaService();

                    PersonaDTO personaDto = personaService.Add(dto);

                    return Results.Created($"/personas/{personaDto.Id_persona}", personaDto);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddPersona")
            .Produces<PersonaDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);

            app.MapPut("/personas", (PersonaDTO dto) =>
            {
                try
                {
                    var personaService = new PersonaService();

                    var found = personaService.Update(dto);

                    if (!found)
                        return Results.NotFound();

                    return Results.NoContent();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("UpdatePersona")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest);

            app.MapDelete("/personas/{id_persona}", (int id_persona) =>
            {
                var personaService = new PersonaService();

                var deleted = personaService.Delete(id_persona);

                if (!deleted)
                    return Results.NotFound();

                return Results.NoContent();
            })
            .WithName("DeletePersona")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound);

            app.MapGet("/personas/criteria", (string texto) =>
            {
                try
                {
                    var personaService = new PersonaService();
                    var criteriaDTO = new PersonaCriteriaDTO { Texto = texto };
                    var personas = personaService.GetByCriteria(criteriaDTO);

                    return Results.Ok(personas);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("GetPersonasByCriteria")
            .Produces<List<PersonaDTO>>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest);
        }
    }
}
