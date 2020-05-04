using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Raunstrup.Contract.DTOs
{
    public class ProjectDto
    {
        public ProjectDto()
        {
            WorkingHoursDtos = new List<WorkingHoursDto>();
            UsedItemsDtos = new List<ProjectItemDto>();
        }
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }

        public bool IsFixedPrice { get; set; }

        public bool IsAccepted { get; set; }
        public bool IsDone { get; set; }

        public List<WorkingHoursDto> WorkingHoursDtos { get; set; }

        public List<ProjectItemDto> UsedItemsDtos { get; set; }

        public List<ProjectDrivingDto> ProjectDrivingDtos { get; set; }
        public List<ProjectEmployeeDto> ProjectEmployeeDtos { get; set; }

        [Timestamp]
        public byte[] Rowversion { get; set; }
    }
}
