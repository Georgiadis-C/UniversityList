using System;
using System.Collections.Generic;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using UniversityList.Models;
using UniversityList.Services;

namespace UniversityList.ViewModels
{
    [QueryProperty(nameof(StudentDetail),"StudentDetail")]
    public partial class AddUpdateStudentDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        private StudentModel _studentDetail = new StudentModel();

        private readonly IStudentService _studentService;

        public AddUpdateStudentDetailViewModel(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [RelayCommand]
        public async Task AddUpdateStudent()
        {
            int response = -1;
            if(StudentDetail.StudentId > 0)
            {
                response = await _studentService.UpdateStudent(StudentDetail);
            }
            else
            {
                 response = await _studentService.AddStudent(new Models.StudentModel
                {
                    Email = StudentDetail.Email,
                    FirstName = StudentDetail.FirstName,
                    LastName = StudentDetail.LastName,

                });
            }



            if(response > 0)
            {
                await Shell.Current.DisplayAlert("Student Info Saved", "Record Saved", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Head Up!", "Something went wrong while adding record", "OK");
            }
        }



    }
}
