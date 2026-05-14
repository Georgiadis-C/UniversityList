using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityList.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        bool isBusy;

        public async Task ExecuteAsync(Func<Task> action)
        {
            if (IsBusy) return;
            try
            {
                IsBusy = true;
                await action();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}