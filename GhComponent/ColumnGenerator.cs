using GHComponent;
using Grasshopper.Kernel;
using System;
using UIWpfApp.View;
using WPFApp.ViewModels;

namespace WPFToGhApp
{
    public class ColumnGenerator : GH_Component
    {

        private MainWindow _mainView;

        public ColumnGenerator()
          : base("ColumnsGenerator", "CG", "Create a series of columns based on the data provided from the UI", "UI", "UI")
        {
        }
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddBrepParameter("Columns", "C", "Columns", GH_ParamAccess.list);

        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            if (!(_mainView?.DataContext is MainViewModel dvm)) return;
            DA.SetDataList(0, dvm.ColumnProfileModel.Colums);

            dvm.UpdateDefinition(() => ExpireSolution(true));
        }

        public override void CreateAttributes()
        {
            m_attributes = new ColumnGeneratorAttributes(this);
        }

        public void DisplayWindows()
        {
            _mainView = new MainWindow();
            _mainView.Show();
            if (!(_mainView.DataContext is MainViewModel dvm)) return;
            dvm.UpdateDefinition(() => ExpireSolution(true));
        }

        public override GH_Exposure Exposure => GH_Exposure.primary;


        protected override System.Drawing.Bitmap Icon => null;

        public override Guid ComponentGuid => new Guid("6e95fd99-ac64-4bc0-b9ae-830c1259ff40");
    }
}