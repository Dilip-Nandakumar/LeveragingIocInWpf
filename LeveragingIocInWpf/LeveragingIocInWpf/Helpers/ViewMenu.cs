using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LeveragingIocInWpf.Helpers
{
    public class ViewMenu
    {
        private string menuName;
        private string itemName;        
        private string toolTip;

        public bool IsRoot { get; set; }
        public bool IsExpand { get; set; }
        public List<ViewMenu> SubMenuItems { get; set; }

        public string MenuName
        {
            get { return menuName; }
            set { menuName = value; }
        }

        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }        

        public string ToolTip
        {
            get { return toolTip; }
            set { toolTip = value; }
        }
    }
}
