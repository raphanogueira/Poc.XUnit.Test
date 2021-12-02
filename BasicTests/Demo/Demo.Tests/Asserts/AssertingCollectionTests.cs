using System.Collections.Generic;
using Xunit;

namespace Demo.Tests.Asserts
{
    public sealed class AssertingCollectionTests
    {
        [Fact]
        public void Employee_Habilities_NotMustHasEmptyHabilities()
        {
            var employee = EmployeeFactory.Create("Raphael", 10000);

            Assert.All(employee.Habilities, habilities => Assert.False(string.IsNullOrEmpty(habilities)));
        }

        [Fact]
        public void Employee_Habilities_JuniorMustHasBasicHabilities()
        {
            var employee = EmployeeFactory.Create("Raphael", 1000);

            Assert.Contains("OOP", employee.Habilities);
        }

        [Fact]
        public void Employee_Habilities_JuniorNotMustHasAdvancedHabilities()
        {
            var employee = EmployeeFactory.Create("Raphael", 10000);

            Assert.Contains("Microservices", employee.Habilities);
        }

        [Fact]
        public void Employee_Habilities_SeniorMustHasAllHabilities()
        {
            var employee = EmployeeFactory.Create("Raphael", 10000);

            var basicHabilities = new List<string>
            {
                "Lógica de Programação",
                "OOP",
                "Testes",
                "Microservices"
            };

            Assert.Equal(basicHabilities, employee.Habilities);
        }
    }
}