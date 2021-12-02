using Xunit;

namespace Demo.Tests.Calculator
{
    public sealed class CalculatorTests
    {
        [Fact]
        public void Calculator_Sum_ReturnSumOfValues()
        {
            var calculator = new Demo.Calculator();

            var resultado = calculator.Sum(2, 2);

            Assert.Equal(4, resultado);
        }

        [Theory]
        [InlineData(1, 10, 11)]
        [InlineData(2, 8, 10)]
        [InlineData(4, 6, 10)]
        [InlineData(6, 4, 10)]
        [InlineData(8, 2, 10)]
        [InlineData(10, 1, 11)]
        public void Calculator_Sum_ReturnCorrectSumValues(decimal v1, decimal v2, decimal total)
        {
            var calculator = new Demo.Calculator();

            var resultado = calculator.Sum(v1, v2);

            Assert.Equal(total, resultado);
        }
    }
}