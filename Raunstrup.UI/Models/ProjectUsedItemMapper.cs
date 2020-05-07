using Raunstrup.Contract.DTOs;
using Raunstrup.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raunstrup.UI.Models
{
    public class ProjectUsedItemMapper
    {
        public static ProjectUsedItemViewModel Map(ProjectUsedItemDto dto)
        {
            return new ProjectUsedItemViewModel
            {
                Id = dto.Id,
                Amount = dto.Amount,
                Price = dto.Price,
                Item = ItemMapper.Map(dto.Item),
                ItemID = dto.ItemID,
                ProjectId = dto.ProjectId
            };
        }

        public static IEnumerable<ProjectUsedItemDto> Map(IEnumerable<ProjectUsedItemViewModel> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }
        public static IEnumerable<ProjectUsedItemViewModel> Map(IEnumerable<ProjectUsedItemDto> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static ProjectUsedItemDto Map(ProjectUsedItemViewModel view)
        {
            return new ProjectUsedItemDto
            {
                Id = view.Id,
                Amount = view.Amount,
                Price = view.Price,
                Item = ItemMapper.Map(view.Item),
                ItemID = view.ItemID,
                ProjectId = view.ProjectId
            };
        }  
    }
}
