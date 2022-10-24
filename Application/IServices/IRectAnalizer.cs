using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;

namespace Application.IServices
{
    public interface IRectAnalizer
    {
        public AnalysisResults AnalyceRectangles(Rectangle rectangle1, Rectangle rectangle2, float tolerance);


    }
}
