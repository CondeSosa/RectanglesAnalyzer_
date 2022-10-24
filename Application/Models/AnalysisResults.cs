using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class AnalysisResults
    {
        public bool HasContainment { get; set; }
        public bool IsAdjacent{ get;  set; }
        public int AdjacentType { get; set; }
        public bool HasIntersection { get; set; }
        public List<Point> Intersections { get;  set; }
        

    }
}
