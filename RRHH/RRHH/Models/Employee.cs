using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RRHH.Models
{
    public enum Gender
    {
        F = 0,
        M = 1
    }

    public class Employee
    {
        [Key]
        public Int32 EmployeeId { get; set; }
        [Required]
        [StringLength(20)]
        public string EmployeeCode { get; set; }
        [StringLength(50)]
        public string NationalCardId { get; set; }
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        [StringLength(150)]
        public string Address { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? Birthdate { get; set; }
        public Gender Gender { get; set; }
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        public string PhoneNumber { get; set; }
        public string ProfileUrl { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? HireDate { get; set; }
        [Required]
        public Int32 DepartmentId { get; set; }
        public Int32 ShiftId { get; set; }
        public Int32? JobPositionId { get; set; }
        public Int32? CountryId { get; set; }
        public Int32? CityId { get; set; }
        public bool IsActive { get; set; }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        public virtual Department Department { get; set; }
        public virtual City City { get; set; }
        public virtual Country Country { get; set; }
        public virtual JobPosition JobPosition { get; set; }
        public virtual Shift Shift { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
        public virtual ICollection<AttendanceRecord> AttendanceRecords { get; set; }
        public virtual ICollection<TimeSheet> Timesheets { get; set; }
    }
}