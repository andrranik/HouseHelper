using Autofac;
using HouseHelper.DataStorage.Repositories.Implementation;
using HouseHelper.DataStorage.Repositories.Interfaces;

namespace HouseHelper.DataStorage
{
    public class DataStorageModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(DataStorageModule).Assembly)
                .Where(x => x.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();
        }
    }
}