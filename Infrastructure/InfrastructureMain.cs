using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

namespace Infrastructure
{
    public class InfrastructureMain : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<QualityAssurance>().As<IQualityAssuranceMicro>()
            //    .InstancePerLifetimeScope();
        }
    }
}
