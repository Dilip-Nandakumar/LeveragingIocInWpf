using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeveragingIocInWpf.Interfaces.ViewModels;
using LeveragingIocInWpf.Helpers;

namespace LeveragingIocInWpf.ViewModels
{
    public class EmployeeRegistrationViewModel : IEmployeeRegistrationViewModel
    {
        private WizardInfo _selectedWizardInfo;
        private List<WizardInfo> _wizardInfoList = new List<WizardInfo>();

        public event Action<string> WizardChanged;

        public WizardInfo SelectedWizardInfo
        {
            get
            {
                return this._selectedWizardInfo;
            }

            set
            {
                this._selectedWizardInfo = value;
                this.WizardChanged(this._selectedWizardInfo.Value);                
            }
        }

        public List<WizardInfo> WizardInfoList
        {
            get
            {
                return this._wizardInfoList;
            }
        }
    }
}
