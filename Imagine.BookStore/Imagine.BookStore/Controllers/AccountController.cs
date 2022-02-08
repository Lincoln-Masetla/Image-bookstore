using Imagine.BookStore.Application.Contracts.Persistence;
using Imagine.BookStore.Domain.Services.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Imagine.BookStore.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;
    public AccountController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("authenticate")]
    public async Task<IActionResult> AuthenticateAsync(AuthenticationRequest request)
    {
        return Ok(await _authenticationService.AuthenticateAsync(request));
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(RegistrationRequest request)
    {
        var origin = Request.Headers["origin"];
        return Ok(await _authenticationService.RegisterAsync(request, origin));
    }
}
