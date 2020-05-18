using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Raunstrup.Contract.DTOs;
using Raunstrup.DataAccess.Model;

namespace Raunstrup.Api.Models
{
    public class ProjectAssignedItemMapper
    {
        public static ProjectAssignedItem Map(ProjectAssignedItemDto dto)
        {
            return new ProjectAssignedItem
            {
                Id = dto.Id,
                Amount = dto.Amount,
                Price = dto.Price,
                Item = ItemMapper.Map(dto.Item),
                ItemID = dto.ItemID,
                ProjectId = dto.ProjectId
            };
        }

        public static IEnumerable<ProjectAssignedItemDto> Map(IEnumerable<ProjectAssignedItem> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static IEnumerable<ProjectAssignedItem> Map(IEnumerable<ProjectAssignedItemDto> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static ProjectAssignedItemDto Map(ProjectAssignedItem projectItem)
        {
            return new ProjectAssignedItemDto
            {
                Id = projectItem.Id,
                Amount = projectItem.Amount,
                Price = projectItem.Price,
                Item = ItemMapper.Map(projectItem.Item),
                ItemID = projectItem.ItemID,
                ProjectId = projectItem.ProjectId
            };
        }
    }
}
