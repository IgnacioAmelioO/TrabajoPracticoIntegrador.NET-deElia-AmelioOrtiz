using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Domain.Model;
using DTOs;

namespace Domain.Services
{
    public class CursoService
    {
        public CursoDTO Add(CursoDTO dto)
        {
            var cursoRepository = new CursoRepository();

            
            if (cursoRepository.CursoExists(dto.Anio_calendario, dto.Id_materia, dto.Id_comision))
            {
                throw new ArgumentException("Ya existe un curso para esa materia y comisión en el año especificado.",
                    nameof(dto));
            }

            Curso curso = new Curso(0, dto.Anio_calendario, dto.Cupo, dto.Id_materia, dto.Id_comision);

            cursoRepository.Add(curso);

            dto.Id_curso = curso.Id_curso; 

            return dto;
        }

        public bool Delete(int id)
        {
            var cursoRepository = new CursoRepository();
            return cursoRepository.Delete(id);
        }

        public CursoDTO Get(int id)
        {
            var cursoRepository = new CursoRepository();
            Curso? curso = cursoRepository.Get(id);
            if (curso == null)
                return null;

            return new CursoDTO
            {
                Id_curso = curso.Id_curso,
                Anio_calendario = curso.Anio_calendario,
                Cupo = curso.Cupo,
                Id_materia = curso.Id_materia,
                Id_comision = curso.Id_comision
            };
        }

        public IEnumerable<CursoDTO> GetAll()
        {
            var cursoRepository = new CursoRepository();
            return cursoRepository.GetAll().Select(curso => new CursoDTO
            {
                Id_curso = curso.Id_curso,
                Anio_calendario = curso.Anio_calendario,
                Cupo = curso.Cupo,
                Id_materia = curso.Id_materia,
                Id_comision = curso.Id_comision
            }).ToList();
        }

        public bool Update(CursoDTO dto)
        {
            var cursoRepository = new CursoRepository();

            
            if (cursoRepository.CursoExists(dto.Anio_calendario, dto.Id_materia, dto.Id_comision, dto.Id_curso))
            {
                throw new ArgumentException("Ya existe un curso para esa materia y comisión en el año especificado.",
                    nameof(dto));
            }

            Curso curso = new Curso(dto.Id_curso, dto.Anio_calendario, dto.Cupo, dto.Id_materia, dto.Id_comision);
            return cursoRepository.Update(curso);
        }
    }
}
