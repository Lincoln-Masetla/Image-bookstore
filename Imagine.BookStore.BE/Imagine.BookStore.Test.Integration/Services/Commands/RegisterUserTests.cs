using FluentAssertions;
using Imagine.BookStore.Domain.Entities;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Imagine.BookStore.Test.Integration.Services.Commands
{

    using static Testing;

    public class RegisterUserTests : TestBase
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

            user.Should().NotBeNull();
            user.UserName.Should().Be(userReq.UserName);
            user.Email.Should().Be(userReq.UserName);
        }


    }
}
