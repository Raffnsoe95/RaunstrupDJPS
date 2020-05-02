using Raunstrup.Contract.DTOs;
using Raunstrup.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raunstrup.Api.Models
{
    public class ProjectItemMapper
    {
        public static ProjectItem Map(ProjectItemDto dto)
        {
            return new ProjectItem
            {
                Id = dto.Id,
                Amount = dto.Amount,
                Price = dto.Price,
                //Item = ItemMapper.Map(dto.Item),
                ProjectId = dto.ProjectId
            };
        }

        public static IEnumerable<ProjectItemDto> Map(IEnumerable<ProjectItem> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static IEnumerable<ProjectItem> Map(IEnumerable<ProjectItemDto> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static ProjectItemDto Map(ProjectItem projectItem)
        {
            return new ProjectItemDto
            {
                Id = projectItem.Id,
                Amount = projectItem.Amount,
                Price = projectItem.Price,
                //Item = ItemMapper.Map(projectItem.Item),
                ProjectId = projectItem.ProjectId
            };
        }
    }
}
