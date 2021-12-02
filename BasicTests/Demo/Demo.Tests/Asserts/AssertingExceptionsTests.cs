using System;
using Xunit;

namespace Demo.Tests.Asserts
{
    public sealed class AssertingExceptionsTests
    {
        [Fact]
        public void Calculator_Divide_MustReturnErrorDivisionByZero()
        {
            var calculator = new Demo.Calculator();

            Assert.Throws<DivideByZeroException>(() => calculator.Div(10, 0));
        }

        [Fact]
        public void Calculator_Salary_MustReturnErrorSalaryLessThanAllowed()
        {
            var exception = Assert.Throws<Exception>(() => EmployeeFactory.Create("Raphael", 250));

            Assert.Equal("Salario inferior ao permitido", exception.Message);
        }
    }
}