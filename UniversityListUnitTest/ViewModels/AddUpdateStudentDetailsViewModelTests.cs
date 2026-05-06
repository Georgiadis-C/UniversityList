using UniversityList.Models;
using UniversityList.Services;
using UniversityList.ViewModels;
namespace UniversityListUnitTest;

public class AddUpdateStudentDetailsViewModelTests
{
    [Fact]
    public async Task AddUpdateStudentDetail_StateUnderTest_ExpectedBehavior()
    {
        // Arrange
        var dbConnection = new SQLite.SQLiteAsyncConnection(":memory:");
        var studentService = new StudentService(dbConnection);
        var viewModel = new AddUpdateStudentDetailViewModel(studentService);
        var studentModel = new StudentModel
        {
            FirstName = "Νίκος",
            LastName = "Παπαδόπουλος",
            Email = "nikos@example.com",
            Department = "Πληροφορική",
            YearAdded = 2023,
            GPA = 8.5
        };
        viewModel.StudentDetail = studentModel;

        // Act
        await viewModel.AddUpdateStudent();

        // Assert
        var allStudents = await studentService.GetStudentList();

        Assert.NotEmpty(allStudents);
        Assert.Equal("Νίκος", allStudents[0].FirstName);


    }
}
