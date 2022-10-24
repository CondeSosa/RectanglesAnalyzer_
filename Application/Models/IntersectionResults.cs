using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class IntersectionResults
    {
        public IntersectionResults()
        {
            
        }

        public IntersectionResults(bool hasIntersection, bool isAdjacent, int adjacentType = 0)
        {
            HasIntersection = hasIntersection;
            IsAdjacent = isAdjacent;
            AdjacentType = adjacentType;
        }
        public IntersectionResults(bool hasIntersection, Point intersection, bool isAdjacent, int adjacentType = 0)
        {
            HasIntersection = hasIntersection;
            Intersection = intersection;
            IsAdjacent = isAdjacent;
        }

        public bool HasIntersection { get;  set; }
        public int AdjacentType { get;  set; }
        public bool IsAdjacent { get; set; }
        public Point Intersection { get; set; } 

    }
}
