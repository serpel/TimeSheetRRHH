using System;
using System.ComponentModel.DataAnnotations;

namespace RRHH.Models
{
    public class ShiftSchedule
    {
        [Key]
        public Int32 ShiftScheduleId { get; set; }
        public Int32? ShiftId { get; set; }
        public Int32? EmployeeId { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime InsertedAt { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }

        public virtual Shift Shift { get; set; }
        public virtual Employee Employee { get; set; }
    }
}