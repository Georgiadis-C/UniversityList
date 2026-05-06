using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;
using UniversityList.Interfaces;
using UniversityList.Models;


namespace UniversityList.Services
{
    public class StudentService (SQLiteAsyncConnection dbConnection) : IStudentService
    {
        private async Task InitializeAsync()
        {
            await dbConnection.CreateTableAsync<StudentModel>();
        }

        public async Task SaveStudent(StudentModel studentModel)
        {
            await InitializeAsync();

            if (studentModel.StudentId == 0)
            {
                await dbConnection.InsertAsync(studentModel);
            }
            else
            {
                await dbConnection.UpdateAsync(studentModel);
            }
        }

        public async Task DeleteStudent(StudentModel studentModel)
        {
            await InitializeAsync();

            await dbConnection.DeleteAsync(studentModel);
        }

        public async Task<List<StudentModel>> GetStudentList()
        {
            await InitializeAsync();

            var studentList = await dbConnection.Table<StudentModel>().ToListAsync();
            return studentList;
        }
    }
}
