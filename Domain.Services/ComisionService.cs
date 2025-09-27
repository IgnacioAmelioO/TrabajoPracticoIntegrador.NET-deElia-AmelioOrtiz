using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Domain.Model;
using DTOs;

namespace Domain.Services
{
    public class ComisionService
    {
        public ComisionDTO Add(ComisionDTO dto)
        {
            var comisionRepository = new ComisionRepository();

           
            if (comisionRepository.ComisionExists(dto.Desc_comision, dto.Anio_especialidad, dto.Id_plan))
            {
                throw new ArgumentException("Ya existe una comisión con ese nombre, año y plan.", nameof(dto));
            }

            Comision comision = new Comision(0, dto.Desc_comision, dto.Anio_especialidad, dto.Id_plan);
            comisionRepository.Add(comision);
            dto.Id_comision = comision.Id_comision; 

            return dto;
        }

        public bool Delete(int id)
        {
            var comisionRepository = new ComisionRepository();
            return comisionRepository.Delete(id);
        }

        public ComisionDTO Get(int id)
        {
            var comisionRepository = new ComisionRepository();
            Comision? comision = comisionRepository.Get(id);
            if (comision == null)
                return null;

            return new ComisionDTO
            {
                Id_comision = comision.Id_comision,
                Desc_comision = comision.Desc_comision,
                Anio_especialidad = comision.Anio_especialidad,
                Id_plan = comision.Id_plan
            };
        }

        public IEnumerable<ComisionDTO> GetAll()
        {
            var comisionRepository = new ComisionRepository();
            return comisionRepository.GetAll().Select(comision => new ComisionDTO
            {
                Id_comision = comision.Id_comision,
                Desc_comision = comision.Desc_comision,
                Anio_especialidad = comision.Anio_especialidad,
                Id_plan = comision.Id_plan
            }).ToList();
        }

        public bool Update(ComisionDTO dto)
        {
            var comisionRepository = new ComisionRepository();

           
            if (comisionRepository.ComisionExists(dto.Desc_comision, dto.Anio_especialidad, dto.Id_plan, dto.Id_comision))
            {
                throw new ArgumentException("Ya existe una comisión con ese nombre, año y plan.", nameof(dto));
            }

            Comision comision = new Comision(dto.Id_comision, dto.Desc_comision, dto.Anio_especialidad, dto.Id_plan);
            return comisionRepository.Update(comision);
        }
    }
}