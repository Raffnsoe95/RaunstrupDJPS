using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace Raunstrup.UI.Models
{
    public class ProjectViewModel
    {
        public ProjectViewModel() 
        {
            UsedItems = new List<ProjectUsedItemViewModel>();
            AssignedItems = new List<ProjectAssignedItemViewModel>();
        }


        public int Id { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime StartDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }

        public bool IsFixedPrice { get; set; }

        public bool IsAccepted { get; set; }

        public bool IsDone { get; set; }

        [Timestamp]
        public byte[] Rowversion { get; set; }

        public List<WorkingHoursViewModel> WorkingHours { get; set; }

        public List<ProjectEmployeeViewModel> ProjectEmployees { get; set; }

        public List<ProjectAssignedItemViewModel> AssignedItems { get; set; }

        public List<ProjectUsedItemViewModel> UsedItems { get; set; }

        public List<ProjectDrivingViewModel> ProjectDrivings { get; set; }
    }
}
