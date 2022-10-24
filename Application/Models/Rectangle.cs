using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public sealed class Rectangle
    {
        public Rectangle()
        {
            TopLeftCorner = new Point();
        }
        public Rectangle(Point topLeftPoint, int width, int height)
        {
            Width = width;
            Height = height;
            TopLeftCorner = topLeftPoint;
        }
        
        public double Width { get; set; }
        public double Height { get; set; }
        public  Point TopLeftCorner { get; private set; }
        
        public  Point BottomLeftCorner => new Point
        {
            PositionX = TopLeftCorner.PositionX,
            PositionY = TopLeftCorner.PositionY + (float)Height
        };

        public  Point TopRightCorner => new Point
        {
            PositionX = TopLeftCorner.PositionX + (float)Width,
            PositionY = TopLeftCorner.PositionY
        };
    
        public  Point BottomRightCorner => new Point
        {   PositionX = TopLeftCorner.PositionX + (float)Width ,
            PositionY = TopLeftCorner.PositionY + (float)Height
        };

        public  RectangleSides Sides => new RectangleSides(TopLeftCorner,BottomLeftCorner,TopRightCorner,BottomRightCorner);



    }
}
