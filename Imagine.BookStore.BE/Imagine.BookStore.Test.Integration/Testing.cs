using Imagine.BookStore.Application.Contracts.Persistence;
using Imagine.BookStore.Domain.Entities;
using Imagine.BookStore.Persistence.Context;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using Respawn;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Imagine.BookStore.Test.Integration
{
    [SetUpFixture]
    public class Testing
    {
        private static IConfigurationRoot _configuration = null!;
        private static IServiceScopeFactory _scopeFactory = null!;
        private static Checkpoint _checkpoint = null!;
        private static Guid? _currentUserId;

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables();

            _configuration = builder.Build();

            var startup = new Startup(_configuration);

            var services = new ServiceCollection();

            services.AddSingleton(Mock.Of<IWebHostEnvironment>(w =>
                w.EnvironmentName == "Development" &&
                w.ApplicationName == "Imagine.BookStore"));

            services.AddLogging();

            startup.ConfigureServices(services);

            _scopeFactory = services.BuildServiceProvider().GetRequiredService<IServiceScopeFactory>();

            _checkpoint = new Checkpoint
            {
            };

            EnsureDatabase();
        }

        private static void EnsureDatabase()
        {
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        }

        public static async Task<Book> CreateBookAsync()
        {
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            var book = new Book
            {
                Id = Guid.NewGuid(),
                Name =  Guid.NewGuid().ToString(),
                PurchasePrice = 50M
            };

            context.Add(book);
            await context.SaveChangesAsync();

            return book;
        }

        public static async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            using var scope = _scopeFactory.CreateScope();

            var mediator = scope.ServiceProvider.GetRequiredService<ISender>();

            return await mediator.Send(request);
        }

        public static async Task<ApplicationUser> RunAsDefaultUserAsync()
        {
            return await RunAsUserAsync($"{Guid.NewGuid()}test@local", "Testing1234!");
        }

        public static async Task<ApplicationUser> RunAsAdministratorAsync()
        {
            return await RunAsUserAsync($"{Guid.NewGuid()}administrator@local", "Administrator1234!");
        }

        public static async Task<ApplicationUser> RunAsUserAsync(string userName, string password)
        {
            using var scope = _scopeFactory.CreateScope();

            var userManager = scope.ServiceProvider.GetRequiredService<IIdentityService>();

            var user = new ApplicationUser { UserName = userName, Email = userName };

            var result = await userManager.Register(userName, password, userName);

            if (result.Succeeded)
            {
                _currentUserId = user.Id;
                return user;
            }

            throw new Exception($"Unable to create {userName}.{Environment.NewLine}");
        }

        public static async Task<Object> LoginAsync(string userName, string password)
        {
            using var scope = _scopeFactory.CreateScope();

            var userManager = scope.ServiceProvider.GetRequiredService<IIdentityService>();

            var result = await userManager.Login(userName, password);

            return result;

        }

        public static async Task ResetState()
        {
            // todo point to dev database
            //await _checkpoint.Reset(_configuration.GetConnectionString("DefaultConnection"));

            //_currentUserId = null;
        }

        public static async Task<TEntity?> FindAsync<TEntity>(params object[] keyValues)
            where TEntity : class
        {
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            return await context.FindAsync<TEntity>(keyValues);
        }

        public static async Task AddAsync<TEntity>(TEntity entity)
            where TEntity : class
        {
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            context.Add(entity);

            await context.SaveChangesAsync();
        }

        public static async Task<int> CountAsync<TEntity>() where TEntity : class
        {
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            return await context.Set<TEntity>().CountAsync();
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
        }
    }

}
