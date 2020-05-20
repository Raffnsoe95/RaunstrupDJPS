using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Raunstrup.Contract.DTOs;

namespace Raunstrup.UI.Models
{
    public class ProjectAssignedItemMapper
    {
        public static ProjectAssignedItemViewModel Map(ProjectAssignedItemDto dto)
        {
            return new ProjectAssignedItemViewModel
            {
                Id = dto.Id,
                Amount = dto.Amount,
                Price = dto.Price,
                Item = ItemMapper.Map(dto.Item),
                ItemId = dto.ItemID,
                ProjectId = dto.ProjectId
            };
        }

        public static IEnumerable<ProjectAssignedItemDto> Map(IEnumerable<ProjectAssignedItemViewModel> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static IEnumerable<ProjectAssignedItemViewModel> Map(IEnumerable<ProjectAssignedItemDto> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static ProjectAssignedItemDto Map(ProjectAssignedItemViewModel view)
        {
            return new ProjectAssignedItemDto
            {
                Id = view.Id,
                Amount = view.Amount,
                Price = view.Price,
                Item = ItemMapper.Map(view.Item),
                ItemID = view.ItemId,
                ProjectId = view.ProjectId
            };
        }
    }
}
