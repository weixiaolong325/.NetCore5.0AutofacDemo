using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BaoZi.Core
{
    public static class IocManager
    {
        private static object obj = new object();
        private static ILifetimeScope _container { get; set; }
       
        /// <summary>
        /// 批量注入扩展
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="assembly"></param>
        public static void BatchAutowired(this ContainerBuilder builder, Assembly assembly)
        {

            var transientType = typeof(ITransitDenpendency); //瞬时注入
            var singletonType = typeof(ISingletonDenpendency); //单例注入
            var scopeType = typeof(IScopeDenpendency); //单例注入
            //瞬时注入
            builder.RegisterAssemblyTypes(assembly).Where(t => t.IsClass && !t.IsAbstract && t.GetInterfaces().Contains(transientType))
                .AsSelf()
                .AsImplementedInterfaces()
                .InstancePerDependency()
                .PropertiesAutowired(new AutowiredPropertySelector());
            //单例注入
            builder.RegisterAssemblyTypes(assembly).Where(t => t.IsClass && !t.IsAbstract && t.GetInterfaces().Contains(singletonType))
               .AsSelf()
               .AsImplementedInterfaces()
               .SingleInstance()
               .PropertiesAutowired(new AutowiredPropertySelector());
            //生命周期注入
            builder.RegisterAssemblyTypes(assembly).Where(t => t.IsClass && !t.IsAbstract && t.GetInterfaces().Contains(scopeType))
               .AsSelf()
               .AsImplementedInterfaces()
               .InstancePerLifetimeScope()
               .PropertiesAutowired(new AutowiredPropertySelector());

        }
        public static void InitContainer(ILifetimeScope container)
        {
            //防止过程中方法被调用_container发生改变
            if (_container == null)
            {
                lock (obj)
                {
                    if (_container == null)
                    {
                        _container = container;
                    }
                }
            }
        }
        /// <summary>
        /// 手动获取实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }

}
