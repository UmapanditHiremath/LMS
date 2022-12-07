using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Leave_Management_3.Models
{
    public partial class Manager
    {
        [Required(ErrorMessage ="Enter Your ID")]
        public int EmpId { get; set; }
        [Required(ErrorMessage = "Enter Name ")]
        public string ManagerName { get; set; }
        [Required(ErrorMessage = "Enter Email ID")]
        public string ManagerEmailId { get; set; }
        [Required(ErrorMessage = "Enter Mobile number")]
        public int? MobileNo { get; set; }
    }
}
