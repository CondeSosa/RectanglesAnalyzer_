using Application.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Application.Helpers;
using Application.Models;

namespace Application.Services
{
    public class RectAnalizer : IRectAnalizer
    {
        private readonly VectorIntersection _vectorIntersection;
        private readonly ContainmentChecker _containmentChecker;
        public RectAnalizer()
        {
            _vectorIntersection = new VectorIntersection();
            _containmentChecker = new ContainmentChecker();
        }

        //
        public AnalysisResults AnalyceRectangles(Rectangle rectangle1, Rectangle rectangle2, float tolerance = 0.001f)
        {

            try
            {

                AnalysisResults analysisResult = new AnalysisResults();


                //check is a rectangle is containing or not the other rectangle
                bool isContained = _containmentChecker.IsContained(rectangle1, rectangle2, tolerance);

                analysisResult.HasContainment = isContained;


                //In case that there is no rectangle contained inside another
                //we check if there is any adjacent  or intersection case
                if (!isContained)
                {

                    //We analyze every side of both rectangles and add results to this list of IntersectionResults
                    List<IntersectionResults> intersections = new List<IntersectionResults>();
                    Line rect1Line = new Line();
                    bool checkAdjacent = false;
                    for (int i = 0; i < 4; i++)
                    {
                      
                        if (i == 0)
                        {
                            rect1Line = rectangle1.Sides.Left;
                        }
                        else if (i == 1)
                        {
                            rect1Line = rectangle1.Sides.Top;
                        }
                        else if (i == 2)
                        {
                            rect1Line = rectangle1.Sides.Right;
                        }
                        else if (i == 3)
                        {
                            rect1Line = rectangle1.Sides.Bottom;
                        }


                        for (int j = 0; j < 4; j++)
                        {
                            

                            if (j == 0)
                            {
                                var result =
                                    _vectorIntersection.CheckIntersection(rect1Line, rectangle2.Sides.Left, tolerance,i == 2);
                                intersections.Add(result);
                            }
                            else if (j == 1)
                            {
                                var result =
                                    _vectorIntersection.CheckIntersection(rect1Line, rectangle2.Sides.Top, tolerance, i == 3);
                                intersections.Add(result);
                            }
                            else if (j == 2)
                            {
                                var result =
                                    _vectorIntersection.CheckIntersection(rect1Line, rectangle2.Sides.Right, tolerance, i == 0);
                                intersections.Add(result);
                            }
                            else if (j == 3)
                            {
                                var result = _vectorIntersection.CheckIntersection(rect1Line, rectangle2.Sides.Bottom,tolerance, i == 1);
                                intersections.Add(result);
                            }
                        }

                    }


                    //Verify if there is any adjacent
                    bool isAdjacent = intersections.Any(x => x.IsAdjacent == true);

                    analysisResult.IsAdjacent = isAdjacent;
                    if (isAdjacent)
                    {
                        analysisResult.AdjacentType =
                            intersections.FirstOrDefault(x => x.IsAdjacent == true)?.AdjacentType ?? 0;
                    }
                    else
                    {


                        //Verify if any intersection occurred
                        bool hasIntersection = intersections.Any(x => x.HasIntersection == true);

                        analysisResult.HasIntersection = hasIntersection;

                        if (hasIntersection)
                        {
                            var intersectionPoints =
                                intersections.Where(x => x.Intersection != null).Select(x => x.Intersection).ToList();

                            analysisResult.Intersections = intersectionPoints;
                        }

                    }




                }
                
                return analysisResult;
            }
            catch (Exception)
            {
              throw;
            }

        }
    }
}
