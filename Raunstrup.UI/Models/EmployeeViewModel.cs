using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Raunstrup.UI.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        [RegularExpression(@"[A-ZØ]+[a-zøA-ZØ]"),StringLength(200)]
        public string Name { get; set; }
        [RegularExpression(@"[0-9()+]"), StringLength(9)]
        public string Tlfnr { get; set; }
        public bool Active { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
