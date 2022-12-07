using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Leave_Management_3.Models
{
    public  class Employee
    {
      
        public int EmpId { get; set; }
        [Required(ErrorMessage = "Employee Name is required")]
        public string EmployeeName { get; set; }
        [Required(ErrorMessage = "Employee Email ID is required")]
        public string EmployeeEmailId { get; set; }
        [Required(ErrorMessage = "Employee Mpbile no is required")]
        public int? MobileNo { get; set; }
        [Required]
        public DateTime? DateJoined { get; set; }
        [Required]
        public string Department { get; set; }
    }
}
