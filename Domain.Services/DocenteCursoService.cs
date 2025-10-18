using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Domain.Model;
using DTOs;

namespace Domain.Services
{
    public class DocenteCursoService
    {
        public DocenteCursoDTO Add(DocenteCursoDTO dto)
        {
            var docenteCursoRepository = new DocenteCursoRepository();

            // Verificar si ya existe una asignación para este docente y curso
            if (docenteCursoRepository.ExistsByDocenteAndCurso(dto.Id_docente, dto.Id_curso))
            {
                throw new ArgumentException("Ya existe una asignación para este docente y curso.", nameof(dto));
            }

            DocenteCurso docenteCurso = new DocenteCurso(0, dto.Id_curso, dto.Id_docente, dto.Cargo);

            docenteCursoRepository.Add(docenteCurso);

            dto.Id_dictado = docenteCurso.Id_dictado; // Asignar el Id generado al DTO

            return dto;
        }

        public bool Delete(int id)
        {
            var docenteCursoRepository = new DocenteCursoRepository();
            return docenteCursoRepository.Delete(id);
        }

        public DocenteCursoDTO Get(int id)
        {
            var docenteCursoRepository = new DocenteCursoRepository();
            DocenteCurso? docenteCurso = docenteCursoRepository.Get(id);
            if (docenteCurso == null)
                return null;

            return new DocenteCursoDTO
            {
                Id_dictado = docenteCurso.Id_dictado,
                Id_curso = docenteCurso.Id_curso,
                Id_docente = docenteCurso.Id_docente,
                Cargo = docenteCurso.Cargo
            };
        }

        public IEnumerable<DocenteCursoDTO> GetAll()
        {
            var docenteCursoRepository = new DocenteCursoRepository();
            return docenteCursoRepository.GetAll().Select(docenteCurso => new DocenteCursoDTO
            {
                Id_dictado = docenteCurso.Id_dictado,
                Id_curso = docenteCurso.Id_curso,
                Id_docente = docenteCurso.Id_docente,
                Cargo = docenteCurso.Cargo
            }).ToList();
        }

        public bool Update(DocenteCursoDTO dto)
        {
            var docenteCursoRepository = new DocenteCursoRepository();

            // Verificar si ya existe una asignación para este docente y curso (excluyendo el actual)
            if (docenteCursoRepository.ExistsByDocenteAndCurso(dto.Id_docente, dto.Id_curso, dto.Id_dictado))
            {
                throw new ArgumentException("Ya existe otra asignación para este docente y curso.", nameof(dto));
            }

            DocenteCurso docenteCurso = new DocenteCurso(dto.Id_dictado, dto.Id_curso, dto.Id_docente, dto.Cargo);
            return docenteCursoRepository.Update(docenteCurso);
        }

        public IEnumerable<DocenteCursoDTO> GetByDocente(int idDocente)
        {
            var docenteCursoRepository = new DocenteCursoRepository();
            
            return docenteCursoRepository.GetByDocente(idDocente).Select(docenteCurso => new DocenteCursoDTO
            {
                Id_dictado = docenteCurso.Id_dictado,
                Id_curso = docenteCurso.Id_curso,
                Id_docente = docenteCurso.Id_docente,
                Cargo = docenteCurso.Cargo
            }).ToList();
        }

        public IEnumerable<DocenteCursoDTO> GetByCurso(int idCurso)
        {
            var docenteCursoRepository = new DocenteCursoRepository();
            
            return docenteCursoRepository.GetByCurso(idCurso).Select(docenteCurso => new DocenteCursoDTO
            {
                Id_dictado = docenteCurso.Id_dictado,
                Id_curso = docenteCurso.Id_curso,
                Id_docente = docenteCurso.Id_docente,
                Cargo = docenteCurso.Cargo
            }).ToList();
        }
    }
}
