using BaoZi.Core;
using BaoZi.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoZi.Service
{
    public class UserService :IUserService
    {
        public string GetUserName()
        {
            return "张三";
        }
    }
}
