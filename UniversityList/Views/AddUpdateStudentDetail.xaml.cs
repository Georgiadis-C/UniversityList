using UniversityList.ViewModels;

namespace UniversityList.Views;

public partial class AddUpdateStudentDetail : ContentPage
{
	public AddUpdateStudentDetail(AddUpdateStudentDetailViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
    }
}