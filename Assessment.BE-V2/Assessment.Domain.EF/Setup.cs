using Assessment.Domain.EF.Contexts;
using Assessment.Domain.EF.Repositories;
using Assessment.Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Assessment.Domain.EF
{
    public static class Setup
    {
        public static void AddDatabaseDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEntityRepositoryFactory, DbContextEntityRepositoryFactory>();
            services.AddScoped<AssessmentDbContext, AssessmentDbContext>();
            services.AddScoped<IEntityRepository, DbContextRepository>();
        }
    }
}
