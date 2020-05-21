using System;
using System.Collections.Generic;
using System.Text;

namespace Raunstrup.Contract.DTOs
{
    public class ProjectDetailsDto
    {
        public ProjectDetailsDto()
        {
            ProjectEmployees = new List<ProjectEmployeeDto>();
            WorkingHours = new List<WorkingHoursDto>();
            UsedItems = new List<ProjectUsedItemDto>();
            AssignedItems = new List<ProjectAssignedItemDto>();
            ProjectDrivings = new List<ProjectDrivingDto>();

        }

        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }

        public double ESTdriving { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }

        public bool IsFixedPrice { get; set; }

        public bool IsAccepted { get; set; }

        public bool IsDone { get; set; }

        public byte[] Rowversion { get; set; }

        public List<WorkingHoursDto> WorkingHours { get; set; }

        public List<ProjectEmployeeDto> ProjectEmployees { get; set; }
        public CustomerDto Customer { get; set; }

        public int? CustomerId { get; set; }

        public List<ProjectAssignedItemDto> AssignedItems { get; set; }

        public List<ProjectUsedItemDto> UsedItems { get; set; }

        public List<ProjectDrivingDto> ProjectDrivings { get; set; }


        public decimal TotalAssignedHours { get; set; }
        public decimal TotalAssignedItems { get; set; }
        public decimal TotalUsedHours { get; set; }
        public decimal TotalUsedItems { get; set; }
        public decimal TotalUsedDriving { get; set; }

        public decimal EstimatedPrice
        {
            get
            {
                return TotalAssignedHours + TotalAssignedItems + Convert.ToDecimal(ESTdriving);
            }
        }

        public decimal CustomerDiscount
        {
            get
            {
                if (Customer == null)
                {
                    return 0;
                }
                else
                {
                    return Math.Round(EstimatedPrice * Customer.CustomerDiscountType.DiscountPercent / 100, 2);
                }
            }
        }

        public decimal DiscountedPrice
        {
            get
            {
                if (Customer == null)
                {
                    return EstimatedPrice;
                }
                else
                {
                    return Math.Round(EstimatedPrice - (EstimatedPrice * Customer.CustomerDiscountType.DiscountPercent / 100), 2);
                }
            }
        }
    }
}
