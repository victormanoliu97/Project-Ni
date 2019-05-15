using Ni.Core.Entities;
using Ni.Core.Requests;
using Ni.Core.Responses;
using Ni.Core.Services;
using Ni.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ni.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public GenericResponse AddUser(AddUserRequest request)
        {
            GenericResponse response = new GenericResponse();
            response.Errors = new List<string>();
            if (_userRepository.GetUserByEmail(request.Email) != null)
            {
                response.StatusCode = 400;
                response.Errors.Add("Email Already exists");
                return response;
            }
            _userRepository.AddUser(request.Email, request.Username, request.Password);
            response.StatusCode = 200;
            return response;
        }
    }
    public class AuthService : IAuthService
    {
        private IUserRepository _userRepository;
        private IAuthKeyRepository _authKeyRepository;

        public AuthService(IUserRepository userRepository, IAuthKeyRepository authKeyRepository)
        {
            _userRepository = userRepository;
            _authKeyRepository = authKeyRepository;
        }

        public AuthResponse Auth(AuthRequest request)
        {
            AuthResponse response = new AuthResponse();
            response.Errors = new List<string>();
            response.StatusCode = 200;
            User user = _userRepository.GetUserByEmail(request.Email);
            if (user == null)
            {
                response.StatusCode = 400;
                response.Errors.Add("Account does not exist");
                return response;
            }
            if (SHAHasher.ComputeSha256Hash(user.PasswordHash + request.Password) != user.PasswordHashed)
            {
                response.StatusCode = 400;
                response.Errors.Add("Passwords do not match");
            }
            if (response.StatusCode != 200)
                return response;

            AuthKey authkey = _authKeyRepository.GenerateAuthKey(request.Email, request.Password);
            response.StatusCode = 200;
            response.AuthKey = authkey.Key;
            response.UserId = authkey.UserId;
            return response;
        }
    }
}
