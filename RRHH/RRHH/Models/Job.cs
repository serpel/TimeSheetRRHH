using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RRHH.Models
{
    public class Job
    {
        [Key]
        public Int32 JobId { get; set; }
        [StringLength(100)]
        public string JobTitle { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}