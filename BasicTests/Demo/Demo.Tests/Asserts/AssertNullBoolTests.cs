using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Demo.Tests.Asserts
{
    public sealed class AssertNullBoolTests
    {
        [Fact]
        public void Employee_Name_NotMustBeNullOrEmpty()
        {
            var employee = new Employee("", 700);

            Assert.False(string.IsNullOrEmpty(employee.Name));
        }

        [Fact]
        public void Employee_LastName_NotMustBeLastName()
        {
            var employee = new Employee("Raphael", 1000);

            Assert.Null(employee.LastName);

            Assert.True(string.IsNullOrEmpty(employee.LastName));
            Assert.False(employee.LastName?.Length > 0);
        }
    }
}