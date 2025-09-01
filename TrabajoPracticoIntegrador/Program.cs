using Domain.Model;
using Domain.Services;
using DTOs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpLogging(o => { });

// Add CORS for Blazor WebAssembly
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorWasm",
        policy =>
        {
            policy.WithOrigins("https://localhost:7003", "http://localhost:5255")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //Falta configurar de manera correcta        
    app.UseHttpLogging();
}

app.UseHttpsRedirection();

// Use CORS
app.UseCors("AllowBlazorWasm");

// ================= PERSONAS CRUD =================
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

// ================= PLANES CRUD =================
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
    var planService = new PlanService();

    var deleted = planService.Delete(id_plan);

    if (!deleted)
        return Results.NotFound();

    return Results.NoContent();
})
.WithName("DeletePlan")
.Produces(StatusCodes.Status204NoContent)
.Produces(StatusCodes.Status404NotFound);

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

// ================= ESPECIALIDADES CRUD =================
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

app.Run();
