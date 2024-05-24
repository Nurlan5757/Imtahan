using Imtahan.DAL;
using Imtahan.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Imtahan
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
           
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<FreshContext>(opt =>
            opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));


            builder.Services.AddIdentity<AppUser, IdentityRole> (opt =>
            {
                opt.Password.RequiredLength = 6;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireDigit = true;
                opt.Password.RequireLowercase = true;
                opt.Password.RequireUppercase = false;
                opt.User.RequireUniqueEmail = true;

            })
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<FreshContext>();


            var app = builder.Build();
            

			                      
			app.UseStaticFiles();

			app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Chefs}/{action=Index}/{id?}"
            );

            app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
