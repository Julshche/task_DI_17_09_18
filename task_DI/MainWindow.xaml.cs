using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Collections.ObjectModel;
using HelixToolkit.Wpf;

using System.Windows.Media.Media3D;
using Microsoft.Win32;
using System.ComponentModel;
using System.Windows.Media;
using System.Timers;
using System;

namespace task_DI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///remember Identity
    ///Scale
    ///Rotation
    ///Orientation
    /// Translation


    public partial class MainWindow : Window
    {

        private const string MODEL_PATH = "D:/vs/display3D-master/Display3DModel/bicycle.stl";
        //[System.ComponentModel.Bindable(true)]
        public System.Windows.Controls.DataTemplateSelector ItemTemplateSelector { get; set; }
        System.Windows.Threading.DispatcherTimer clock = new System.Windows.Threading.DispatcherTimer();
        bool flag_for_rotate = false;
        int delta = 10;
        public MainWindow()
        {
            //ObservableCollection<Task> ListTask= new ObservableCollection<Task>();
            //clock.Tick += new EventHandler(clock_Tick);
            clock.Interval = new TimeSpan(0, 0, 0, 0, 20);
            InitializeComponent();
            CloseButton.Click += (s, e) => Close();
            MaximizeButton.Click += (s, e) => WindowState = WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;
            MinimizeButton.Click += (s, e) => WindowState = WindowState.Minimized;
            ModelVisual3D device3D = new ModelVisual3D();

        }

        private void MyListItemSelected(object sender, RoutedEventArgs e)
        {
            if (MyView.Content != null && MyView != null)
            {
                MyView.Content = null;
                OnPropertyChanged("MyView.Content");
            }
            //DTselector dt = new DTselector();
            //dt.SelectTemplate(sender, panel);
            DataTemplate Temp;
            ListBox el = sender as ListBox;
            if (el.SelectedItem.ToString() == "TASK 5")
            {
                Temp = (DataTemplate)this.FindResource("MaxTemplate");
                panel.ItemTemplate = Temp;
            }
            else
            {
                Temp = (DataTemplate)this.FindResource("MinTemplate");
                panel.ItemTemplate = Temp;

            }

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
                        //helix_view.CameraController.AddZoomForce(0.6);
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
                case "START":
                    {
                        Matrix3D matrix;
                        // Declare scene objects.
                        flag_for_rotate = true;
                        var axis = new Vector3D(0, 1, 0);
                            delta += 10;
                             matrix= MyView.Transform.Value;
                            matrix.Rotate(new Quaternion(axis, delta));

                            MyView.Transform = new MatrixTransform3D(matrix);
                       
                        //// Apply the viewport to the page so it will be rendered.
                        //this.Content = myViewport3D;
                        // do something ...
                        break;
                    }
                case "STOP":
                    { flag_for_rotate = false;break; }
                    
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

