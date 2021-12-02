using Assessment.API.ViewModels;
using Assessment.Core;
using Assessment.Core.Data.Entities;
using Assessment.Core.Services.Subscribtions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Assessment.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SubscriptionController : ControllerBase
	{

		private readonly ISubscriptionService _subscription;

		public SubscriptionController(ISubscriptionService subscription)
		{
			_subscription = subscription;
		}

		[Authorize]
		[HttpGet("{id}")]
		public IActionResult Get([FromRoute] Guid id)
		{
			return Ok(_subscription.Get(id));
		}

		[Authorize]
		[HttpPost]
		public IActionResult Add([FromBody] SubscriptionRequestModel request)
		{
			var added = _subscription.Add(request.UserId, request.BookId);

			if (!added)
			{
				return BadRequest();
			}
			return Ok();
		}

		[Authorize]
		[HttpPost(nameof(Unsubscribe))]
		public IActionResult Unsubscribe([FromBody] SubscriptionRequestModel request)
		{
			var deleted = _subscription.Delete(request.UserId, request.BookId);
			if (!deleted)
				BadRequest();

			return Ok();
		}
	}
}
