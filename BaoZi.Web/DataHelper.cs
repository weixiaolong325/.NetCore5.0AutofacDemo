using BaoZi.Core;
using BaoZi.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaoZi.Web
{
    public class DataHelper
    {
        //手动注入UserService
        private static IUserService userService = IocManager.Resolve<IUserService>();
        public static string GetData()
        {
            return userService.GetUserName();
        }
    }
}
