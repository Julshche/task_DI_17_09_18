using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace task_DI
{
    class Tasks : ObservableCollection<Task>
    {

        public Tasks()
        {

            Add(new Task
            {
                TaskName = "TASK 3",
                FutureComponent = new List<string> { "LOAD", "CLEAR" }
            });
            Add(new Task
            {
                TaskName = "TASK 4",
                FutureComponent = new List<string> { "LOAD", "CLEAR" }
            });
            Add(new Task
            {
                TaskName = "TASK 5",
                FutureComponent = new List<string> { "LOAD", "CLEAR", "MIN Z", "MAX Z", "START", "STOP" }
            });
            
    }

    }
}
