using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace LeveragingIocInWpf.Helpers
{
    public static class TreeViewExtension
    {
        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.RegisterAttached("SelectedItem", typeof(object), typeof(TreeViewExtension), new UIPropertyMetadata(null, SelectedItemChanged));
        private static Dictionary<DependencyObject, TreeViewSelectedItemBehavior> behaviors = new Dictionary<DependencyObject, TreeViewSelectedItemBehavior>();

        public static object GetSelectedItem(DependencyObject obj)
        {
            return (object)obj.GetValue(SelectedItemProperty);
        }

        public static void SetSelectedItem(DependencyObject obj, object value)
        {
            if (((ViewMenu)value).SubMenuItems != null && ((ViewMenu)value).SubMenuItems.Count() > 0)
            {
                value = ((ViewMenu)value).SubMenuItems[0];
            }

            obj.SetValue(SelectedItemProperty, value);
        }

        private static void SelectedItemChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if (!(obj is TreeView))
            {
                return;
            }

            if (!behaviors.ContainsKey(obj))
            {
                behaviors.Add(obj, new TreeViewSelectedItemBehavior(obj as TreeView));
            }

            TreeViewSelectedItemBehavior view = behaviors[obj];

            obj.SetValue(SelectedItemProperty, e.NewValue);
            view.ChangeSelectedItem(e.NewValue);
        }

        private class TreeViewSelectedItemBehavior
        {
            private TreeView view;

            public TreeViewSelectedItemBehavior(TreeView view)
            {
                this.view = view;
                view.SelectedItemChanged += (sender, e) => SetSelectedItem(view, e.NewValue);
            }

            internal void ChangeSelectedItem(object p)
            {
                if (this.view.SelectedItem == null)
                {
                    TreeViewItem item = (TreeViewItem)this.view.ItemContainerGenerator.ContainerFromIndex(0);
                    item.IsExpanded = true;
                    item.IsSelected = true;
                }
            }
        }
    }
}
