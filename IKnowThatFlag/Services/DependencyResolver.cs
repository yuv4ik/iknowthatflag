using System;
using Autofac;

namespace IKnowThatFlag.Services
{
    public class DependencyResolver
    {
        static IContainer container;

        public DependencyResolver(params Module[] modules)
        {
            var builder = new ContainerBuilder();

            if (modules != null)
                foreach (var module in modules)
                    builder.RegisterModule(module);

            container = builder.Build();
        }

        public T Resolve<T>() => container.Resolve<T>();
        public object Resolve(Type type) => container.Resolve(type);
    }
}
