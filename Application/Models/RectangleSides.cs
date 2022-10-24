using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public sealed class RectangleSides
    {
        public RectangleSides(Point topLeftCorner, Point bottomLeftCorner, Point topRightCorner, Point bottomRightCorner)
        {
            Right = new Line { Point1 = topRightCorner,Point2 = bottomRightCorner};
            Left = new Line { Point1 = topLeftCorner, Point2 = bottomLeftCorner };
            Top = new Line { Point1 = topLeftCorner, Point2 = topRightCorner };
            Bottom = new Line { Point1 = bottomLeftCorner, Point2 = bottomRightCorner };
        }
        
        public Line Right { get; }
        public Line Left { get; }
        public Line Top { get;  }
        public Line Bottom { get;  }


    }
}
