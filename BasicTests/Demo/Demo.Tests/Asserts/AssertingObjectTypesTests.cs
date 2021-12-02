using Xunit;

namespace Demo.Tests.Asserts
{
    public sealed class AssertingObjectTypesTests
    {
        [Fact]
        public void EmployeeFactory_Create_MustReturnEmployeeType()
        {
            var employee = EmployeeFactory.Create("Raphael", 10000);

            Assert.IsType<Employee>(employee);
        }

        [Fact]
        public void EmployeeFactory_Create_MustReturnPersonType()
        {
            var employee = EmployeeFactory.Create("Raphael", 10000);

            Assert.IsAssignableFrom<Person>(employee);
        }
    }
}