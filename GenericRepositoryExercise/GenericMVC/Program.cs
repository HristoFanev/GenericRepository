using DataAccess.Abstract;
using DataAccess.Implementation;
using DataAccess.Model;

namespace GenericMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddMvc();
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IRepository<Animal>, GenericRepositoryImplementation<Animal>>();

            var app = builder.Build();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
                );

            app.Run();

        }
    }
}