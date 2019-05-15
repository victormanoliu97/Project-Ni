using Ni.Core.Entities;
using Ni.Repositories;
using System.Linq;

namespace Ni.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddUser(string email, string username, string password)
        {
            string hash = SHAHasher.ComputeSha256Hash(RandomStringGenerator.CreateString(256));
            string hashedPassword = SHAHasher.ComputeSha256Hash(hash + password);
            User newAccount = new User()
            {
                Email = email,
                Username = username,
                PasswordHash = hash,
                PasswordHashed = hashedPassword
            };
            _appDbContext.Users.Add(newAccount);
            _appDbContext.SaveChanges();
        }

        public User GetUserByEmail(string email)
        {
            var query = from entity in _appDbContext.Users
                        where entity.Email.ToLower() == email.ToLower()
                        select entity;
            var result = query.ToList();
            if (result.Count >= 1)
                return result[0];
            return null;
        }

        public User GetUserById(int id)
        {
            var query = from entity in _appDbContext.Users
                        where entity.Id == id
                        select entity;
            var result = query.ToList();
            if (result.Count == 1)
                return result[0];
            return null;
        }
    }
}