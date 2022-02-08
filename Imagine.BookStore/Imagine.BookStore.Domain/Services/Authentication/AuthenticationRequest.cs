using System.ComponentModel.DataAnnotations;

namespace Imagine.BookStore.Domain.Services.Authentication;
public class AuthenticationRequest
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}
