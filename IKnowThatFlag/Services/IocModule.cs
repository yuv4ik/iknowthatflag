using Autofac;
using IKnowThatFlag.Repositories;
using IKnowThatFlag.ViewModels;

namespace IKnowThatFlag.Services
{
    public class IocModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // View Models
            builder.RegisterType<WelcomeViewModel>().AsSelf();
            builder.RegisterType<GameViewModel>().AsSelf();
            builder.RegisterType<TopScoreViewModel>().AsSelf();
            builder.RegisterType<AboutViewModel>().AsSelf();

            // Services
            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            builder.RegisterType<GameService>().As<IGameService>().SingleInstance();
            builder.RegisterType<FlagsRepository>().AsSelf().SingleInstance();
            builder.RegisterType<TopScoreRepository>().AsSelf().SingleInstance();
            builder.RegisterType<TypeMapperService>().As<ITypeMapperService>().SingleInstance();
        }
    }
}
