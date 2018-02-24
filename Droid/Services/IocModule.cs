using Autofac;
using IKnowThatFlag.Services;

namespace IKnowThatFlag.Droid.Services
{
    public class IocModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SqliteFileAccessHelper>().As<ISqliteFileAccessHelper>().SingleInstance();
        }
    }
}
