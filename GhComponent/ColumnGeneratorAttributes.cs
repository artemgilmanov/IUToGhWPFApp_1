using Grasshopper.GUI.Canvas;
using Grasshopper.GUI;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Attributes;
using WPFToGhApp;

namespace GHComponent
{
    public class ColumnGeneratorAttributes : GH_ComponentAttributes
    {
        public ColumnGeneratorAttributes(IGH_Component component) : base(component)
        {
        }

        public override GH_ObjectResponse RespondToMouseDoubleClick(GH_Canvas sender, GH_CanvasMouseEvent e)
        {
            (Owner as ColumnGenerator)?.DisplayWindows();
            return GH_ObjectResponse.Handled;
        }
    }
}
