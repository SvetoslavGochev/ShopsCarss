namespace ShopsCarss.Infrastructure
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using ShopsCarss.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PreparateDatabase(this IApplicationBuilder app)
        {
            using var scopesScope = app.ApplicationServices.CreateScope();

            var services = scopesScope.ServiceProvider;

            MigrateDatabase(services);



            return app;
        }

        private static void MigrateDatabase(IServiceProvider services)
        {
            var data = services.GetRequiredService<ApplicationDbContext>();
            data.Database.Migrate();
        }
    }
}
