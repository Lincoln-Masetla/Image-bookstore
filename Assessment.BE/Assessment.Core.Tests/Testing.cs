

using Assessment.API;
using Assessment.Core.Data.Entities;
using Assessment.Core.Services.Books;
using Assessment.Core.Services.IdentityService;
using Assessment.Core.Services.Subscribtions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using Respawn;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace Assessment.Core.Tests
{
    [SetUpFixture]
    public class Testing
    {
        private static IConfiguration Configuration;
        private static IServiceScopeFactory ScopeFactory;
        private static Checkpoint _checkpoint;
        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json", true, true)
             .AddEnvironmentVariables();

            Configuration = builder.Build();

            var services = new ServiceCollection();

            var startup = new Startup(Configuration);

            services.AddSingleton(Mock.Of<IWebHostEnvironment>(w => w.ApplicationName == "Assessment.API"));

            startup.ConfigureServices(services);

            ScopeFactory = services.BuildServiceProvider().GetService<IServiceScopeFactory>();

            _checkpoint = new Checkpoint
            {
                TablesToIgnore = new[] { "__EFMigrationsHistory" }
            };

            EnsureDatabase();
        }

        public static Book CreateBook(Book book)
		{
            using var scope = ScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<ApplicationDBContext>();
            context.Add(book);
            context.SaveChanges();
            return book;
        }

        public static IEnumerable<Book> GetAllBooks()
        {
            using var scope = ScopeFactory.CreateScope();

            var bookService = scope.ServiceProvider.GetService<IBookService>();

            return bookService.GetAll();
        }

        public static async Task<IdentityResult> CreateUserAsync(IdentityUser user, string password)
        {
            using var scope = ScopeFactory.CreateScope();
            var _userManager = scope.ServiceProvider.GetService<UserManager<IdentityUser>>();
            var result = await _userManager.CreateAsync(user, password);
            return result;
        }
        
        public static async Task<IdentityUser> GetUserAsync(string username)
        {
            using var scope = ScopeFactory.CreateScope();
            var _userManager = scope.ServiceProvider.GetService<UserManager<IdentityUser>>();
            var userFromDb = await _userManager.FindByNameAsync(username);
            return userFromDb;
        }

        public static void CreateSubscription(Guid userId, int bookId)
        {
            using var scope = ScopeFactory.CreateScope();
            var subscriptionService = scope.ServiceProvider.GetService<ISubscriptionService>();
            var subscription = subscriptionService.Add(userId, bookId);
        }

        public static async Task<IdentityResult> RegisterUserAsync(string username, string password, string email, string role)
        {
            using var scope = ScopeFactory.CreateScope();
            var identityService = scope.ServiceProvider.GetService<IIdentityService>();
            var identityResult = await identityService.Register(username, password, email, role);
            return identityResult;
        }

        

        public static void DeleteSubscription(Guid userId, int bookId)
        {
            using var scope = ScopeFactory.CreateScope();
            var subscriptionService = scope.ServiceProvider.GetService<ISubscriptionService>();
            var subscription = subscriptionService.Delete(userId, bookId);
        }
        

        public static IEnumerable<Data.Entities.Subscription> GetSubscriptions(Guid userId)
        {
            using var scope = ScopeFactory.CreateScope();
            var subscriptionService = scope.ServiceProvider.GetService<ISubscriptionService>();
            var subscriptions = subscriptionService.Get(userId);
            return subscriptions;
        }


        private void EnsureDatabase()
        {
            using var scope = ScopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetService<ApplicationDBContext>();

            context.Database.Migrate();
        }

        public static async Task ResetState()
        {
            // Still investigating the reset state. I am using sql lite but somehow this referrences sql server hence commented out. 
            var connectionString = Configuration.GetConnectionString("Default");
           // await _checkpoint.Reset(connectionString);
        }

    }
}