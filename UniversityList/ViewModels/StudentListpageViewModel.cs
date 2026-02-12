using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using UniversityList.Models;
using UniversityList.Services;
using UniversityList.Views;
using UniversityList.Interfaces;

namespace UniversityList.ViewModels
{
    public partial class StudentListpageViewModel(IStudentService _studentService) : ObservableObject 
    {
        public ObservableCollection<StudentModel> Students { get; set; } = new ObservableCollection<StudentModel>();

        private List<StudentModel> _allStudentsList = new List<StudentModel>();

        [ObservableProperty]
        private string _searchText;

        partial void OnSearchTextChanged(string value)
        {
            SearchStudent(value);
        }

        [RelayCommand]
        public void SearchStudent(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                Students.Clear();
                foreach (var s in _allStudentsList) Students.Add(s);
                return;
            }

            var filtered = _allStudentsList
                .Where(s => s.LastName != null && s.LastName.ToLower().Contains(searchText.ToLower()))
                .ToList();

            Students.Clear();
            foreach (var s in filtered) Students.Add(s);
        }

        [RelayCommand]
        public async Task GetStudentList() 
        {
            var studentList = await _studentService.GetStudentList();

            Students.Clear();
            _allStudentsList.Clear();

            if (studentList != null && studentList.Count > 0)
            {
                foreach (var student in studentList)
                {
                    Students.Add(student);
                    _allStudentsList.Add(student);
                }
            }
        }

        [RelayCommand]
        public async Task AddUpdateStudent()
        {
            await Shell.Current.GoToAsync(nameof(AddUpdateStudentDetail));
        }

        [RelayCommand]
        public async Task DisplayAction(StudentModel studentModel)
        {
            var response = await Shell.Current.DisplayActionSheet("Select Option", "OK", null, "Edit", "Delete");

            if (response == "Edit")
            {
                var navParam = new Dictionary<string, object>
                {
                    { "StudentDetail", studentModel }
                };
                await Shell.Current.GoToAsync(nameof(AddUpdateStudentDetail), navParam);
            }
            else if (response == "Delete")
            {
                await _studentService.DeleteStudent(studentModel);
                    Students.Remove(studentModel);
                    _allStudentsList.Remove(studentModel);
            }
        }
    }
}