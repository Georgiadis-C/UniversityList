using UniversityList.ViewModels;

namespace UniversityList.Views;

public partial class StudentListPage : ContentPage
{
    private StudentListpageViewModel _viewModel;
    
    public StudentListPage(StudentListpageViewModel viewModel)
	{
		InitializeComponent();
        _viewModel = viewModel;

		this.BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        
        base.OnAppearing();
        _viewModel.GetStudentListCommand.Execute(null);
    }

}