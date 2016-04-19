using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeveragingIocInWpf.Interfaces.ViewModels
{
    public interface IEmployeeRegistrationViewModel : IViewModel
    {
        event Action<string> WizardChanged;
    }
}
