using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Leave_Management_3.Models
{
    public partial class Users
    {
        [Required(ErrorMessage ="Enter ID")]
        public int Id { get; set; }
        [Required(ErrorMessage = "enter User name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Enter Email ID")]
        public string EmailId { get; set; }
        [Required(ErrorMessage = "Enter Password")]
        public string Password { get; set; }
    }
}
