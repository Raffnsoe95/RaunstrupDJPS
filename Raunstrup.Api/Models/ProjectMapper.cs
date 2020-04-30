using Raunstrup.Contract;
using Raunstrup.Contract.DTOs;
using Raunstrup.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Raunstrup.Api.Models
{
    public static class ProjectMapper
    {
       
        public static Project Map(ProjectDto dto)
        {
            return new Project
            {
                Id = dto.Id,
                Active = dto.Active,
                Description = dto.Description,
                EndDate = dto.EndDate,
                IsAccepted = dto.IsAccepted,
                IsDone = dto.IsDone,
                IsFixedPrice = dto.IsFixedPrice,
                Price = dto.Price,
                StartDate = dto.StartDate,
                Rowversion = dto.Rowversion,
                WorkingHours =WorkingHoursMapper.Map(dto.WorkingHoursDto).ToList()
            };
        }

        public static IEnumerable<ProjectDto> Map(IEnumerable<Project> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static ProjectDto Map(Project project)
        {
            return new ProjectDto
            {
                Id = project.Id,
                Active = project.Active,
                Description = project.Description,
                EndDate = project.EndDate,
                IsAccepted = project.IsAccepted,
                IsDone = project.IsDone,
                IsFixedPrice = project.IsFixedPrice,
                Price = project.Price,
                StartDate = project.StartDate,
                Rowversion = project.Rowversion,
                WorkingHoursDto = WorkingHoursMapper.Map(project.WorkingHours).ToList()

            };
        }
    }
}
