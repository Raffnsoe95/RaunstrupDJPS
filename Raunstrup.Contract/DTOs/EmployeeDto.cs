using System;

namespace Raunstrup.Contract.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tlfnr { get; set; }
        public decimal Salary { get; set; }
        public bool Active { get; set; }
       
    }
}
