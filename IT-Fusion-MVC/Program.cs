using IT_Fusion_MVC.Services;
using IT_Fusion_MVC.Services.IServices;
using IT_Fusion_MVC.Utilities;

namespace IT_Fusion_MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IEmployeeService, EmployeeService>();

            Constants.ITFusionBaseUrl = builder.Configuration["ServiceUrls:ITFusion_BaseUrl"]!;

            builder.Services.AddControllers();

            builder.Services.AddAutoMapper(typeof(MappingConfig));


            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Employee}/{action=Index}");

            app.Run();
        }
    }
}
