using Domain.Model;
using Domain.Services;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpLogging(o => { });

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




app.MapGet("/personas/{id_persona}", (int id_persona) =>
{
    PersonaService personaService = new PersonaService();

    Persona persona = personaService.Get(id_persona);

    if (persona == null)
    {
        return Results.NotFound();
    }

    var dto = new DTOs.Persona
    {
        Id_persona = persona.Id_persona,
        Legajo = persona.Legajo,
        Nombre = persona.Nombre,
        Apellido = persona.Apellido,
        Email = persona.Email,
        Direccion = persona.Direccion,
        Telefono = persona.Telefono,
        Tipo_persona = persona.Tipo_persona,
        Fecha_nac = persona.Fecha_nac,
        Id_plan = persona.Id_plan,
    };

    return Results.Ok(dto);
})
.WithName("GetPersona")
.Produces<DTOs.Persona>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound);

app.MapGet("/personas", () =>
{
    PersonaService personaService = new PersonaService();

    var personas = personaService.GetAll();

    var dtos = personas.Select(persona => new DTOs.Persona
    {
        Id_persona = persona.Id_persona,
        Nombre = persona.Nombre,
        Apellido = persona.Apellido,
        Email = persona.Email,
        Fecha_nac = persona.Fecha_nac,
        Direccion = persona.Direccion,
        Telefono = persona.Telefono,
        Legajo = persona.Legajo,
        Tipo_persona = persona.Tipo_persona,
        Id_plan = persona.Id_plan
    }).ToList();


    return Results.Ok(dtos);
})
.WithName("GetAllPersonas")
.Produces<List<DTOs.Persona>>(StatusCodes.Status200OK);

app.MapPost("/personas", (DTOs.Persona dto) =>
{
    try
    {
        var personaService = new PersonaService();

        var persona = new Persona(
            dto.Id_persona,
            dto.Nombre,
            dto.Apellido,
            dto.Direccion,
            dto.Email,
            dto.Telefono,
            dto.Fecha_nac,
            dto.Legajo,
            dto.Tipo_persona,
            dto.Id_plan
        );

        personaService.Add(persona);

        var dtoResultado = new DTOs.Persona
        {
            Id_persona = persona.Id_persona,
            Legajo = persona.Legajo,
            Nombre = persona.Nombre,
            Apellido = persona.Apellido,
            Email = persona.Email,
            Direccion = persona.Direccion,
            Telefono = persona.Telefono,
            Tipo_persona = persona.Tipo_persona,
            Fecha_nac = persona.Fecha_nac,
            Id_plan = persona.Id_plan,
        };

        return Results.Created($"/personas/{dtoResultado.Id_persona}", dtoResultado);
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }
})
.WithName("AddPersona")
.Produces<DTOs.Persona>(StatusCodes.Status201Created)
.Produces(StatusCodes.Status400BadRequest);


app.MapPut("/personas", (DTOs.Persona dto) =>
{
    try
    {
        var personaService = new PersonaService();

        var persona = new Persona(
            dto.Id_persona,
            dto.Nombre,
            dto.Apellido,
            dto.Direccion,
            dto.Email,
            dto.Telefono,
            dto.Fecha_nac,
            dto.Legajo,
            dto.Tipo_persona,
            dto.Id_plan
        );

        var found = personaService.Update(persona);

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

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
app.MapGet("/planes/{id_plan}", (int id_plan) =>
{
    PlanService planService = new PlanService();

    Plan plan = planService.Get(id_plan);

    if (plan == null)
    {
        return Results.NotFound();
    }

    var dto = new DTOs.Plan
    {

        Id_plan = plan.Id_plan,
        Desc_plan = plan.Desc_plan,
        Id_especialidad = plan.Id_especialidad,
    };

    return Results.Ok(dto);
})
.WithName("GetPlan")
.Produces<DTOs.Plan>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound);

app.MapGet("/planes", () =>
{
    PlanService planService = new PlanService();

    var planes = planService.GetAll();

    var dtos = planes.Select(plan => new DTOs.Plan
    {
        Id_plan = plan.Id_plan,
        Desc_plan = plan.Desc_plan,
        Id_especialidad = plan.Id_especialidad,
    }).ToList();


    return Results.Ok(dtos);
})
.WithName("GetAllPlanes")
.Produces<List<DTOs.Plan>>(StatusCodes.Status200OK);

app.MapPost("/planes", (DTOs.Plan dto) =>
{
    try
    {
        var planService = new PlanService();

        var plan = new Plan(
            dto.Id_plan,
            dto.Desc_plan,
            dto.Id_especialidad

        );

        planService.Add(plan);

        var dtoResultado = new DTOs.Plan
        {
            Id_plan = plan.Id_plan,
            Desc_plan = plan.Desc_plan,
            Id_especialidad = plan.Id_especialidad,
        };

        return Results.Created($"/planes/{dtoResultado.Id_plan}", dtoResultado);
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }
})
.WithName("AddPlan")
.Produces<DTOs.Plan>(StatusCodes.Status201Created)
.Produces(StatusCodes.Status400BadRequest);


app.MapPut("/planes", (DTOs.Plan dto) =>
{
    try
    {
        var planService = new PlanService();

        var plan = new Plan(
            dto.Id_plan,
            dto.Desc_plan,
            dto.Id_especialidad
        );

        var found = planService.Update(plan);

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


///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
app.MapGet("/especialidades/{id_esp}", (int id_esp) =>
{
    EspecialidadService especialidadService = new EspecialidadService();

    Especialidad especialidad = especialidadService.Get(id_esp);

    if (especialidad == null)
    {
        return Results.NotFound();
    }

    var dto = new DTOs.Especialidad
    {

        Id_especialidad = especialidad.Id_especialidad,
        Desc_esp = especialidad.Desc_esp,
    };

    return Results.Ok(dto);
})
.WithName("GetEspecialidad")
.Produces<DTOs.Plan>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound);

app.MapGet("/especialidades", () =>
{
    EspecialidadService especialidadService = new EspecialidadService();

    var especialidades = especialidadService.GetAll();

    var dtos = especialidades.Select(especialidad => new DTOs.Especialidad
    {
        Id_especialidad = especialidad.Id_especialidad,
        Desc_esp = especialidad.Desc_esp,

    }).ToList();


    return Results.Ok(dtos);
})
.WithName("GetAllEspecialidades")
.Produces<List<DTOs.Especialidad>>(StatusCodes.Status200OK);

app.MapPost("/especialidades", (DTOs.Especialidad dto) =>
{
    try
    {
        var especialidadService = new EspecialidadService();

        var especialidad = new Especialidad(
            dto.Id_especialidad,
            dto.Desc_esp

        );

        especialidadService.Add(especialidad);

        var dtoResultado = new DTOs.Especialidad
        {
            Id_especialidad = especialidad.Id_especialidad,
            Desc_esp = especialidad.Desc_esp,

        };

        return Results.Created($"/especialidades/{dtoResultado.Id_especialidad}", dtoResultado);
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }
})
.WithName("AddEspecialidad")
.Produces<DTOs.Especialidad>(StatusCodes.Status201Created)
.Produces(StatusCodes.Status400BadRequest);


app.MapPut("/especialidades", (DTOs.Especialidad dto) =>
{
    try
    {
        var especialidadService = new EspecialidadService();

        var especialidad = new Especialidad(
             dto.Id_especialidad,
            dto.Desc_esp
        );

        var found = especialidadService.Update(especialidad);

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



app.Run();
