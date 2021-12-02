using Assessment.Core;
using Assessment.Core.Data.Entities;
using Assessment.Core.Services.Books;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookController : ControllerBase
	{
		private readonly IBookService _bookService;

		public BookController(IBookService bookService)
		{
			_bookService = bookService;
		}

		[Authorize]
		[HttpGet]
		public IActionResult Get()
		{
			return Ok(_bookService.GetAll());
		}
	}
}
