using UniversityList.Models;
using UniversityList.Services;

namespace UniversityListUnitTest;

public class StudentServiceTests
{
    [Fact]
    public async Task SaveStudent_ValidStudent_ShouldInsertToDatabase()
    {
        //Arrange
        var dbConnection = new SQLite.SQLiteAsyncConnection(":memory:");
        var studentService = new StudentService(dbConnection);
        var student = new StudentModel
        {
            FirstName = "Νίκος",
            LastName = "Παπαδόπουλος",
            Email = "nikos@example.com",
            Department = "Πληροφορική",
            YearAdded = 2023,
            GPA = 8.5
        };

        //Act
        await studentService.SaveStudent(student);

        //Assert
        var savedStudents = await studentService.GetStudentList();
        Assert.Single(savedStudents);
        Assert.Equal("Νίκος Παπαδόπουλος", savedStudents[0].FirstName + " " + savedStudents[0].LastName);
    }

    [Fact]
    public async Task DeleteStudent_ExistingStudent_ShouldRemoveFromDatabase()
    {
        //Arrange
        var dbConnection = new SQLite.SQLiteAsyncConnection(":memory:");
        var studentService = new StudentService(dbConnection);
        var student = new StudentModel
        {
            FirstName = "Νίκος",
            LastName = "Παπαδόπουλος",
            Email = "nikos@example.com",
            Department = "Πληροφορική",
            YearAdded = 2023,
            GPA = 8.5
        };

        //Act
        await studentService.DeleteStudent(student);

        //Assert
        var savedStudents = await studentService.GetStudentList();
        Assert.Empty(savedStudents);
    }

    [Fact]
    public async Task GetStudentList_ExistingStudents_ShouldReturnStudentList()
    {
        //Arrange
        var dbConnection = new SQLite.SQLiteAsyncConnection(":memory:");
        var studentService = new StudentService(dbConnection);
        var student = new StudentModel
        {
            FirstName = "Νίκος",
            LastName = "Παπαδόπουλος",
            Email = "nikos@example.com",
            Department = "Πληροφορική",
            YearAdded = 2023,
            GPA = 8.5
        };

        //Act
        await studentService.SaveStudent(student);

        //Assert
        Assert.NotEmpty(await studentService.GetStudentList());

    }
}

