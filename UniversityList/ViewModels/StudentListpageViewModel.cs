using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using UniversityList.Models;
using UniversityList.Services;
using UniversityList.Views;

namespace UniversityList.ViewModels
{
    public partial class StudentListpageViewModel : ObservableObject
    {
        public ObservableCollection<StudentModel> Students { get; set; } = new ObservableCollection<StudentModel>();
        
       private readonly IStudentService _studentService;
        public StudentListpageViewModel(IStudentService studentService)
        {
            _studentService = studentService;
        }


        [RelayCommand]
        public  async void GetStudentList()
        {
            var studentList = await _studentService.GetStudentList();
            if(studentList?.Count > 0)
            {
                Students.Clear();
                foreach(var student in studentList)
                {
                    Students.Add(student);
                }
            }
        }

        [RelayCommand]
        public async void AddUpdateStudent()
        {
            await AppShell.Current.GoToAsync(nameof(AddUpdateStudentDetail));
        }


        [RelayCommand]
        public async void DisplayAction(StudentModel studentModel)
        {
            var response = await AppShell.Current.DisplayActionSheet("Select Option", "OK", null, "Edit", "Delete");

            if (response == "Edit")
            {
                var navParam = new Dictionary<string, object>();
                navParam.Add("StudentDetail", studentModel);
                await AppShell.Current.GoToAsync(nameof(AddUpdateStudentDetail),navParam);
            }
            else if (response == "Delete")
            {
               var delResponse = await _studentService.DeleteStudent(studentModel);
                if (delResponse > 0)
                {
                    Students.Remove(studentModel);
                }
            }
        }
    }
}
