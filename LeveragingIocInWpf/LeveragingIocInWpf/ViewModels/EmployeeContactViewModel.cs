using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeveragingIocInWpf.Interfaces.ViewModels;

namespace LeveragingIocInWpf.ViewModels
{
    public class EmployeeContactViewModel : IEmployeeContactViewModel
    {
        private string _phoneNumber = "123456789";
        private string _address = "U.S.A";

        public string PhoneNumber
        {
            get
            {
                return this._phoneNumber;
            }
        }

        public string Address
        { 
            get
            {
                return this._address;
            }
        }
    }
}
