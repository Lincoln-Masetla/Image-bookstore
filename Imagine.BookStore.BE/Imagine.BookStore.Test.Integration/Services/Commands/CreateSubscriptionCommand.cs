using FluentAssertions;
using Imagine.BookStore.Application.Features.Subscriptions.Commands.CreateSubscription;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Imagine.BookStore.Test.Integration.Services.Commands
{
    using static Testing;

    public class CreateSubscriptionTests : TestBase
    {

        [Test]
        public async Task CreateSubscription()
        {
            var user = await RunAsDefaultUserAsync();

            var book = await CreateBookAsync();

            var command = new CreateSubscriptionCommand
            {
                BookId = book.Id,
                UserId = user.Id,
            };

            var response = await SendAsync(command);

            response.Should().NotBeNull();
            response.Subscription.UserId.Should().Be(command.UserId);
            response.Subscription.BookId.Should().Be(command.BookId);
        }


    }
}
