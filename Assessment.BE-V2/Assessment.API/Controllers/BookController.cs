using Assessment.Domain.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assessment.Domain.UseCases.Books;

namespace Assessment.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookController : ControllerBase
	{
		private readonly DomainContext domainContext;

		public BookController(DomainContext domainContext)
		{
			this.domainContext = domainContext;
		}

		[Authorize]
		[HttpGet]
		public async Task<IActionResult> GetAsync()
		{
			var books = new GetAll(domainContext);
			var results = await books.ExecuteAsync();
			return Ok(results);
		}

	}
}
