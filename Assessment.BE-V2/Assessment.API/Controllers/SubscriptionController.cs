using Assessment.API.Models;
using Assessment.Domain.Contexts;
using Assessment.Domain.UseCases.Subscriptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SubscriptionController : ControllerBase
	{
		private readonly DomainContext domainContext;

		public SubscriptionController(DomainContext domainContext)
		{
			this.domainContext = domainContext;
		}

		[Authorize]
		[HttpGet("{id}")]
		public async Task<IActionResult> GetAsync([FromRoute] Guid id)
		{
			var subscriptions = new GetAll(domainContext) 
			{ 
				UserId = id
			};
			var results = await subscriptions.ExecuteAsync();
			return Ok(results);
		}

		[Authorize]
		[HttpPost]
		public async Task<IActionResult> AddAsync([FromBody] SubscriptionRequestModel request)
		{
			var subscription = new Add(domainContext)
			{
				UserId = request.UserId,
				BookId = request.BookId
			};
			var results = await subscription.ExecuteAsync();
			return Ok(results);
		}

		[Authorize]
		[HttpPost(nameof(Unsubscribe))]
		public async Task<IActionResult> Unsubscribe([FromBody] SubscriptionRequestModel request)
		{
			var subscription = new Delete(domainContext)
			{
				UserId = request.UserId,
				BookId = request.BookId
			};
			var results = await subscription.ExecuteAsync();
			if (!results)
				return BadRequest();

			return Ok(results);
		}
	}
}
