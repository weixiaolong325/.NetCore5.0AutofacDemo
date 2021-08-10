using BaoZi.Core;
using BaoZi.IService;
using BaoZi.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaoZi.Web.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;
        public UserController(IEnumerable<IUserService> userServices)
        {
            _userService = userServices.Where(u => u.GetType() == typeof(User2Service)).FirstOrDefault();
        }
        public IActionResult Index()
        {
            string name = _userService.GetUserName();
            return Content(name);
        }
    }
}
