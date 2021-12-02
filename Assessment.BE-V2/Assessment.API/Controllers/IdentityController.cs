using Assessment.API.Models;
using Assessment.Domain.Services.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class IdentityController : ControllerBase
	{
		private readonly IIdentityService _identityService;

		public IdentityController(IIdentityService identityService)
		{
			_identityService = identityService;
		}


		[HttpPost("login")]
		public async Task<IActionResult> Login(LoginModel model)
		{
			var results = await _identityService.Login(model.Username, model.Password);
			if (results == null)
			{
				return BadRequest();
			}
			return Ok(results);
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register(RegisterModel model)
		{
			var results = await _identityService.Register(model.Username, model.Password, model.Email, model.Role);

			if (results == null)
			{
				return BadRequest();
			}
			return Ok(results);
		}
	}
}
