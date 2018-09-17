using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Collections.ObjectModel;
using HelixToolkit.Wpf;

using System.Windows.Media.Media3D;
using Microsoft.Win32;
using System.ComponentModel;
using System.Windows.Media;

namespace task_DI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///
    /// 

    public partial class MainWindow : Window
    {

        private const string MODEL_PATH = "D:/vs/display3D-master/Display3DModel/bicycle.stl";
        //[System.ComponentModel.Bindable(true)]
        //public System.Windows.Controls.DataTemplateSelector ItemTemplateSelector { get; set; }

        public MainWindow()
        {
            ObservableCollection<Task> ListTask= new ObservableCollection<Task>();
            
            InitializeComponent();
            CloseButton.Click += (s, e) => Close();
            MaximizeButton.Click += (s, e) => WindowState = WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;
            MinimizeButton.Click += (s, e) => WindowState = WindowState.Minimized;
            ModelVisual3D device3D = new ModelVisual3D();
            

        }
     
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        
            private void Button_Click(object sender, RoutedEventArgs e)
        {

            FrameworkElement element = new FrameworkElement();

            Button feSource = e.Source as Button;
            Model3DGroup model1;
            switch (feSource.Content)
            {
                case "LOAD":
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Multiselect = true;
                    openFileDialog.Filter = "Text files (*.obj)|*.obj";
                    // amount of Zoom
                    //openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.);
                    if (openFileDialog.ShowDialog() == true)
                    {
                        string filename = openFileDialog.FileName;
                        ModelImporter import = new ModelImporter();
                        DiffuseMaterial material = new DiffuseMaterial(new SolidColorBrush(Colors.Beige));
                        
                        helix_view.CameraController.CameraUpDirection = new Vector3D(0, 0, 1); // set CameraUpDirection property is optional to have better view !! :)
                        /*helix_view.CameraController.CameraTarget = new Point3D(30, 0, 0);*/ // or your Target Object 3D Coordinate
                        helix_view.CameraController.AddZoomForce(0.65);
                        import.DefaultMaterial = material;
                        model1 = import.Load(filename);
                        MyView.Content = model1;
                        
                    } 
                    break;
                case "CLEAR":
                    { 
                    model1 = new Model3DGroup();
                    MyView.Content = null;
                    OnPropertyChanged("MyView.Content");

                    break;
                    }
                case "CancelButton":
                    // do something ...
                    break;
            }
            e.Handled = true;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

