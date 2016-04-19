using Castle.Core;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using LeveragingIocInWpf.Interfaces;
using LeveragingIocInWpf.Interfaces.ViewModels;
using LeveragingIocInWpf.ViewModels;
using LeveragingIocInWpf.Plumbing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeveragingIocInWpf.Installers
{
    public class ViewsInstaller : IWindsorInstaller
    {
        #region Member Variables
        private const string UIAssemblyName = "LeveragingIocInWpf";
        private IWindsorContainer _container;
        #endregion

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            this._container = container;
            this.RegisterViews();
            this.RegisterViewModels();
        }

        private void RegisterViews()
        {
            this._container.Register(
                 Component.For<ITypedFactoryComponentSelector>().ImplementedBy<ViewSelector>(),

                  Castle.MicroKernel.Registration.Classes.FromAssemblyNamed(UIAssemblyName)
                  .BasedOn(typeof(IView))
                  .WithService.FromInterface()
                  .Configure(c => c.LifeStyle.Is(LifestyleType.Transient)
                  .Activator<ViewActivator>()),

             Component.For<IViewFactory>().AsFactory(c => c.SelectedWith<ViewSelector>()).LifestyleSingleton()
         );
        }

        private void RegisterViewModels()
        {
            this._container.Register(
                Component.For<IEmployeeRegistrationViewModel>()
                .ImplementedBy(typeof(EmployeeRegistrationViewModel)).LifestyleScoped<CustomScopeAccessor>(),

                 Castle.MicroKernel.Registration.Classes.FromAssemblyNamed(UIAssemblyName)
                  .BasedOn(typeof(IViewModel))
                  .WithService.FromInterface()
                  .Configure(c => c.LifeStyle.Is(LifestyleType.Transient)));
        }
    }
}
