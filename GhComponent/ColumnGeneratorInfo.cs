using Grasshopper;
using Grasshopper.Kernel;
using System;
using System.Drawing;

namespace GhComponent
{
    public class ColumnGeneratorInfo : GH_AssemblyInfo
    {
        public override string Name => "GhComponent";

        //Return a 24x24 pixel bitmap to represent this GHA library.
        public override Bitmap Icon => null;

        //Return a short string describing the purpose of this GHA library.
        public override string Description => "";

        public override Guid Id => new Guid("e18ba539-e584-4f8d-a85a-16f9e8ed7034");

        //Return a string identifying you or your company.
        public override string AuthorName => "";

        //Return a string representing your preferred contact details.
        public override string AuthorContact => "";
    }
}