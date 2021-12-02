using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Assessment.Domain.Services.Token
{
	public interface IJWTTokenGenerator
	{
		string GenerateToken(IdentityUser user, IList<string> roles, IList<Claim> claims);
	}
}
