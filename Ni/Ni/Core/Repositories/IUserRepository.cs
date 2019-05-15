using Ni.Core.Entities;

namespace Ni.Repositories
{
    public interface IUserRepository
    {

        User GetUserById(int id);
        User GetUserByEmail(string email);
        void AddUser(string email, string username, string password);
    }
}