using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Imagine.BookStore.Application.Contracts
{
	public interface IJWTTokenGenerator
	{
		string GenerateToken(IdentityUser user, IList<Claim> claims);
	}
}
