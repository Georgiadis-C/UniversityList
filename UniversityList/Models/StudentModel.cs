using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace UniversityList.Models
{
    public class StudentModel
    {
        [PrimaryKey, AutoIncrement]
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
