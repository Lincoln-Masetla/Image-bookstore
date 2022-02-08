using Imagine.BookStore.Domain.Common;
using Imagine.BookStore.Domain.Services.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagine.BookStore.Application.Contracts.Persistence
{
    public interface IAuthenticationService
    {
        Task<BaseResponse<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request);
        Task<BaseResponse<string>> RegisterAsync(RegistrationRequest request, string origin);
    }
}
