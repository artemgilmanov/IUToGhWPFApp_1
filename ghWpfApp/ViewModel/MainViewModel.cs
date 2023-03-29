using Rhino.Geometry;
using System;
using System.Linq;
using WPFApp.Model;

namespace WPFApp.ViewModels
{
    public class MainViewModel:BaseViewModel
    {
        /// <summary>
        /// Custom view model keeping the binding logic and the geometry creation.
        /// </summary>
        /// 
        private double _bay;
        private double _height;
        private int _columnCount;
        private Profiles _profiles;

        public Action Update;
        public ColumnProfileModel ColumnProfileModel { get; }

        public MainViewModel() 
        {
            ColumnProfileModel = new ColumnProfileModel();
        }

        public double Bay
        {
            get => _bay; 
            set
            {
                _bay = value;
                OnPropertyChanged("Bay");
            }
        }
        public double Height
        {
            get => _height;
            set
            {
                _height = value;
                OnPropertyChanged("Hieght");
            }
        }
        public int ColumnCount
        {
            get => _columnCount;
            set
            {
                _columnCount = value;
                OnPropertyChanged("FrameCount");
            }
        }
        public Profiles Profile
        {
            get => _profiles;
            set
            {
                _profiles = value;
                OnPropertyChanged("Profile");
            }
        }

        public void CreateColumns()
        {
            Brep[] columns = new Brep[ColumnCount];
            columns[0] = CreateColumn();

            for (int i = 1; i < ColumnCount; i++)
            {
                var bayTemp = columns[i-1].Duplicate();
                bayTemp.Translate(Vector3d.YAxis * (Bay / 2));
                columns[i] = (Brep)bayTemp;
            }

            ColumnProfileModel.Colums = columns.ToList();
            ColumnProfileModel.Height = Height;
            ColumnProfileModel.Bay = Bay;
        }

        private Brep CreateColumn()
        {
            Point3d pt0 = Point3d.Origin;
            Point3d pt1 = pt0 + Vector3d.ZAxis * _height;

            Polyline centerLine = new Polyline(new[] {pt0, pt1});
            Curve[] profiles = { GetProfile(Profile) };

            SweepOneRail sweepOneRail = new SweepOneRail();
            sweepOneRail.MiterType= 1;
            Brep[] breps = sweepOneRail.PerformSweep(centerLine.ToNurbsCurve(), profiles);

            return breps[0];
        }

        private Curve GetProfile(Profiles profiles)
        {
            switch (profiles)
            {
                case (Profiles)1:
                    return new Rectangle3d(Plane.WorldXY, new Point3d(-250, -250, 0), new Point3d(250, 250, 0)).ToNurbsCurve();
                case (Profiles)2:
                    return new Circle(Plane.WorldXY, Point3d.Origin, 250).ToNurbsCurve();
                case (Profiles)3:
                    return new Rectangle3d(Plane.WorldXY, new Point3d(-250, -50, 0), new Point3d(250, 50, 0)).ToNurbsCurve();
                default:
                    return new LineCurve(new Point3d(-50, 0, 0), new Point3d(50, 0, 0));
            }
        }

        public void UpdateDefinition(Action a)
        {
            Update = a;
        }
    }
}
