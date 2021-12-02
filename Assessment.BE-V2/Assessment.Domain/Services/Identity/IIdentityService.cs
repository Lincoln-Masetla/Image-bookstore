using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Domain.Services.Identity
{
	public interface IIdentityService
	{
		Task<Object> Login(string Username, string password);
		Task<IdentityResult> Register(string Username, string password, string email, string role);
	}
}
