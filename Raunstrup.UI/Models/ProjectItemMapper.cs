using Raunstrup.Contract.DTOs;
using Raunstrup.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raunstrup.UI.Models
{
    public class ProjectItemMapper
    {

        public static ProjectItemViewModel Map(ProjectItemDto dto)
        {
            return new ProjectItemViewModel
            {
                Id = dto.Id,
                Amount = dto.Amount,
                Price = dto.Price,
                //Item = ItemMapper.Map(dto.Item),
                ProjectId = dto.ProjectId
            };
        }

        public static IEnumerable<ProjectItemViewModel> Map(IEnumerable<ProjectItemDto> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static ProjectItemDto Map(ProjectItemViewModel view)
        {
            return new ProjectItemDto
            {
                Id = view.Id,
                Amount = view.Amount,
                Price = view.Price,
                //Item = ItemMapper.Map(view.Item),
                ProjectId = view.ProjectId
            };
        }

        

        

        
    }
}
