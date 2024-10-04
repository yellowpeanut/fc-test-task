using fc_test_task.Data;
using fc_test_task.Interfaces.Reposiroties;
using fc_test_task.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace FcTestTask.Tests;

internal class FcTestTaskWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.RemoveAll(typeof(ApplicationContext));
            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseInMemoryDatabase("TestDB");
            });

            var serviceProvider = services.BuildServiceProvider();
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
                
                context.Database.EnsureDeleted();
            }
        });
    }
}
