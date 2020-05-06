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
            ProjectDrivingDtos = new List<ProjectDrivingDto>();
            ProjectEmployeeDtos = new List<ProjectEmployeeDto>();
            UsedItemsDtos = new List<ProjectUsedItemDto>();
            AssignedItemDtos = new List<ProjectAssignedItemDto>();
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

        [Timestamp]
        public byte[] Rowversion { get; set; }

        public List<WorkingHoursDto> WorkingHoursDtos { get; set; }

        public List<ProjectUsedItemDto> UsedItemsDtos { get; set; }

        public List<ProjectAssignedItemDto> AssignedItemDtos { get; set; }

        public List<ProjectDrivingDto> ProjectDrivingDtos { get; set; }

        public List<ProjectEmployeeDto> ProjectEmployeeDtos { get; set; }
    }
}
