using System;
using FloorProblem.Implementation;
using Xunit;

namespace FloorProblem.Tests
{
    public class Tests
    {
        [Theory]
        [InlineData(0,0)]
        [InlineData(1,0)]
        [InlineData(2,0)]
        [InlineData(3,0)]
        [InlineData(4,0)]
        public void WhenMaxFloorLength_IsSuppliedAsLessThanFive_Then_ReturnPossibleCombinationAsZero(int maxLayoutSize, int expected)
        {
            var evaluator = new LayoutCombinationEvaluator();
            var actual = evaluator.DoWork(maxLayoutSize);
            Assert.Equal(expected,actual);
        }
        
        [Theory]
        [InlineData(5,2)]
        [InlineData(9,6)]
        [InlineData(32,2)]
        public void WhenMaxFloorLength_IsSuppliedAsMoreThanFour_Then_ExpectAnAppropriateResult(int maxLayoutSize, int expected)
        {
            var evaluator = new LayoutCombinationEvaluator();
            var actual = evaluator.DoWork(maxLayoutSize);
            Assert.Equal(expected,actual);
        }
    }
}