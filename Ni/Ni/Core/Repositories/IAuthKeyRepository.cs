using Ni.Core.Entities;

namespace Ni.Repositories
{
    public interface IAuthKeyRepository
    {
        AuthKey GenerateAuthKey(string email, string password);
        bool Validate(int userId, string authKey);
    }
}