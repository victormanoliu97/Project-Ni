using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ni.Core.Requests;
using Ni.Core.Services;

namespace Ni.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : Controller
    {
        private IUserService _userService;

        public AccountsController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public JsonResult Post([FromBody] AddUserRequest request)
        {
            return Json(_userService.AddUser(request));
        }
    }
}
