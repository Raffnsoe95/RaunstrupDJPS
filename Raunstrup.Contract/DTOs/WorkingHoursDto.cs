using Raunstrup.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Raunstrup.Contract.DTOs
{
   public class WorkingHoursDto
    {
        //public WorkingHoursDto()
        //{
        //    Employee = new EmployeeDto();
        //}
        public int Id { get; set; }
        public int Amount { get; set; }
        public int EmployeeId { get; set; }
        public decimal HourlyPrice { get; set; }

        public int ProjectId { get; set; }
       
        public EmployeeDto Employee { get; set; }

        [Timestamp]
        public byte[] Rowversion { get; set; }

        
    }
}
