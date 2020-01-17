using System;
using Autofac;

namespace Persistence
{
    public class PersistenceMain : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<QualityAssurance>().As<IQualityAssuranceMicro>()
            //    .InstancePerLifetimeScope();
        }
    }
}
