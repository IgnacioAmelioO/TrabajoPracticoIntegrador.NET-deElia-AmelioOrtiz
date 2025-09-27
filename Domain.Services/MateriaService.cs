using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Domain.Model;
using DTOs;

namespace Domain.Services
{
    public class MateriaService
    {
        public MateriaDTO Add(MateriaDTO dto)
        {
            var materiaRepository = new MateriaRepository();

            
            if (materiaRepository.MateriaExists(dto.Desc_materia, dto.Id_plan))
            {
                throw new ArgumentException("Ya existe una materia con ese nombre en el plan especificado.", nameof(dto));
            }

            Materia materia = new Materia(0, dto.Desc_materia, dto.Hs_semanales, dto.Hs_totales, dto.Id_plan);
            materiaRepository.Add(materia);
            dto.Id_materia = materia.Id_materia; 

            return dto;
        }

        public bool Delete(int id)
        {
            var materiaRepository = new MateriaRepository();
            return materiaRepository.Delete(id);
        }

        public MateriaDTO Get(int id)
        {
            var materiaRepository = new MateriaRepository();
            Materia? materia = materiaRepository.Get(id);
            if (materia == null)
                return null;

            return new MateriaDTO
            {
                Id_materia = materia.Id_materia,
                Desc_materia = materia.Desc_materia,
                Hs_semanales = materia.Hs_semanales,
                Hs_totales = materia.Hs_totales,
                Id_plan = materia.Id_plan
            };
        }

        public IEnumerable<MateriaDTO> GetAll()
        {
            var materiaRepository = new MateriaRepository();
            return materiaRepository.GetAll().Select(materia => new MateriaDTO
            {
                Id_materia = materia.Id_materia,
                Desc_materia = materia.Desc_materia,
                Hs_semanales = materia.Hs_semanales,
                Hs_totales = materia.Hs_totales,
                Id_plan = materia.Id_plan
            }).ToList();
        }

        public bool Update(MateriaDTO dto)
        {
            var materiaRepository = new MateriaRepository();

            
            if (materiaRepository.MateriaExists(dto.Desc_materia, dto.Id_plan, dto.Id_materia))
            {
                throw new ArgumentException("Ya existe una materia con ese nombre en el plan especificado.", nameof(dto));
            }

            Materia materia = new Materia(dto.Id_materia, dto.Desc_materia, dto.Hs_semanales, dto.Hs_totales, dto.Id_plan);
            return materiaRepository.Update(materia);
        }
    }
}