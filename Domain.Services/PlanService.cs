using System.Collections.Generic;
using System.ComponentModel;
using Data;
using Domain.Model;
using DTOs;


namespace Domain.Services
{
    public class PlanService
    {
        public PlanDTO Add(PlanDTO dto)
        {
            var planRepository = new PlanRepository();

            if (planRepository.DescriptionExists(dto.Desc_plan))
            {
                throw new ArgumentException("Ya existe un plan con esa descripción.", nameof(dto.Desc_plan));
            }

            Plan plan = new Plan(0, dto.Desc_plan, dto.Id_especialidad);

            planRepository.Add(plan);

            dto.Id_plan = plan.Id_plan; // Asignar el Id generado al DTO

            return dto;

        }

        public bool Delete(int id)
        {
            var planRepository = new PlanRepository();
            return planRepository.Delete(id);
        }

        public PlanDTO Get(int id)
        {
            var planRepository = new PlanRepository();
            Plan? plan = planRepository.Get(id);
            if (plan == null)
                return null;

            return new PlanDTO
            {
                Id_plan = plan.Id_plan,
                Desc_plan = plan.Desc_plan,
                Id_especialidad = plan.Id_especialidad
            };
        }

        public IEnumerable<PlanDTO> GetAll()
        {
            var planRepository = new PlanRepository();
            return planRepository.GetAll().Select(plan => new PlanDTO
            {
                Id_plan = plan.Id_plan,
                Desc_plan = plan.Desc_plan,
                Id_especialidad = plan.Id_especialidad
            }).ToList();
        }

        public bool Update(PlanDTO dto)
        {
            var planRepository = new PlanRepository();

            if (planRepository.DescriptionExists(dto.Desc_plan))
            {
                throw new ArgumentException("Ya existe un plan con esa descripción.", nameof(dto.Desc_plan));
            }
            Plan plan = new Plan(dto.Id_plan, dto.Desc_plan, dto.Id_especialidad);
            return planRepository.Update(plan);
        }

        public IEnumerable<PlanDTO> GetByCriteria(PlanCriteriaDTO criteriaDTO)
        {
            var planRepository = new PlanRepository();

            var criteria = new PlanCriteria(criteriaDTO.Texto);

            var planes = planRepository.GetByCriteria(criteria);

            return planes.Select(plan => new PlanDTO
            {
                Id_plan = plan.Id_plan,
                Desc_plan = plan.Desc_plan,
                Id_especialidad = plan.Id_especialidad
            }).ToList();
        }
        

    }
}
