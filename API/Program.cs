using Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistence;
using System;
using System.Threading.Tasks;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            // every time we run the app, we check if we've a database and run the migrations.
            // if we don't have a db, the sys will create one and run the migrations
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<DataContext>();
                    context.Database.Migrate();
                    var userManager = services.GetRequiredService<UserManager<AppUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                    bool superAdminRoleExists = await roleManager.RoleExistsAsync("Manager").ConfigureAwait(false);
                    if (!superAdminRoleExists)
                    {
                        var roleResult = await roleManager.CreateAsync(new IdentityRole
                        {
                            Name = "Manager"
                        });
                    }
                    bool adminRoleExists = await roleManager.RoleExistsAsync("Admin").ConfigureAwait(false);
                    if (!adminRoleExists)
                    {
                        var roleResult = await roleManager.CreateAsync(new IdentityRole
                        {
                            Name = "Admin"
                        });
                    }
                    bool user = await roleManager.RoleExistsAsync("User").ConfigureAwait(false);
                    if (!user)
                    {
                        var roleResult = await roleManager.CreateAsync(new IdentityRole
                        {
                            Name = "User"
                        });
                    }

                    //Seed.SeedData(context, userManager).Wait();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();

                    logger.LogError("Error occurred during migration: " + ex);
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}