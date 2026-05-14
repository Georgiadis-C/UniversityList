
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel.DataAnnotations;
using UniversityList.Interfaces;
using UniversityList.Models;

namespace UniversityList.ViewModels
{
    [QueryProperty(nameof(StudentDetail),"StudentDetail")]
    public partial class AddUpdateStudentDetailViewModel(IStudentService studentService) : ObservableObject
    {
        [ObservableProperty]
        StudentModel _studentDetail = new();
        
        [ObservableProperty]
        string firstNameError; 
        [ObservableProperty]
        string lastNameError;
        [ObservableProperty]
        string emailError;
        [ObservableProperty]
        string departmentError;
        [ObservableProperty]
        string yearAddedError;
        [ObservableProperty]
        string gpaError;

        [RelayCommand]
        public async Task AddUpdateStudent()
        {
            FirstNameError = LastNameError = EmailError = DepartmentError = YearAddedError = GpaError = string.Empty;

            var context = new ValidationContext(StudentDetail);
            var results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(StudentDetail, context, results, true);

            if (!isValid)
            {
                foreach (var error in results)
                {
                    var propertyName = error.MemberNames.FirstOrDefault();

                    switch (propertyName)
                    {
                        case nameof(StudentDetail.FirstName):
                            FirstNameError = error.ErrorMessage;
                            break;
                        case nameof(StudentDetail.LastName):
                            LastNameError = error.ErrorMessage;
                            break;
                        case nameof(StudentDetail.Email):
                            EmailError = error.ErrorMessage;
                            break;
                        case nameof(StudentDetail.Department):
                            DepartmentError = error.ErrorMessage;
                            break;
                        case nameof(StudentDetail.YearAdded):
                            YearAddedError = error.ErrorMessage;
                            break;
                        case nameof(StudentDetail.GPA):
                            GpaError = error.ErrorMessage;
                            break;
                    }
                }
                return; 
            }

            await studentService.SaveStudent(StudentDetail);

            if (Shell.Current != null)
            {
                await Shell.Current.DisplayAlertAsync("Student Info Saved", "Record Saved", "OK");

                await Shell.Current.GoToAsync("..");
            }

            StudentDetail = new();
        }
    }
}
