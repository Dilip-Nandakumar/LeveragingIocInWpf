using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeveragingIocInWpf.Interfaces.ViewModels;
using LeveragingIocInWpf.Helpers;
using System.Collections.ObjectModel;

namespace LeveragingIocInWpf.ViewModels
{
    public class ShellViewModel : IShellViewModel
    {
        private ViewMenu _viewSelected;
        private ObservableCollection<ViewMenu> _viewMenuItems;

        public event Action<string> ChildViewSelected;

        public ObservableCollection<ViewMenu> ViewMenuItems
        {
            get
            {
                return this._viewMenuItems;
            }

            set
            {
                this._viewMenuItems = value;                
            }
        }

        public ViewMenu ViewSelected
        {
            get
            {
                return this._viewSelected;
            }

            set
            {
                if (this._viewSelected != value)
                {
                    this._viewSelected = value;
                    this.ChildViewSelected(this._viewSelected.ItemName);
                }
            }
        }

        public ShellViewModel()
        {           
            List<ViewMenu> subMenus = new List<ViewMenu>();
            subMenus.Add(new ViewMenu() { MenuName = "Employee Profile", ItemName = "EmployeeProfile", ToolTip = "Employee Profile" });
            subMenus.Add(new ViewMenu() { MenuName = "Employee Contact", ItemName = "EmployeeContact", ToolTip = "Employee Contact" });
            subMenus.Add(new ViewMenu() { MenuName = "Employee Registration", ItemName = "EmployeeRegistration", ToolTip = "Employee Registration" });           

            this.ViewMenuItems = new ObservableCollection<ViewMenu>();            
            this.ViewMenuItems.Add(new ViewMenu() { MenuName = "Employee", ItemName = "EmployeeProfile", ToolTip = "Settings", SubMenuItems = subMenus });            
        }

        public void SelectDefaultView()
        {
            this.ViewSelected = this.ViewMenuItems[0];
        }
    }
}
