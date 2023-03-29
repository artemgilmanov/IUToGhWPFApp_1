using Rhino.Geometry;
using System.Collections.Generic;

namespace WPFApp.Model
{
    /// <summary>
    /// Class used to transport the data
    /// </summary>
    /// 

    public class ColumnProfileModel
    {
        public double Bay { get; set; }

        public double Height { get; set; }

        public List<Brep> Colums { get; set; }
    }
}
