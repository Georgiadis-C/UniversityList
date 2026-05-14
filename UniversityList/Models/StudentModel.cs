using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UniversityList.Models
{
    public class StudentModel
    {
        [PrimaryKey, AutoIncrement]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First name can only contain letters")]
        [StringLength(20, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last name can only contain letters")]
        [StringLength(20, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [RegularExpression(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@(gmail\.com|outlook\.com|yahoo\.com)$",
        ErrorMessage = "Only Gmail, Outlook or Yahoo accounts are allowed")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Department is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Department can only contain letters")]
        public string Department { get; set; }

        [Required(ErrorMessage = "Year added is required")]
        [Range(1975, 2026, ErrorMessage = "Year added must be between 1975 and 2026")]
        public int? YearAdded { get; set; }

        [Required(ErrorMessage = "GPA is required")]
        [Range(5.0, 10.0, ErrorMessage = "GPA must be between 5.0 and 10.0")]
        public double? GPA { get; set; }

    }
}
