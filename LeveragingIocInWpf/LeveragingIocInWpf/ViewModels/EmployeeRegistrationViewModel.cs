using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeveragingIocInWpf.Interfaces.ViewModels;
using LeveragingIocInWpf.Helpers;
using System.ComponentModel;

namespace LeveragingIocInWpf.ViewModels
{
    public class EmployeeRegistrationViewModel : IEmployeeRegistrationViewModel, INotifyPropertyChanged
    {
        private int _wizardButtonIndex;
        private int _wizardHeaderIndex;
        private string _nextButtonText;
        private bool _isPreviousEnabled;
        private WizardInfo _selectedWizardInfo;
        private List<WizardInfo> _wizardInfoList = new List<WizardInfo>();

        public event Action<string> WizardChanged;
        public event PropertyChangedEventHandler PropertyChanged;

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

        public int WizardHeaderIndex
        {
            get
            {
                return this._wizardHeaderIndex;
            }

            set
            {
                if (value < 0)
                {
                    value = this._wizardHeaderIndex;
                }

                this._wizardHeaderIndex = value;
            }
        }

        public int WizardButtonIndex
        {
            get
            {
                return this._wizardButtonIndex;
            }

            set
            {
                this._wizardButtonIndex = value;
                this.OnWizardButtonSelection(value);
            }
        }

        public bool IsPreviousEnabled
        {
            get
            {
                return this._isPreviousEnabled;
            }

            set
            {
                this._isPreviousEnabled = value;                
            }
        }

        public string NextButtonText
        {
            get
            {
                return this._nextButtonText;
            }

            set
            {
                this._nextButtonText = value;
                OnPropertyChanged("NextButtonText");             
            }
        }

        public void LoadWizardInfo()
        {
            this.WizardInfoList.Add(new WizardInfo() { Text = "DEPARTMENT", Value = "EmployeeDepartment", NextButtonText = "Next" });
            this.WizardInfoList.Add(new WizardInfo() { Text = "DETAILS", Value = "EmployeeDetails", NextButtonText = "Next" });
            this.WizardInfoList.Add(new WizardInfo() { Text = "SUMMARY", Value = "EmployeeSummary", NextButtonText = "Finish" });

            this.SelectedWizardInfo = this.WizardInfoList[0];
            this.LoadWizardSettings();
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }            
        }

        private void LoadWizardSettings()
        {            
            this.NextButtonText = this._selectedWizardInfo.NextButtonText;
            this.IsPreviousEnabled = this._selectedWizardInfo.IsPreviousEnabled;            
        }

        private void OnWizardButtonSelection(int index)
        {
            switch (index)
            {
                case 0:
                    this.WizardHeaderIndex -= 1;
                    break;
                case 1:
                    if (this.WizardHeaderIndex == 2)
                    {                        
                        this.WizardHeaderIndex = 0;
                        break;
                    }
                    else
                    {
                        this.WizardHeaderIndex += 1;
                    }

                    break;
                case 2:
                    this.WizardHeaderIndex = 0;
                    break;
            }

            this.SelectedWizardInfo = this.WizardInfoList[this.WizardHeaderIndex];
            this.LoadWizardSettings();
        }         
    }
}
