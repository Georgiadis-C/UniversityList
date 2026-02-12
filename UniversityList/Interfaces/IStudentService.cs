using System;
using System.Collections.Generic;
using System.Text;
using UniversityList.Models;

namespace UniversityList.Interfaces
{
    public interface IStudentService
    {
        Task<List<StudentModel>> GetStudentList();

        Task SaveStudent(StudentModel studentModel);
        Task DeleteStudent(StudentModel studentModel);
    }
}
