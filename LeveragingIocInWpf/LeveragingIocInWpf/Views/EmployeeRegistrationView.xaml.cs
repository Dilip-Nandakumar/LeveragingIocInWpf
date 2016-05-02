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

        private void OnWizardChanged(string viewName)
        {
            IView view = this._viewFactory.GetView(viewName);
            this.WizardContainer.Children.Clear();
            this.WizardContainer.Children.Add((UIElement)view);
        }
    }
}
