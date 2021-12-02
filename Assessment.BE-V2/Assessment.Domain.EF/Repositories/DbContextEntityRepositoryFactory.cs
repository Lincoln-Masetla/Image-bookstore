using Assessment.Domain.EF.Contexts;
using Assessment.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.Domain.EF.Repositories
{
    public sealed class DbContextEntityRepositoryFactory : IEntityRepositoryFactory
    {
        private readonly IServiceProvider _provider;

        public DbContextEntityRepositoryFactory(IServiceProvider provider)
        {
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
        }


        public IEntityRepository CreateRepository()
        {
            var options = _provider.GetService(typeof(DbContextOptions)) as DbContextOptions;

            return new DbContextRepository(new AssessmentDbContext(options));
        }
    }
}
