using System.ComponentModel.DataAnnotations;

namespace Imagine.BookStore.Models;

public class RegisterModel
{
	[Required]
	public string Username { get; set; }
	[Required]
	[EmailAddress]
	public string Email { get; set; }
	[Required]
	public string Password { get; set; }
}