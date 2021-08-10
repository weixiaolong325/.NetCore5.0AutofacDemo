using BaoZi.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoZi.IService
{
   public interface IUserService: ITransitDenpendency
    {
        public string GetUserName();
        
    }
}
