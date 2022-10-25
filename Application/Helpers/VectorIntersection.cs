using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Enums;
using Application.Models;

namespace Application.Helpers
{
    //Part of this code was based on Jehonathan Thomas 2017 StackOverflow answer 
    //you can find it at https://stackoverflow.com/a/46045077/15833890


    public class VectorIntersection
    {
        //adding a default plus tolerance for adjacent check
        private readonly float _addTolerance = 0.3f;
        public IntersectionResults CheckIntersection(Line line1, Line line2, float tolerance = 0.001f,bool checkAdjacent = false)
        {
            IntersectionResults result = new()
            {
                AdjacentType = (int)AdjacentTypes.NotAdjacent
            };


            float x1 = line1.Point1.PositionX, y1 = line1.Point1.PositionY;
            float x2 = line1.Point2.PositionX, y2 = line1.Point2.PositionY;

            float x3 = line2.Point1.PositionX, y3 = line2.Point1.PositionY;
            float x4 = line2.Point2.PositionX, y4 = line2.Point2.PositionY;

            if (checkAdjacent)
            {

                //We check if the two lines are vertical with overlapping
                //the _addTolerance field was added to increment a bit more the tolerance
                //when checking only if the lines are adjacent or not
                if (Math.Abs(x1 - x2) < tolerance + _addTolerance && Math.Abs(x3 - x4) < tolerance + _addTolerance &&
                    Math.Abs(x1 - x3) < tolerance + _addTolerance)
                {

                    result.IsAdjacent = true;
                    //Given the fact that the lines are overlapping know we will check 
                    //what type of adjacency we came across so first we check if 
                    //both vectors are align at the exact (with tolerance) position on both top and bottom y-axis

                    if (Math.Abs(y1 - y3) < tolerance + _addTolerance &&
                        Math.Abs(y4 - y2) < tolerance + _addTolerance && Math.Abs(y1 - y3) < tolerance + _addTolerance)
                    {
                        result.AdjacentType = (int)AdjacentTypes.Proper;
                    }
                    else
                    {
                        //knowing that it not align we now check if one line exceed the other 
                        //and if it does it would then indicate that its a partial adjacent case
                        //else it would be a sub-line
                        if (y1 - y3 > tolerance + _addTolerance && y4 - y2 < tolerance + _addTolerance ||
                            y1 - y3 < tolerance + _addTolerance && y4 - y2 > tolerance + _addTolerance)
                        {
                            result.AdjacentType = (int)AdjacentTypes.Partial;
                        }
                        else
                        {
                           
                            result.AdjacentType = (int)AdjacentTypes.SubLine;
                        }
                    }


                    //return intersection result with no intersection but confirming that its adjacent
                    return result;

                }

                //We check if the two lines are horizontal with overlapping
                //the _addTolerance field was added to increment a bit more the tolerance
                //when checking only if the lines are adjacent or not
                if (Math.Abs(y1 - y2) < tolerance + _addTolerance && Math.Abs(y3 - y4) < tolerance + _addTolerance &&
                    Math.Abs(y1 - y3) < tolerance + _addTolerance)
                {


                    result.IsAdjacent = true;
                    //Given the fact that the lines are overlapping know we will check 
                    //what type of adjacency we came across so first we check if 
                    //both vectors are align at the exact (with tolerance) position on both left and right x-axis
                    if (Math.Abs(x1 - x3) < tolerance + _addTolerance &&
                        Math.Abs(x4 - x2) < tolerance + _addTolerance && Math.Abs(x1 - x3) < tolerance + _addTolerance)
                    {
                        result.AdjacentType = (int)AdjacentTypes.Proper;
                    }
                    else
                    {
                        //knowing that it not align we now check if one line exceed the other 
                        //and if it does it would then indicate that its a partial adjacent case
                        //else it would be a sub-line
                        if (x1 - x3 > tolerance + _addTolerance && x4 - x2 < tolerance + _addTolerance ||
                            x1 - x3 < tolerance + _addTolerance && x4 - x2 > tolerance + _addTolerance)
                        {
                            result.AdjacentType = (int)AdjacentTypes.Partial;
                        }
                        else
                        {
                            result.AdjacentType = (int)AdjacentTypes.SubLine;
                        }

                    }

                    //return intersection result with no intersection but confirming that its adjacent
                    return result;

                }
            }

           




            //general equation of line is y = mx + c where m is the slope
            //assume equation of line 1 as y1 = m1x1 + c1 
            //=> -m1x1 + y1 = c1 ----(1)
            //assume equation of line 2 as y2 = m2x2 + c2
            //=> -m2x2 + y2 = c2 -----(2)
            //if line 1 and 2 intersect then x1=x2=x & y1=y2=y where (x,y) is the intersection point
            //so we will get below two equations 
            //-m1x + y = c1 --------(3)
            //-m2x + y = c2 --------(4)

            float x, y;

            //lineA is vertical x1 = x2
            //slope will be infinity
            //so lets derive another solution
            if (Math.Abs(x1 - x2) < tolerance)
            {
                //compute slope of line 2 (m2) and c2
                float m2 = (y4 - y3) / (x4 - x3);
                float c2 = -m2 * x3 + y3;

                //equation of vertical line is x = c
                //if line 1 and 2 intersect then x1=c1=x
                //subsitute x=x1 in (4) => -m2x1 + y = c2
                // => y = c2 + m2x1 
                x = x1;
                y = c2 + m2 * x1;
            }
            //lineB is vertical x3 = x4
            //slope will be infinity
            //so lets derive another solution
            else if (Math.Abs(x3 - x4) < tolerance)
            {
                //compute slope of line 1 (m1) and c2
                float m1 = (y2 - y1) / (x2 - x1);
                float c1 = -m1 * x1 + y1;

                //equation of vertical line is x = c
                //if line 1 and 2 intersect then x3=c3=x
                //subsitute x=x3 in (3) => -m1x3 + y = c1
                // => y = c1 + m1x3 
                x = x3;
                y = c1 + m1 * x3;
            }
            //lineA & lineB are not vertical 
            //(could be horizontal we can handle it with slope = 0)
            else
            {
                //compute slope of line 1 (m1) and c2
                float m1 = (y2 - y1) / (x2 - x1);
                float c1 = -m1 * x1 + y1;

                //compute slope of line 2 (m2) and c2
                float m2 = (y4 - y3) / (x4 - x3);
                float c2 = -m2 * x3 + y3;

                //solving equations (3) & (4) => x = (c1-c2)/(m2-m1)
                //plugging x value in equation (4) => y = c2 + m2 * x
                x = (c1 - c2) / (m2 - m1);
                y = c2 + m2 * x;

                //verify by plugging intersection point (x, y)
                //in orginal equations (1) & (2) to see if they intersect
                //otherwise x,y values will not be finite and will fail this check
                if (!(Math.Abs(-m1 * x + y - c1) < tolerance
                    && Math.Abs(-m2 * x + y - c2) < tolerance))
                {
                    //return intersection result with no intersection
                    return result;
                }
            }

            //x,y can intersect outside the line segment since line is infinitely long
            //so finally check if x, y is within both the line segments
            if (IsInsideLine(line1, x, y) &&
                IsInsideLine(line2, x, y))
            {
                result.HasIntersection = true;
                result.Intersection = new Point { PositionX = x, PositionY = y };

                //return intersection result with intersection
                return result;
            }

            //return intersection result with no intersection
            return result;

        }

        // Returns true if given point(x,y) is inside the given line segment
        private  bool IsInsideLine(Line line, float x, float y)
        {
            return (x >= line.Point1.PositionX && x <= line.Point2.PositionX
                        || x >= line.Point2.PositionX && x <= line.Point1.PositionX)
                   && (y >= line.Point1.PositionY && y <= line.Point2.PositionY
                        || y >= line.Point2.PositionY && y <= line.Point1.PositionY);
        }
    }
}
