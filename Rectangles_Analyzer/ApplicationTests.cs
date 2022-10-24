using Application.Helpers;
using Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using FluentAssertions;
using Xunit;

namespace RectanglesAnalyzer.Tests
{
    public class ApplicationTests
    {
        [Theory]
        [InlineData(140,196,300,125,207,207,150,100)]
        [InlineData(140, 196, 300, 125, 286, 206, 150, 100)]
        [InlineData(140, 196, 300, 125, 207, 220, 150, 100)]
        public void check_If_A_Rectangle_Contains_A_Rectangle_MustReturnTrue(float r1X,float r1Y,int r1Width,int r1Height, float r2X, float r2Y, int r2Width, int r2Height)
        {
            var analyzer = new RectAnalizer();

            Rectangle rectangle1 = new Rectangle(new Point(r1X, r1Y), r1Width, r1Height);
            Rectangle rectangle2 = new Rectangle(new Point(r2X, r2Y), r2Width, r2Height);

            var result = analyzer.AnalyceRectangles(rectangle1, rectangle2);

            result.HasContainment.Should().BeTrue();
        }

        [Theory]
        [InlineData(140, 196, 300, 125, 54, 153, 150, 100)]
        [InlineData(140, 196, 300, 125, 305, 192, 150, 100)]
        [InlineData(140, 196, 300, 125, 229, 368, 150, 100)]
        public void check_If_A_Rectangle_Contains_A_Rectangle_MustReturnFalse(float r1X, float r1Y, int r1Width, int r1Height, float r2X, float r2Y, int r2Width, int r2Height)
        {
            var analyzer = new RectAnalizer();

            Rectangle rectangle1 = new Rectangle(new Point(r1X, r1Y), r1Width, r1Height);
            Rectangle rectangle2 = new Rectangle(new Point(r2X, r2Y), r2Width, r2Height);

            var result = analyzer.AnalyceRectangles(rectangle1, rectangle2);

            result.HasContainment.Should().BeFalse();
        }



        [Theory]
        [InlineData(140, 196, 300, 125, 364, 264, 150, 100)]
        [InlineData(140, 196, 300, 125, 216, 269, 150, 100)]
        [InlineData(140, 196, 300, 125, 93, 172, 150, 100)]
        [InlineData(140, 196, 300, 125, 374, 184, 150, 100)]
        public void check_If_There_Is_An_Intersection_MustReturnTrue(float r1X, float r1Y, int r1Width, int r1Height, float r2X, float r2Y, int r2Width, int r2Height)
        {
            var analyzer = new RectAnalizer();

            Rectangle rectangle1 = new Rectangle(new Point(r1X, r1Y), r1Width, r1Height);
            Rectangle rectangle2 = new Rectangle(new Point(r2X, r2Y), r2Width, r2Height);

            var result = analyzer.AnalyceRectangles(rectangle1, rectangle2);

            result.HasIntersection.Should().BeTrue();
        }

        [Theory]
        [InlineData(140, 196, 300, 125, 453, 206, 150, 100)]
        [InlineData(140, 196, 300, 125, -13, 320, 150, 100)]
        [InlineData(132, 214, 300, 125, 194, 113, 150, 100)]
        public void check_If_There_Is_An_Intersection_MustReturnFalse(float r1X, float r1Y, int r1Width, int r1Height, float r2X, float r2Y, int r2Width, int r2Height)
        {
            var analyzer = new RectAnalizer();

            Rectangle rectangle1 = new Rectangle(new Point(r1X, r1Y), r1Width, r1Height);
            Rectangle rectangle2 = new Rectangle(new Point(r2X, r2Y), r2Width, r2Height);

            var result = analyzer.AnalyceRectangles(rectangle1, rectangle2);

            result.HasIntersection.Should().BeFalse();
        }


        [Theory]
        [InlineData(114, 247, 300, 125, 414, 247, 300, 125)]
        public void check_If_Its_Adjacent_MustReturnTrue(float r1X, float r1Y, int r1Width, int r1Height, float r2X, float r2Y, int r2Width, int r2Height)
        {
            var analyzer = new RectAnalizer();

            Rectangle rectangle1 = new Rectangle(new Point(r1X, r1Y), r1Width, r1Height);
            Rectangle rectangle2 = new Rectangle(new Point(r2X, r2Y), r2Width, r2Height);

            var result = analyzer.AnalyceRectangles(rectangle1, rectangle2);

            result.IsAdjacent.Should().BeTrue();
        }


        [Theory]
        [InlineData(114, 247, 300, 125, 415, 247, 300, 125)]
        public void check_If_Its_Adjacent_MustReturnFalse(float r1X, float r1Y, int r1Width, int r1Height, float r2X, float r2Y, int r2Width, int r2Height)
        {
            var analyzer = new RectAnalizer();
            Rectangle rectangle1 = new Rectangle(new Point(r1X, r1Y), r1Width, r1Height);
            Rectangle rectangle2 = new Rectangle(new Point(r2X, r2Y), r2Width, r2Height);

            var result = analyzer.AnalyceRectangles(rectangle1, rectangle2);

            result.IsAdjacent.Should().BeFalse();
        }

    }
}
