using Autofac;
using Xamarin_assignment.Services;
using Xamarin_assignment.Services.Interfaces;

namespace Xamarin_assignment.DIContainer
{
    public class AppContainer
    {
        public static IContainer _container;

        public static void ConfigureServices()
        {
            var appBuilder = new ContainerBuilder();

            appBuilder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            //appBuilder.RegisterType<UserService>().As<IUserService>().SingleInstance();
        }
    }
}
