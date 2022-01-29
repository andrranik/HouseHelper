using Autofac;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using HouseHelper.DataStorage;
using HouseHelper.Services;
using HouseHelper.ViewModel;
using ReactiveUI;
using Splat.Autofac;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace HouseHelper.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var builder = new ContainerBuilder();
            builder.RegisterModule(new DataStorageModule());
            builder.RegisterModule(new ViewModelModule());
            builder.RegisterModule(new ServicesModule());
            var autofacResolver = builder.UseAutofacDependencyResolver();
            builder.RegisterInstance(autofacResolver);
            autofacResolver.InitializeReactiveUI();
            builder.RegisterAutoMapper(typeof(MainViewModel).Assembly);
            var container = builder.Build();
            autofacResolver.SetLifetimeScope(container);

            MainPage = new MainPage(container.Resolve<MainViewModel>());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}