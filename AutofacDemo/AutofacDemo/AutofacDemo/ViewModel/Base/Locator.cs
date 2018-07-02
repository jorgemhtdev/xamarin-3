namespace AutofacDemo.ViewModel.Base
{
    using Services.Authentication;
    using Services.Doctor;
    using Services.Navigation;
    using Services.Speciality;
    using Autofac;
    using System;

    public class Locator
    {
        private IContainer container;
        private readonly ContainerBuilder containerBuilder;

        private static readonly Locator instance = new Locator();

        public static Locator Instance => instance;

        public Locator()
        {
            containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<NavigationService>().As<INavigationService>();
            containerBuilder.RegisterType<FakeAuthenticationService>().As<IAuthenticationService>();
            containerBuilder.RegisterType<FakeDoctorServices>().As<IDoctorServices>();
            containerBuilder.RegisterType<FakeSpecialityServices>().As<ISpecialtyServices>();

            containerBuilder.RegisterType<MainViewModel>();
            containerBuilder.RegisterType<MenuViewModel>();
            containerBuilder.RegisterType<DoctorViewModel>();
            containerBuilder.RegisterType<SpecialityViewModel>();
            containerBuilder.RegisterType<HomeViewModel>();
            containerBuilder.RegisterType<LoginViewModel>();
            containerBuilder.RegisterType<ProfileViewModel>();
            containerBuilder.RegisterType<ExtendedSplashViewModel>();
        }

        public T Resolve<T>() => container.Resolve<T>();
        public object Resolve(Type type) => container.Resolve(type);
        public void Register<TInterface, TImplementation>() where TImplementation : TInterface => containerBuilder.RegisterType<TImplementation>().As<TInterface>();
        public void Register<T>() where T : class => containerBuilder.RegisterType<T>();
        public void Build() => container = containerBuilder.Build();
    }
}
