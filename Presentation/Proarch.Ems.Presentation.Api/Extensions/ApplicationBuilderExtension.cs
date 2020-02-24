using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Proarch.Ems.Infrastructure.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proarch.Ems.Presentation.Api.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static void EnsureSeed(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

            using var context = serviceScope.ServiceProvider.GetService<EmsDbContext>();

            context.Database.Migrate();
        }
    }
}
