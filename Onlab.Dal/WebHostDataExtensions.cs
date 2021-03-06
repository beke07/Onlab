﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onlab.Dal
{
    public static class WebHostDataExtensions
    {
        public static IWebHost MigrateDatabase<TContext>(this IWebHost host)
        where TContext : DbContext
        {
            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var context = serviceProvider.GetRequiredService<TContext>();
                context.Database.Migrate();
            }
            return host;
        }
    }
}
