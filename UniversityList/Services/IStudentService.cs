using System;
using System.Collections.Generic;
using System.Text;
using UniversityList.Models;

namespace UniversityList.Services
{
    public interface IStudentService
    {
        Task<List<StudentModel>> GetStudentList();

        Task<int> AddStudent(StudentModel studentModel);
        Task<int> DeleteStudent(StudentModel studentModel);
        Task<int> UpdateStudent(StudentModel studentModel);
    }
}
