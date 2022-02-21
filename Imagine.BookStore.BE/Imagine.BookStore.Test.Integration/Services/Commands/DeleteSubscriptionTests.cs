using FluentAssertions;
using Imagine.BookStore.Application.Features.Subscriptions.Commands.CreateSubscription;
using Imagine.BookStore.Application.Features.Subscriptions.Commands.DeleteSubscription;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Imagine.BookStore.Test.Integration.Services.Commands
{
    using static Testing;

    public class DeleteSubscriptionTests : TestBase
    {

        [Test]
        public async Task ShouldCreateTodoItem()
        {
            var user = await RunAsDefaultUserAsync();

            var book = await CreateBookAsync();

            var command = new CreateSubscriptionCommand
            {
                BookId = book.Id,
                UserId = user.Id,
            };

            var bookResponse = await SendAsync(command);

            var deleteCommand = new DeleteSubscriptionCommand
            {
                BookId = book.Id,
                UserId = user.Id,
            };

            var response = await SendAsync(deleteCommand);

            response.Should().NotBeNull();
            response.Success.Should().Be(true);
        }


    }
}
