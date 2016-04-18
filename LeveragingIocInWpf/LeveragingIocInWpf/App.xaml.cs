using System.Windows;
using LeveragingIocInWpf.Views;
using Castle.Windsor;
using LeveragingIocInWpf.Plumbing;
using LeveragingIocInWpf.Interfaces.Views;

namespace LeveragingIocInWpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IWindsorContainer _container;
        private IMainView _mainView;

        public App()
        {            
            this._container = Bootstrapper.InitializeContainer();            
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            this._mainView = this._container.Resolve<IMainView>();
            this._mainView.ShowDialog();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            this._container.Release(this._mainView);
            this._container.Dispose();
        }
    }
}
