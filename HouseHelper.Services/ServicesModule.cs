using Autofac;

namespace HouseHelper.Services
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(ServicesModule).Assembly)
                .Where(x => x.Name.EndsWith("Service"))
                .AsImplementedInterfaces();;
        }
    }
}