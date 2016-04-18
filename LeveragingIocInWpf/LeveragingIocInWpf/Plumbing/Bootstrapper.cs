using Castle.Facilities.TypedFactory;
using Castle.Windsor;
using Castle.Windsor.Installer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeveragingIocInWpf.Plumbing
{
    internal static class Bootstrapper
    {
        private static IWindsorContainer container;

        internal static IWindsorContainer InitializeContainer()
        {
            container = new WindsorContainer();
            container.AddFacility<TypedFactoryFacility>();
            container.Install(FromAssembly.This());
            return container;
        }
    }
}
