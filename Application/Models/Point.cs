using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public sealed class Point
    {
        public Point()
        {
            
        }
        public Point(float positionX,float positionY)
        {
            PositionX = positionX;
            PositionY = positionY;
        }
        public float PositionX { get; set; }
        public float PositionY { get;  set; }

    }
}
