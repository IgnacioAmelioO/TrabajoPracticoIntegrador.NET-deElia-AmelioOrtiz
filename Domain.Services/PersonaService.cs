using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Domain.Model;
using DTOs;

namespace Domain.Services
{
    public class PersonaService
    {
        public PersonaDTO Add(PersonaDTO dto)
        {
            var personaRepository = new PersonaRepository();

            if (personaRepository.EmailExists(dto.Email))
            {
                throw new ArgumentException("Ya existe una persona con ese email.", nameof(dto.Email));
            }

            Persona persona = new Persona(0, dto.Nombre, dto.Apellido, dto.Direccion, dto.Email, 
                dto.Telefono, dto.Fecha_nac, dto.Legajo, dto.Tipo_persona, dto.Id_plan);

            personaRepository.Add(persona);

            dto.Id_persona = persona.Id_persona; 

            return dto;
        }

        public bool Delete(int id)
        {
            var personaRepository = new PersonaRepository();
            return personaRepository.Delete(id);
        }

        public PersonaDTO Get(int id)
        {
            var personaRepository = new PersonaRepository();
            Persona? persona = personaRepository.Get(id);
            if (persona == null)
                return null;

            return new PersonaDTO
            {
                Id_persona = persona.Id_persona,
                Nombre = persona.Nombre,
                Apellido = persona.Apellido,
                Direccion = persona.Direccion,
                Email = persona.Email,
                Telefono = persona.Telefono,
                Fecha_nac = persona.Fecha_nac,
                Legajo = persona.Legajo,
                Tipo_persona = persona.Tipo_persona,
                Id_plan = persona.Id_plan
            };
        }

        public IEnumerable<PersonaDTO> GetAll()
        {
            var personaRepository = new PersonaRepository();
            return personaRepository.GetAll().Select(persona => new PersonaDTO
            {
                Id_persona = persona.Id_persona,
                Nombre = persona.Nombre,
                Apellido = persona.Apellido,
                Direccion = persona.Direccion,
                Email = persona.Email,
                Telefono = persona.Telefono,
                Fecha_nac = persona.Fecha_nac,
                Legajo = persona.Legajo,
                Tipo_persona = persona.Tipo_persona,
                Id_plan = persona.Id_plan
            }).ToList();
        }

        public bool Update(PersonaDTO dto)
        {
            var personaRepository = new PersonaRepository();

            if (personaRepository.EmailExists(dto.Email, dto.Id_persona))
            {
                throw new ArgumentException("Ya existe una persona con ese email.", nameof(dto.Email));
            }
            
            Persona persona = new Persona(dto.Id_persona, dto.Nombre, dto.Apellido, dto.Direccion, 
                dto.Email, dto.Telefono, dto.Fecha_nac, dto.Legajo, dto.Tipo_persona, dto.Id_plan);
            return personaRepository.Update(persona);
        }

        public IEnumerable<PersonaDTO> GetByCriteria(PersonaCriteriaDTO criteriaDTO)
        {
            var personaRepository = new PersonaRepository();

            var criteria = new PersonaCriteria(criteriaDTO.Texto);

            var personas = personaRepository.GetByCriteria(criteria);

            return personas.Select(persona => new PersonaDTO
            {
                Id_persona = persona.Id_persona,
                Nombre = persona.Nombre,
                Apellido = persona.Apellido,
                Direccion = persona.Direccion,
                Email = persona.Email,
                Telefono = persona.Telefono,
                Fecha_nac = persona.Fecha_nac,
                Legajo = persona.Legajo,
                Tipo_persona = persona.Tipo_persona,
                Id_plan = persona.Id_plan
            }).ToList();
        }
    }
}


