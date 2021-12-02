using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Demo.Tests
{
    public sealed class AssertNumbersTests
    {
        [Fact]
        public void Calculator_Sum_MustBeEquals()
        {
            var calculator = new Calculator();

            var result = calculator.Sum(1, 2);

            Assert.Equal(3, result);
        }

        [Fact]
        public void Calculator_Sum_MustNotBeEquals()
        {
            var calculator = new Calculator();

            var result = calculator.Sum(1.13123123123, 2.2312313123);

            Assert.NotEqual(3.3, result, 1);
        }
    }
}