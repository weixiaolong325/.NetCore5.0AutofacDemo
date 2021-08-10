using Autofac;
using BaoZi.Core;
using BaoZi.Repository;
using BaoZi.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaoZi.Web
{
    public class AutofacRegisterModule:Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //获取所有控制器类型并使用属性注入
            Type[] controllersTypeAssembly = typeof(Startup).Assembly.GetExportedTypes()
                .Where(type => typeof(ControllerBase).IsAssignableFrom(type)).ToArray();
            builder.RegisterTypes(controllersTypeAssembly).PropertiesAutowired(new AutowiredPropertySelector());

            //批量自动注入,把需要注入层的程序集传参数
            builder.BatchAutowired(typeof(UserService).Assembly);
            builder.BatchAutowired(typeof(UserRepository).Assembly);
        }
    }
}
