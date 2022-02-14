using Imagine.BookStore.Application.Contracts.Persistence;
using Imagine.BookStore.Domain.Services.Authentication;
using Imagine.BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace Imagine.BookStore.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
	private readonly IIdentityService _identityService;

	public AccountController(IIdentityService identityService)
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
		var results = await _identityService.Register(model.Username, model.Password, model.Email);

		if (results == null)
		{
			return BadRequest();
		}
		return Ok(results);
	}
}
