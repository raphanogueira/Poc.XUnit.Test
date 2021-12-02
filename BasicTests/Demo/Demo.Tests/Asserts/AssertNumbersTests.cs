using Xunit;

namespace Demo.Tests.Asserts
{
    public sealed class AssertNumbersTests
    {
        [Fact]
        public void Calculator_Sum_MustBeEquals()
        {
            var calculator = new Demo.Calculator();

            var result = calculator.Sum(1, 2);

            Assert.Equal(3, result);
        }

        [Fact]
        public void Calculator_Sum_MustNotBeEquals()
        {
            var calculator = new Demo.Calculator();

            var result = calculator.Sum(1.13123123123m, 2.2312313123m);

            Assert.NotEqual(3.3m, result, 1);
        }
    }
}