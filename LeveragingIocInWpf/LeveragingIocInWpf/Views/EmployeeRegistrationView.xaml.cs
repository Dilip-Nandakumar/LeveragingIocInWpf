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
    /// Interaction logic for EmployeeRegistrationView.xaml
    /// </summary>
    public partial class EmployeeRegistrationView : UserControl, IEmployeeRegistrationView
    {
        private IViewFactory _viewFactory;

        public EmployeeRegistrationView(IEmployeeRegistrationViewModel employeeRegistrationViewModel, IViewFactory viewFactory)
        {
            InitializeComponent();
            this._viewFactory = viewFactory;
            employeeRegistrationViewModel.WizardChanged += this.OnWizardChanged;
            employeeRegistrationViewModel.LoadWizardInfo();            
        }

        private void ListBoxButtons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((object[])e.AddedItems).Count() == 0)
            {
                switch (((ContentControl)e.RemovedItems[0]).Content.ToString().ToLower())
                {
                    case "next":
                    case "finish":
                        ((ListBoxItem)lbBtns.Items[1]).IsSelected = true;
                        break;
                    case "previous":
                        ((ListBoxItem)lbBtns.Items[0]).IsSelected = true;
                        break;
                }
            }
        }

        private void OnWizardChanged(string viewName)
        {
            IView view = this._viewFactory.GetView(viewName);
            this.WizardContainer.Children.Clear();
            this.WizardContainer.Children.Add((UIElement)view);
        }
    }
}
