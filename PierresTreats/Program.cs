using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PierresTreats.Models;

namespace PierresTreats
{
  class Program
  {
    static void Main(string[] args)
    {

      WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

      builder.Services.AddControllersWithViews();

      builder.Services.AddDbContext<PierresTreatsContext>(
                        dbContextOptions => dbContextOptions
                          .UseMySql(
                            builder.Configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(builder.Configuration["ConnectionStrings:DefaultConnection"]
                          )
                        )
                      );

      WebApplication app = builder.Build();

      app.UseHttpsRedirection();
      app.UseStaticFiles();

      app.UseRouting();

      app.MapControllerRoute(
          name: "default",
          pattern: "{controller=Home}/{action=Index}/{id?}");

      app.Run();
    }
  }
}