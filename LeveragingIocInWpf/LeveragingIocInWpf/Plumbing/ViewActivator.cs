using System.Linq;
using Castle.MicroKernel.ComponentActivator;
using Castle.Core;
using Castle.MicroKernel;
using System.Windows;
using LeveragingIocInWpf.Interfaces;

namespace LeveragingIocInWpf.Plumbing
{
    class ViewActivator : DefaultComponentActivator
    {
        public ViewActivator(ComponentModel model, IKernelInternal kernel, ComponentInstanceDelegate onCreation, ComponentInstanceDelegate onDestruction)
            : base(model, kernel, onCreation, onDestruction)
        {
        }

        protected override object CreateInstance(Castle.MicroKernel.Context.CreationContext context, ConstructorCandidate c, object[] arguments)
        {
            var component = base.CreateInstance(context, c, arguments);
            this.AssignViewModel(component, arguments);
            return component;
        }

        private void AssignViewModel(object component, object[] arguments)
        {
            var frameworkElement = component as FrameworkElement;
            if (frameworkElement == null || arguments == null)
            {
                return;
            }

            var vm = arguments.Where(a => a is IViewModel).FirstOrDefault();
            if (vm != null)
            {
                frameworkElement.DataContext = vm;
            }
        }
    }
}
