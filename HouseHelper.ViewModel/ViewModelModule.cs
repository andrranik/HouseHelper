using Autofac;

namespace HouseHelper.ViewModel
{
    public class ViewModelModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(ViewModelModule).Assembly)
                .Where(x => x.Name.EndsWith("ViewModel"));
        }
    }
}