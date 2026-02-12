using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using UniversityList.Interfaces;
using UniversityList.Models;

namespace UniversityList.Services
{
    public class StudentService : IStudentService
    {
        private SQLiteAsyncConnection _dbConnection;
        public StudentService()
        {
            SetUpDB();
        }

        private async void SetUpDB()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Student.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<StudentModel>();
            }
        }
        public async Task SaveStudent(StudentModel studentModel)
        {
            if (studentModel.StudentId == 0)
            {
                await _dbConnection.InsertAsync(studentModel);
            }
            else
            {
                await _dbConnection.UpdateAsync(studentModel);
            }
        }

        public async Task DeleteStudent(StudentModel studentModel)
        {
            await _dbConnection.DeleteAsync(studentModel);
        }

        public async Task<List<StudentModel>> GetStudentList()
        {
            var studentList = await _dbConnection.Table<StudentModel>().ToListAsync();
            return studentList;
        }
    }
}
