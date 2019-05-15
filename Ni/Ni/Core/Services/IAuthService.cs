using Ni.Core.Requests;
using Ni.Core.Responses;

namespace Ni.Core.Services
{
    public interface IAuthService
    {
        AuthResponse Auth(AuthRequest request);
    }
}