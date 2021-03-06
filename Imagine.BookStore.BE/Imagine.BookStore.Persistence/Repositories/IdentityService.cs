using Imagine.BookStore.Application.Contracts;
using Imagine.BookStore.Application.Contracts.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace Imagine.BookStore.Persistence.Repositories
{
	public class IdentityService : IIdentityService
	{
		private readonly UserManager<IdentityUser> _userManager;
		private readonly SignInManager<IdentityUser> _signInManager;
		private readonly IJWTTokenGenerator _jwtToken;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly ILogger<IIdentityService> _logger;
		public IdentityService(
			  UserManager<IdentityUser> userManager,
			  SignInManager<IdentityUser> signInManager,
			  IJWTTokenGenerator jwtToken,
			  RoleManager<IdentityRole> roleManager,
			  ILogger<IIdentityService> logger)
		{
			_jwtToken = jwtToken;
			_roleManager = roleManager;
			_signInManager = signInManager;
			_userManager = userManager;
			_logger = logger;
		}

		public async Task<object> Login(string username, string password)
		{
			var userFromDb = await _userManager.FindByEmailAsync(username);

			if (userFromDb == null)
			{
				return null;
			}

			var result = await _signInManager.CheckPasswordSignInAsync(userFromDb, password, false);

			if (!result.Succeeded)
			{
				return null;
			}

			var roles = await _userManager.GetRolesAsync(userFromDb);

			IList<Claim> claims = await _userManager.GetClaimsAsync(userFromDb);
			return new
			{
				result = result,
				username = userFromDb.UserName,
				email = userFromDb.Email,
				Id = userFromDb.Id,
				token = _jwtToken.GenerateToken(userFromDb, claims)
			};
		}

		public async Task<IdentityResult> Register(string username, string password, string email)
		{
			var userToCreate = new IdentityUser
			{
				Email = email,
				UserName = username
			};

			//Create User
			var result = await _userManager.CreateAsync(userToCreate, password);

			if (!result.Succeeded)
				return null;

			return result;
		}
	}
}
