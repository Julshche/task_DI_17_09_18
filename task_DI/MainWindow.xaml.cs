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
        public System.Windows.Controls.DataTemplateSelector ItemTemplateSelector { get; set; }

        public MainWindow()
        {
            //ObservableCollection<Task> ListTask= new ObservableCollection<Task>();

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
                        helix_view.CameraController.AddZoomForce(0.6);
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
                        // Declare scene objects.

                        Model3DGroup myModel3DGroup = new Model3DGroup();
                        GeometryModel3D myGeometryModel = new GeometryModel3D();
                        ModelVisual3D myModelVisual3D = new ModelVisual3D();

                        MeshGeometry3D myMeshGeometry3D = new MeshGeometry3D();

                        // Create a collection of normal vectors for the MeshGeometry3D.
                        Vector3DCollection myNormalCollection = new Vector3DCollection();
                        myNormalCollection.Add(new Vector3D(1, 0, 0));
                        myNormalCollection.Add(new Vector3D(1, 0, 0));
                        myNormalCollection.Add(new Vector3D(0, 0, 1));
                        myNormalCollection.Add(new Vector3D(1, 0, 1));
                        myNormalCollection.Add(new Vector3D(0, 1, 1));
                        myNormalCollection.Add(new Vector3D(0, 0, 1));
                        myMeshGeometry3D.Normals = myNormalCollection;

                        // Create a collection of vertex positions for the MeshGeometry3D. 
                        Point3DCollection myPositionCollection = new Point3DCollection();
                        myPositionCollection.Add(new Point3D(-0.5, -0.5, 0.5));
                        myPositionCollection.Add(new Point3D(0.5, -0.5, 0.5));
                        myPositionCollection.Add(new Point3D(0.5, 0.5, 0.5));
                        myPositionCollection.Add(new Point3D(0.5, 0.5, 0.5));
                        myPositionCollection.Add(new Point3D(-0.5, 0.5, 0.5));
                        myPositionCollection.Add(new Point3D(-0.5, -0.5, 0.5));
                        myMeshGeometry3D.Positions = myPositionCollection;

                        // Create a collection of texture coordinates for the MeshGeometry3D.
                        PointCollection myTextureCoordinatesCollection = new PointCollection();
                        myTextureCoordinatesCollection.Add(new Point(0, 0));
                        myTextureCoordinatesCollection.Add(new Point(1, 0));
                        myTextureCoordinatesCollection.Add(new Point(1, 1));
                        myTextureCoordinatesCollection.Add(new Point(1, 1));
                        myTextureCoordinatesCollection.Add(new Point(0, 1));
                        myTextureCoordinatesCollection.Add(new Point(0, 0));
                        myMeshGeometry3D.TextureCoordinates = myTextureCoordinatesCollection;

                        // Create a collection of triangle indices for the MeshGeometry3D.
                        Int32Collection myTriangleIndicesCollection = new Int32Collection();
                        myTriangleIndicesCollection.Add(0);
                        myTriangleIndicesCollection.Add(1);
                        myTriangleIndicesCollection.Add(2);

                        myMeshGeometry3D.TriangleIndices = myTriangleIndicesCollection;

                        // Apply the mesh to the geometry model.
                        myGeometryModel.Geometry = myMeshGeometry3D;

                        // The material specifies the material applied to the 3D object. In this sample a  
                        // linear gradient covers the surface of the 3D object.

                        // Create a horizontal linear gradient with four stops.   
                        LinearGradientBrush myHorizontalGradient = new LinearGradientBrush();
                        myHorizontalGradient.StartPoint = new Point(0, 0.5);
                        myHorizontalGradient.EndPoint = new Point(1, 0.5);
                        myHorizontalGradient.GradientStops.Add(new GradientStop(Colors.Yellow, 0.0));

                        // Define material and apply to the mesh geometries.
                        DiffuseMaterial myMaterial = new DiffuseMaterial(myHorizontalGradient);
                        myGeometryModel.Material = myMaterial;

                        // Apply a transform to the object. In this sample, a rotation transform is applied,  
                        // rendering the 3D object rotated.
                        RotateTransform3D myRotateTransform3D = new RotateTransform3D();
                        AxisAngleRotation3D myAxisAngleRotation3d = new AxisAngleRotation3D();
                        myAxisAngleRotation3d.Axis = new Vector3D(0, 3, 0);
                        myAxisAngleRotation3d.Angle = 40;
                        myRotateTransform3D.Rotation = myAxisAngleRotation3d;
                        myGeometryModel.Transform = myRotateTransform3D;

                        // Add the geometry model to the model group.
                        myModel3DGroup.Children.Add(myGeometryModel);

                        // Add the group of models to the ModelVisual3d.
                        myModelVisual3D.Content = myModel3DGroup;
                        MyView.Children.Add(myModelVisual3D);
                        // 
                        //myViewport3D.Children.Add(myModelVisual3D);

                        //// Apply the viewport to the page so it will be rendered.
                        //this.Content = myViewport3D;
                        // do something ...
                        break;
                    }
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

