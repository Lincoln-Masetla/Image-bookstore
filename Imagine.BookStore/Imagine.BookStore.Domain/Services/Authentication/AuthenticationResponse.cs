using System.Text.Json.Serialization;

namespace Imagine.BookStore.Domain.Services.Authentication;
public class AuthenticationResponse
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string JWToken { get; set; }
    [JsonIgnore]
    public string RefreshToken { get; set; }
}
