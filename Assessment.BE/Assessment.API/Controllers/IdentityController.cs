using Assessment.Core.Services.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Assessment.API.ViewModels;
using System.Security.Principal;
using Assessment.Core.Services.IdentityService;

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
