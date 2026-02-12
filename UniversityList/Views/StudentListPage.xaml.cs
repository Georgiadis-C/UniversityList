using UniversityList.ViewModels;

namespace UniversityList.Views;

public partial class StudentListPage : ContentPage
{
    private StudentListpageViewModel _viewModel;
    
    public StudentListPage(StudentListpageViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = _viewModel = viewModel;


    }

    protected override async void OnAppearing()
    {
         await _viewModel.GetStudentList();
    }

}