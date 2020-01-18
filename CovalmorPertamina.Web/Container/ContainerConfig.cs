using Autofac;
using System.Linq;
using CovalmorPertamina.Entity;
using System.Reflection;

namespace CovalmorPertamina.Web.Container
{
    public static class ContainerConfig
    {

        public static ContainerBuilder Configure()
        {
            ContainerBuilder builder = new ContainerBuilder();

            /*
             * @description : Load container or implement interface DBCovalmor
             */
            builder.RegisterType<CovalmorContext>().As<IDBCovalmor>();


            /*
             * @description : Load container or implement interface CovalmorPertamina.Entity.Repository
             */
            builder.RegisterAssemblyTypes(Assembly.Load("CovalmorPertamina.Entity"))
                .Where(t => t.Namespace.Contains("Repository"))
                .AsImplementedInterfaces();
            builder.RegisterType<EntityFactory>().As<IEntityFactory>();


            /*
             * @description : Load container or implement interface CovalmorPertamina.Common.Service
             */
            builder.RegisterAssemblyTypes(Assembly.Load("CovalmorPertamina.Common"))
                .Where(t => t.Namespace.Contains("Services"))
                .AsImplementedInterfaces();
            

            return builder;
        }
    }
}