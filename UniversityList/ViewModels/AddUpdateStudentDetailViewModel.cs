using System;
using System.Collections.Generic;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using UniversityList.Services;

namespace UniversityList.ViewModels
{
    public partial class AddUpdateStudentDetailViewModel : ObservableObject
    {
        private readonly IStudentService _studentService;

        public AddUpdateStudentDetailViewModel(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [ObservableProperty]
        private string _firstName;

        [ObservableProperty]
        private string _lastName;

        [ObservableProperty]
        private string _email;

        [RelayCommand]
        public async Task AddUpdateStudent()
        {
            var response = await _studentService.AddStudent(new Models.StudentModel
            {
                Email = Email,
                FirstName = FirstName,
                LastName = LastName,

            });

            if(response > 0)
            {
                await Shell.Current.DisplayAlert("Success", "Record added to Student Table", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Head Up!", "Something went wrong while adding record", "OK");
            }
        }



    }
}
