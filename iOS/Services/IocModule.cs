using Autofac;
using IKnowThatFlag.Services;

namespace IKnowThatFlag.iOS.Services
{
    public class IocModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SqliteFileAccessHelper>().As<ISqliteFileAccessHelper>().SingleInstance();
        }
    }
}
