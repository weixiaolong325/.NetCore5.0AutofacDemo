using BaoZi.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoZi.IService
{
    public interface IOrderService: ITransitDenpendency
    {
        public string CreateOrder();
    }
}
