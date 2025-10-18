using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Domain.Model;
using DTOs;

namespace Domain.Services
{
    public class AlumnoInscripcionService
    {
        public AlumnoInscripcionDTO Add(AlumnoInscripcionDTO dto)
        {
            var repo = new AlumnoInscripcionRepository();

            // Validación simple: evitar duplicados alumno-curso
            if (repo.ExistsByAlumnoCurso(dto.Id_alumno, dto.Id_curso))
                throw new ArgumentException("El alumno ya está inscripto en ese curso.", nameof(dto));

            var ent = new AlumnoInscripcion(0, dto.Id_alumno, dto.Id_curso, dto.Nota, dto.Condicion);

            try
            {
                // Usar el método que chequea cupo y decrementa en la misma transacción/contexto
                repo.AddWithCupoCheck(ent);
            }
            catch (ArgumentException)
            {
                // Re-lanzar para que el caller (endpoints) reciba BadRequest/NotFound según convenga
                throw;
            }
            catch (InvalidOperationException ex)
            {
                // No hay cupo disponible
                throw new ArgumentException(ex.Message, nameof(dto.Id_curso));
            }

            dto.Id_inscripcion = ent.Id_inscripcion;
            return dto;
        }

        public bool Delete(int id)
        {
            var repo = new AlumnoInscripcionRepository();
            return repo.Delete(id);
        }

        public AlumnoInscripcionDTO? Get(int id)
        {
            var repo = new AlumnoInscripcionRepository();
            var ent = repo.Get(id);
            if (ent == null) return null;
            return new AlumnoInscripcionDTO
            {
                Id_inscripcion = ent.Id_inscripcion,
                Id_alumno = ent.Id_alumno,
                Id_curso = ent.Id_curso,
                Nota = ent.Nota,
                Condicion = ent.Condicion
            };
        }

        public IEnumerable<AlumnoInscripcionDTO> GetAll()
        {
            var repo = new AlumnoInscripcionRepository();
            return repo.GetAll().Select(ent => new AlumnoInscripcionDTO
            {
                Id_inscripcion = ent.Id_inscripcion,
                Id_alumno = ent.Id_alumno,
                Id_curso = ent.Id_curso,
                Nota = ent.Nota,
                Condicion = ent.Condicion
            }).ToList();
        }

        public bool Update(AlumnoInscripcionDTO dto)
        {
            var repo = new AlumnoInscripcionRepository();

            // Si se requiere, validar reglas antes de actualizar (por ejemplo unicidad alumno-curso)
            if (repo.ExistsByAlumnoCurso(dto.Id_alumno, dto.Id_curso, dto.Id_inscripcion))
                throw new ArgumentException("Ya existe otra inscripción del mismo alumno en ese curso.", nameof(dto));

            var ent = new AlumnoInscripcion(dto.Id_inscripcion, dto.Id_alumno, dto.Id_curso, dto.Nota, dto.Condicion);
            return repo.Update(ent);
        }

        // Obtener inscripciones por Id_alumno
        public IEnumerable<AlumnoInscripcionDTO> GetByAlumno(int id_alumno)
        {
            var repo = new AlumnoInscripcionRepository();
            var list = repo.GetByAlumno(id_alumno);
            return list.Select(ent => new AlumnoInscripcionDTO
            {
                Id_inscripcion = ent.Id_inscripcion,
                Id_alumno = ent.Id_alumno,
                Id_curso = ent.Id_curso,
                Nota = ent.Nota,
                Condicion = ent.Condicion
            }).ToList();
        }
    }
}