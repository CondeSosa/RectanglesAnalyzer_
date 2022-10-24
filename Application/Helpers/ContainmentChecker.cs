using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;

namespace Application.Helpers
{
    public class ContainmentChecker
    {
        //returns true is a rectangle is containing the other rectangle
        public bool IsContained(Rectangle rect1, Rectangle rect2, float tolerance = 0.001f)
        {
            //Check if first rectangle contains the  four corners of the second rectangle within it
            if (rect1.TopLeftCorner.PositionX <= rect2.TopLeftCorner.PositionX - tolerance &&
                rect1.TopRightCorner.PositionX >= rect2.TopRightCorner.PositionX - tolerance && 
                rect1.TopLeftCorner.PositionY <= rect2.TopLeftCorner.PositionY - tolerance &&
                rect1.BottomLeftCorner.PositionY >= rect2.BottomLeftCorner.PositionY - tolerance
                ||
                //Check if second rectangle contains the  four corners of the first rectangle within it
                rect2.TopLeftCorner.PositionX  <= rect1.TopLeftCorner.PositionX - tolerance &&
                rect2.TopRightCorner.PositionX >= rect1.TopRightCorner.PositionX - tolerance &&
                rect2.TopLeftCorner.PositionY <= rect1.TopLeftCorner.PositionY - tolerance &&
                rect2.BottomLeftCorner.PositionY >= rect1.BottomLeftCorner.PositionY - tolerance
               )
            {
                return true;
            }



            return false;
        }

    }
}
