using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Demo.Tests.Asserts
{
    public sealed class AssertingRangesTests
    {
        [Theory]
        [InlineData(700)]
        [InlineData(1500)]
        [InlineData(2000)]
        [InlineData(7500)]
        [InlineData(8000)]
        [InlineData(15000)]
        public void Employee_Salary_SalaryRangesMustRespectProfessionalTier(double salary)
        {
            var employee = new Employee("Raphael", salary);

            if (employee.ProfessionalTierType.Equals(ProfessionalTierType.Junior))
                Assert.InRange(employee.Salary, 500, 1999);

            if (employee.ProfessionalTierType.Equals(ProfessionalTierType.Pleno))
                Assert.InRange(employee.Salary, 2000, 7999);

            if (employee.ProfessionalTierType.Equals(ProfessionalTierType.Senior))
                Assert.InRange(employee.Salary, 8000, double.MaxValue);

            Assert.NotInRange(employee.Salary, 0, 499);
        }
    }
}