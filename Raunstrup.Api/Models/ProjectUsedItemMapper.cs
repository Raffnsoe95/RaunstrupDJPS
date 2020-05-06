using Raunstrup.Contract.DTOs;
using Raunstrup.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raunstrup.Api.Models
{
    public class ProjectUsedItemMapper
    {
        public static ProjectUsedItem Map(ProjectUsedItemDto dto)
        {
            return new ProjectUsedItem
            {
                Id = dto.Id,
                Amount = dto.Amount,
                Price = dto.Price,
                IsUsed = dto.IsUsed,
                Item = ItemMapper.Map(dto.Item),
                ItemID = dto.ItemID,
                ProjectId = dto.ProjectId
            };
        }

        public static IEnumerable<ProjectUsedItemDto> Map(IEnumerable<ProjectUsedItem> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static IEnumerable<ProjectUsedItem> Map(IEnumerable<ProjectUsedItemDto> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static ProjectUsedItemDto Map(ProjectUsedItem projectItem)
        {
            return new ProjectUsedItemDto
            {
                Id = projectItem.Id,
                Amount = projectItem.Amount,
                Price = projectItem.Price,
                IsUsed = projectItem.IsUsed,
                Item = ItemMapper.Map(projectItem.Item),
                ItemID = projectItem.ItemID,
                ProjectId = projectItem.ProjectId
            };
        }
    }
}
