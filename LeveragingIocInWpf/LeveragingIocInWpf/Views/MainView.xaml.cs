using System.Windows;
using LeveragingIocInWpf.Interfaces.Views;

namespace LeveragingIocInWpf.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window, IMainView
    {
        public MainView(IShellView shellView)
        {
            InitializeComponent();
            this.grdContainer.Children.Clear();
            this.grdContainer.Children.Add((UIElement)shellView);
        }
    }
}
