using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeveragingIocInWpf.Interfaces.ViewModels;

namespace LeveragingIocInWpf.ViewModels
{
    public class EmployeeProfileViewModel : IEmployeeProfileViewModel
    {
        private string _name = "Bill";
        private string _designation = "Developer";

        public string Name
        {
            get
            {
                return this._name;
            }            
        }

        public string Designation
        {
            get
            {
                return this._designation;
            }            
        }
    }
}
