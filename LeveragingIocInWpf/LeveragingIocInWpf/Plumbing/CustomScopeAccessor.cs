using Castle.MicroKernel.Lifestyle.Scoped;
using System;
using System.Collections.Concurrent;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeveragingIocInWpf.Plumbing
{
    class CustomScopeAccessor : IScopeAccessor
    {
        private static readonly ConcurrentDictionary<Guid, ILifetimeScope> Collection = new ConcurrentDictionary<Guid, ILifetimeScope>();

        public ILifetimeScope GetScope(Castle.MicroKernel.Context.CreationContext context)
        {
            return Collection.GetOrAdd((Guid)Application.Current.Resources["ScopeId"], id => new DefaultLifetimeScope());
        }

        public void Dispose()
        {
            foreach (var scope in Collection)
            {
                scope.Value.Dispose();
            }

            Collection.Clear();
        }
    }
}
