
using System.Windows;
using System.Windows.Controls;

namespace task_DI
{
    class DTselector: DataTemplateSelector
    {
        public override DataTemplate
            SelectTemplate(object item, DependencyObject container)
        {
            if (item != null && item is Task)
            {
                var taskitem = (Task)item;
                var window = Application.Current.MainWindow;
                switch(taskitem.TaskName)
                {
                    case "TASK 3":
                        return window.FindResource("MinTemplate") as DataTemplate;
                    case "TASK 4":
                        return window.FindResource("MinTemplate") as DataTemplate;
                    case "TASK 5":
                        return window.FindResource("MaxTemplate") as DataTemplate;
                    default:
                        return null;
                }
        }

            return null;
        }
    }
}
