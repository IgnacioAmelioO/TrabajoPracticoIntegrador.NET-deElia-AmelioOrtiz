using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Domain.Model;
using DTOs;

namespace Domain.Services
{
    public class EspecialidadService
    {
        public EspecialidadDTO Add(EspecialidadDTO dto)
        {
            var especialidadRepository = new EspecialidadRepository();

            if (especialidadRepository.DescriptionExists(dto.Desc_esp))
            {
                throw new ArgumentException("Ya existe una especialidad con esa descripción.", nameof(dto.Desc_esp));
            }

            Especialidad especialidad = new Especialidad(0, dto.Desc_esp);

            especialidadRepository.Add(especialidad);

            dto.Id_especialidad = especialidad.Id_especialidad; // Asignar el Id generado al DTO

            return dto;
        }

        public bool Delete(int id)
        {
            var especialidadRepository = new EspecialidadRepository();
            return especialidadRepository.Delete(id);
        }

        public EspecialidadDTO Get(int id)
        {
            var especialidadRepository = new EspecialidadRepository();
            Especialidad? especialidad = especialidadRepository.Get(id);
            if (especialidad == null)
                return null;

            return new EspecialidadDTO
            {
                Id_especialidad = especialidad.Id_especialidad,
                Desc_esp = especialidad.Desc_esp
            };
        }

        public IEnumerable<EspecialidadDTO> GetAll()
        {
            var especialidadRepository = new EspecialidadRepository();
            return especialidadRepository.GetAll().Select(especialidad => new EspecialidadDTO
            {
                Id_especialidad = especialidad.Id_especialidad,
                Desc_esp = especialidad.Desc_esp
            }).ToList();
        }

        public bool Update(EspecialidadDTO dto)
        {
            var especialidadRepository = new EspecialidadRepository();

            if (especialidadRepository.DescriptionExists(dto.Desc_esp, dto.Id_especialidad))
            {
                throw new ArgumentException("Ya existe una especialidad con esa descripción.", nameof(dto.Desc_esp));
            }

            Especialidad especialidad = new Especialidad(dto.Id_especialidad, dto.Desc_esp);
            return especialidadRepository.Update(especialidad);
        }

        public IEnumerable<EspecialidadDTO> GetByCriteria(EspecialidadCriteriaDTO criteriaDTO)
        {
            var especialidadRepository = new EspecialidadRepository();

            var criteria = new EspecialidadCriteria(criteriaDTO.Texto);

            var especialidades = especialidadRepository.GetByCriteria(criteria);

            return especialidades.Select(especialidad => new EspecialidadDTO
            {
                Id_especialidad = especialidad.Id_especialidad,
                Desc_esp = especialidad.Desc_esp
            }).ToList();
        }
    }
}

