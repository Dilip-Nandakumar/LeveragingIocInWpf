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
    /// Interaction logic for EmployeeDepartmentView.xaml
    /// </summary>
    public partial class EmployeeDepartmentView : UserControl, IEmployeeDepartmentView
    {
        public EmployeeDepartmentView(IEmployeeRegistrationViewModel employeeRegistrationViewModel)
        {
            InitializeComponent();
        }
    }
}
