using System;
using System.Reflection;
using System.Text;
using Castle.Facilities.TypedFactory;

namespace LeveragingIocInWpf.Plumbing
{
    class ViewSelector : DefaultTypedFactoryComponentSelector
    {
        #region Constants
        private const string DotSeperator = ".";
        private const string InterfacePrefix = "I";
        private const string ViewDirectory = "Interfaces.Views";
        private const string ViewSuffix = "View";
        #endregion

        protected override string GetComponentName(MethodInfo method, object[] arguments)
        {
            return null;
        }

        protected override Type GetComponentType(MethodInfo method, object[] arguments)
        {
            StringBuilder typeName = new StringBuilder();
            typeName.Append(Assembly.GetExecutingAssembly().GetName().Name);
            typeName.Append(DotSeperator);
            typeName.Append(ViewDirectory);
            typeName.Append(DotSeperator);
            typeName.Append(InterfacePrefix);
            typeName.Append(arguments[0]);
            typeName.Append(ViewSuffix);

            return Type.GetType(typeName.ToString());
        }
    }
}
