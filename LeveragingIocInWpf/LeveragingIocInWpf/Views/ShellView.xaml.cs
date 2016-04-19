using LeveragingIocInWpf.Interfaces;
using LeveragingIocInWpf.Interfaces.ViewModels;
using LeveragingIocInWpf.Interfaces.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LeveragingIocInWpf.Views
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class ShellView : UserControl, IShellView
    {
        private IViewFactory _viewFactory;

        public ShellView(IShellViewModel shellViewModel, IViewFactory viewFactory)
        {
            InitializeComponent();
            this._viewFactory = viewFactory;
            shellViewModel.ChildViewSelected += OnChildViewSelected;
            shellViewModel.SelectDefaultView();
        }

        private void OnChildViewSelected(string itemName)
        {            
            IView viewSelected = this._viewFactory.GetView(itemName);
            this.pnlWorkArea.Children.Clear();
            this.pnlWorkArea.Children.Add((UIElement)viewSelected);
        }
    }
}
