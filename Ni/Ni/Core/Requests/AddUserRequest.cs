using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ni.Core.Requests
{
    public class AddUserRequest
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
