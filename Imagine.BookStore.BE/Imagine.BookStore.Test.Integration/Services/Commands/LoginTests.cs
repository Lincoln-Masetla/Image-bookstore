using FluentAssertions;
using Imagine.BookStore.Domain.Entities;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Imagine.BookStore.Test.Integration.Services.Commands
{

    using static Testing;

    public class LoginTests : TestBase
    {

        [Test]
        public async Task ShouldCreateTodoItem()
        {
            var userReq = new ApplicationUser
            {
                Email = $"{Guid.NewGuid()}administrator@local",
                UserName = $"{Guid.NewGuid()}administrator@local",
                Password = "Administrator1234!"
            };
            var user = await RunAsUserAsync(userReq.UserName, userReq.Password);

            var login = await LoginAsync(userReq.UserName, userReq.Password);

            login.Should().NotBeNull();
        }


    }
}
