using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Leave_Management_3.Models
{
    public partial class LeaveApplication
    {
        [Required(ErrorMessage ="Enter Leave ID")]
        public int LeaveId { get; set; }
        [Required(ErrorMessage = "Enter no of days")]
        public int? NoOfDays { get; set; }
        [Required(ErrorMessage = "Enter Start Dtae")]
        public DateTime? StartDate { get; set; }
        [Required(ErrorMessage = "Enter End Date")]
        public DateTime? EndDate { get; set; }
        [Required(ErrorMessage = "Enter Leave Type")]
        public string LeaveType { get; set; }
        [Required]
        public string Status { get; set; }
        public string Reason { get; set; }
        public string ManagerComments { get; set; }
    }
}
