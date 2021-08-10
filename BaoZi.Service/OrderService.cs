using BaoZi.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoZi.Service
{
    public class OrderService : IOrderService
    {
        public string CreateOrder()
        {
            return "下单成功";
        }
    }
}
