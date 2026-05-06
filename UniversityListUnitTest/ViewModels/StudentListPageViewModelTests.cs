using UniversityList.Models;

namespace UniversityListUnitTest;


public class StudentListPageViewModelTests
{
    [Fact]
    public async Task If_SearchStudent_Gives_ExpectedResults()
    {
        // Arrange
        var dbConnection = new SQLite.SQLiteAsyncConnection(":memory:");
        var studentService = new UniversityList.Services.StudentService(dbConnection);
        var viewModel = new UniversityList.ViewModels.StudentListpageViewModel(studentService);

        await studentService.SaveStudent(new StudentModel { FirstName = "Nikos", LastName = "Papadopoulos" });
        await studentService.SaveStudent(new StudentModel { FirstName = "Giorgos", LastName = "Georgiou" });


        await viewModel.GetStudentList();

        // Act
        viewModel.SearchStudent ("Pap"); 

        // Assert
        Assert.Single(viewModel.Students);
        Assert.Equal("Papadopoulos", viewModel.Students[0].LastName);
    }
}