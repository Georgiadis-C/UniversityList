using System;
using System.Collections.Generic;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using UniversityList.Interfaces;
using UniversityList.Models;

namespace UniversityList.ViewModels
{
    [QueryProperty(nameof(StudentDetail),"StudentDetail")]
    public partial class AddUpdateStudentDetailViewModel(IStudentService studentService) : ObservableObject
    {
        [ObservableProperty]
        StudentModel _studentDetail = new();

        [RelayCommand]
        public async Task AddUpdateStudent()
        {
            await studentService.SaveStudent(StudentDetail);

            await Shell.Current.DisplayAlertAsync("Student Info Saved", "Record Saved", "OK");

            StudentDetail = new();
        }
    }
}
