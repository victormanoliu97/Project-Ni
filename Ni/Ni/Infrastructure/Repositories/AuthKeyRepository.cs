using Ni.Core.Entities;
using Ni.Repositories;
using System.Linq;

namespace Ni.Infrastructure.Repositories
{
    public class AuthKeyRepository : IAuthKeyRepository
    {
        private AppDbContext _appDbContext;
        private IUserRepository _userRepository;


        public AuthKeyRepository(AppDbContext appDbContext, IUserRepository userRepository)
        {
            _appDbContext = appDbContext;
            _userRepository = userRepository;
        }
        public AuthKey GenerateAuthKey(string email, string password)
        {
            User user = _userRepository.GetUserByEmail(email);
            if (user == null) return null;

            string hash = SHAHasher.ComputeSha256Hash(RandomStringGenerator.CreateString(256));
            AuthKey authKey = new AuthKey()
            {
                UserId = user.Id,
                Key = hash
            };
            _appDbContext.AuthKeys.Add(authKey);
            _appDbContext.SaveChanges();
            return authKey;
        }

        public bool Validate(int userId, string authKey)
        {
            var query = from entity in _appDbContext.AuthKeys
                        where entity.UserId == userId && entity.Key == authKey
                        select entity;
            if (query.FirstOrDefault() != null)
                return true;
            return false;
        }
    }
}