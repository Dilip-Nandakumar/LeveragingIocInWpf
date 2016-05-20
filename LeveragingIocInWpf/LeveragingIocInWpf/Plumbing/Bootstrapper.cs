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
            container.AddFacility<TypedFactoryFacility>(); // Provides automatically generated factories
            container.Install(FromAssembly.This()); /* Instantiates the installers that implements IWindsorInstaller in this assesmbly
                                                       and invokes the constructor */
            return container;
        }
    }
}
