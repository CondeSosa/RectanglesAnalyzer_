using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Helpers;
using Application.Models;
using FluentAssertions;
using Xunit;
namespace RectanglesAnalyzer.Tests
{
    public class ContainmentCheckerUnitTests
    {

        [Fact]
        public void Contains_Rectangle_MustReturn_False()
        {
            var containmentChecker = new ContainmentChecker();
            Rectangle rectangle1 = new Rectangle(new Point(121, 164), 300, 125);
            Rectangle rectangle2 = new Rectangle(new Point(466, 166), 150, 100);

            var result = containmentChecker.IsContained(rectangle1,rectangle2);
            
            result.Should().BeFalse();
        }

        [Fact]
        public void Contains_Rectangle_MustReturn_True()
        {
            var containmentChecker = new ContainmentChecker();
            Rectangle rectangle1 = new Rectangle(new Point(121, 164), 300, 125);
            Rectangle rectangle2 = new Rectangle(new Point(140, 180), 150, 100);

            var result = containmentChecker.IsContained(rectangle1, rectangle2);

            result.Should().BeTrue();
        }

    }
}
