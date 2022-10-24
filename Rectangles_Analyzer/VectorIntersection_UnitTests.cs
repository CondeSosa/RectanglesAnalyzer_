using Application.Helpers;
using Application.Models;
using FluentAssertions;
using Moq;
using Xunit;
using Point = Application.Models.Point;

namespace RectanglesAnalyzer.Tests
{
    public class VectorIntersectionUnitTests
    {
        

        [Fact]
        public void Check_VectorIntersection_HasIntersection_MustReturn_True()
        {
            var vectorIntersection = new VectorIntersection();
            Rectangle rectangle1 = new Rectangle(new Point(149, 192), 300, 125);
            Rectangle rectangle2 = new Rectangle(new Point(368, 246), 150, 100);


            var line1 = rectangle1.Sides.Right;
            var line2 = rectangle2.Sides.Top;


            var result = vectorIntersection.CheckIntersection(line1, line2);


            result.HasIntersection.Should().BeTrue();

        }


        [Fact]
        public void Check_VectorIntersection_HasIntersection_MustReturn_False()
        {
            var vectorIntersection = new VectorIntersection();
            
            Rectangle rectangle1 = new Rectangle(new Point(149, 192), 300, 125);
            Rectangle rectangle2 = new Rectangle(new Point(246, 204), 150, 100);


            var line1 = rectangle1.Sides.Right;
            var line2 = rectangle2.Sides.Top;

            var result = vectorIntersection.CheckIntersection(line1, line2);


            result.HasIntersection.Should().BeFalse();

        }


        [Fact]
        public void Check_VectorIntersection_Adjacent_Proper_Vertical()
        {
            var vectorIntersection = new VectorIntersection();
            
            Rectangle rectangle1 = new Rectangle(new Point(115, 115), 300, 125);
            Rectangle rectangle2 = new Rectangle(new Point(415, 115), 300, 125);


            var line1 = rectangle1.Sides.Right;
            var line2 = rectangle2.Sides.Left;

            var result = vectorIntersection.CheckIntersection(line1, line2,0.001f,true);


            result.AdjacentType.Should().Be(1);

        }

        [Fact]
        public void Check_VectorIntersection_Adjacent_SubLine_Vertical()
        {
            var vectorIntersection = new VectorIntersection();
            
            Rectangle rectangle1 = new Rectangle(new Point(115, 115), 300, 125);
            Rectangle rectangle2 = new Rectangle(new Point(415, 129), 100, 50);


            var line1 = rectangle1.Sides.Right;
            var line2 = rectangle2.Sides.Left;

            var result = vectorIntersection.CheckIntersection(line1, line2, 0.001f, true);


            result.AdjacentType.Should().Be(2);

        }

        [Fact]
        public void Check_VectorIntersection_Adjacent_Partial_Vertical()
        {
            var vectorIntersection = new VectorIntersection();
            
            Rectangle rectangle1 = new Rectangle(new Point(115, 115), 300, 125);
            Rectangle rectangle2 = new Rectangle(new Point(415, 115), 100, 130);


            var line1 = rectangle1.Sides.Right;
            var line2 = rectangle2.Sides.Left;

            var result = vectorIntersection.CheckIntersection(line1, line2, 0.001f, true);


            result.AdjacentType.Should().Be(3);

        }


        [Fact]
        public void Check_VectorIntersection_Adjacent_Proper_Horizontal()
        {
            var vectorIntersection = new VectorIntersection();

            Rectangle rectangle1 = new Rectangle(new Point(115, 115), 300, 125);
            Rectangle rectangle2 = new Rectangle(new Point(115, 240), 300, 100);


            var line1 = rectangle1.Sides.Bottom;
            var line2 = rectangle2.Sides.Top;

            var result = vectorIntersection.CheckIntersection(line1, line2, 0.001f, true);


            result.AdjacentType.Should().Be(1);

        }


        [Fact]
        public void Check_VectorIntersection_Adjacent_SubLine_Horizontal()
        {
            var vectorIntersection = new VectorIntersection();

            Rectangle rectangle1 = new Rectangle(new Point(115, 115), 300, 125);
            Rectangle rectangle2 = new Rectangle(new Point(115, 240), 255, 100);


            var line1 = rectangle1.Sides.Bottom;
            var line2 = rectangle2.Sides.Top;

            var result = vectorIntersection.CheckIntersection(line1, line2, 0.001f, true);


            result.AdjacentType.Should().Be(2);

        }

      

        [Fact]
        public void Check_VectorIntersection_Adjacent_Partial_Horizontal()
        {
            var vectorIntersection = new VectorIntersection();

            Rectangle rectangle1 = new Rectangle(new Point(115, 115), 300, 125);
            Rectangle rectangle2 = new Rectangle(new Point(115, 240), 355, 100);


            var line1 = rectangle1.Sides.Bottom;
            var line2 = rectangle2.Sides.Top;

            var result = vectorIntersection.CheckIntersection(line1, line2, 0.001f, true);


            result.AdjacentType.Should().Be(3);

        }

        [Fact]
        public void Check_VectorIntersection_Parallel_Lines_ShouldReturn_Adjacent_False()
        {
            var vectorIntersection = new VectorIntersection();

            Rectangle rectangle1 = new Rectangle(new Point(115, 115), 300, 125);
            Rectangle rectangle2 = new Rectangle(new Point(115, 243), 300, 125);


            var line1 = rectangle1.Sides.Bottom;
            var line2 = rectangle2.Sides.Top;

            var result = vectorIntersection.CheckIntersection(line1, line2);


            result.IsAdjacent.Should().BeFalse();

        }


        


    }
}