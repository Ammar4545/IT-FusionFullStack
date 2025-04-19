using ADVA_FrontEnd.Services.IServices;
using ADVA_FrontEnd.Services;
using System.Text.Json.Serialization;
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

            SD.ITFusionBaseUrl = builder.Configuration["ServiceUrls:ITFusion_BaseUrl"]!;

            builder.Services.AddControllers();
            //.AddJsonOptions(options =>
            //{
            //    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            //});

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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
