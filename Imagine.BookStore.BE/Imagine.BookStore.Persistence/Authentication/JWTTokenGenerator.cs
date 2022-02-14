using Imagine.BookStore.Application.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Imagine.BookStore.Persistence.Authentication;

public class JWTTokenGenerator : IJWTTokenGenerator
{
	private readonly IConfiguration _config;

	public JWTTokenGenerator(IConfiguration config)
	{
		_config = config;

	}
	public string GenerateToken(IdentityUser user, IList<Claim> claims)
	{
		claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));

		var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["ConnectionStrings:Key"]));

		var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

		var tokenDescriptor = new SecurityTokenDescriptor
		{
			Subject = new ClaimsIdentity(claims),
			Expires = DateTime.Now.AddDays(7),
			SigningCredentials = creds,
			Issuer = _config["ConnectionStrings:Issuer"],
		};

		var tokenHandler = new JwtSecurityTokenHandler();

		var token = tokenHandler.CreateToken(tokenDescriptor);

		return tokenHandler.WriteToken(token);
	}
}
