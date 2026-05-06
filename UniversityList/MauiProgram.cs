using Microsoft.Extensions.Logging;
using SQLite;
using UniversityList.Interfaces;
using UniversityList.Services;
using UniversityList.ViewModels;
using UniversityList.Views;

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
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Student.db3");
            builder.Services.AddSingleton(new SQLiteAsyncConnection(dbPath));
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
