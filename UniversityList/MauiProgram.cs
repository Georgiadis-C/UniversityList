using Microsoft.Extensions.Logging;
using UniversityList.Views;
using UniversityList.ViewModels;
using UniversityList.Services;
using UniversityList.Interfaces;

namespace UniversityList
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            //Services
            builder.Services.AddSingleton<IStudentService, StudentService>();


            //Views Registration
            builder.Services.AddSingleton<StudentListPage>();
            builder.Services.AddTransient<AddUpdateStudentDetail>();


            //ViewModels Registration
            builder.Services.AddSingleton<StudentListpageViewModel>();
            builder.Services.AddTransient<AddUpdateStudentDetailViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
