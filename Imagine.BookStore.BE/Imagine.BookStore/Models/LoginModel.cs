﻿using System.ComponentModel.DataAnnotations;

namespace Imagine.BookStore.Models;

public class LoginModel
{
	[Required]
	[EmailAddress]
	public string Username { get; set; }
	[Required]
	public string Password { get; set; }
}