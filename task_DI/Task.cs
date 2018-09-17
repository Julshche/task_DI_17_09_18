
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace task_DI
{
    class Task : INotifyPropertyChanged
    {
        private string _name;
        public List<string> FutureComponent { get; set; }


        public string TaskName
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("TaskName");
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString() => _name;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
}
