using Imagine.BookStore.Application.Features.Subscriptions.Commands.CreateSubscription;
using Imagine.BookStore.Application.Features.Subscriptions.Commands.DeleteSubscription;
using Imagine.BookStore.Application.Features.Subscriptions.Queries.GetBooks;
using Imagine.BookStore.Application.Features.Subscriptions.Queries.GetUserSubscriptions;
using Imagine.BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace Imagine.BookStore.Controllers
{
    public class BookStoreController : BaseController
    {
        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var dtos = await Mediator.Send(new GetBookListQuery());
            return Ok(await Task.FromResult(dtos));
        }

        [HttpGet("subscriptions/{id}")]
        public async Task<IActionResult> GetSubscriptions([FromRoute] Guid id)
        {
            var dtos = await Mediator.Send(new GetUserSubscriptionListQuery { UserId = id });
            return Ok(await Task.FromResult(dtos));
        }

        [HttpPost("subscriptions/Create")]
        public async Task<IActionResult> CreateSubscription([FromBody] SubscriptionModel model)
        {
            var command = new CreateSubscriptionCommand
            {
                BookId = model.BookId,
                UserId  = model.UserId
            };
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("subscriptions/Delete")]
        public async Task<IActionResult> DeleteSubscription([FromBody] SubscriptionModel model)
        {
            var command = new DeleteSubscriptionCommand
            {
                BookId = model.BookId,
                UserId  = model.UserId
            };
            var response = await Mediator.Send(command);
            return Ok(response);
        }
    }
}
