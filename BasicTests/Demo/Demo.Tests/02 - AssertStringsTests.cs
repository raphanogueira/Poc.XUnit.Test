using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Demo.Tests
{
    public sealed class AssertStringsTests
    {
        [Fact]
        public void StringExtensions_Union_ReturnCompletedName()
        {
            var stringExtensions = new StringExtensions();

            var completedName = stringExtensions.Union("Raphael", "Nogueira");

            Assert.Equal("Raphael Nogueira", completedName);
        }

        [Fact]
        public void StringExtensions_Union_MustIgnoreCase()
        {
            var stringExtensions = new StringExtensions();

            var completedName = stringExtensions.Union("Raphael", "Nogueira");

            Assert.Equal("RAPHAEL NOGUEIRA", completedName, true);
        }

        [Fact]
        public void StringExtensions_Union_MustContainsParcialString()
        {
            var stringExtensions = new StringExtensions();

            var completedName = stringExtensions.Union("Raphael", "Nogueira");

            Assert.Contains("ael", completedName, StringComparison.InvariantCultureIgnoreCase);
        }

        [Fact]
        public void StringExtensions_Union_MustStartsWith()
        {
            var stringExtensions = new StringExtensions();

            var completedName = stringExtensions.Union("Raphael", "Nogueira");

            Assert.StartsWith("Rap", completedName);
        }

        [Fact]
        public void StringExtensions_Union_MustEndsWith()
        {
            var stringExtensions = new StringExtensions();

            var completedName = stringExtensions.Union("Raphael", "Nogueira");

            Assert.EndsWith("eira", completedName);
        }

        [Fact]
        public void StringExtensions_Union_MustMatches()
        {
            var stringExtensions = new StringExtensions();

            var completedName = stringExtensions.Union("Raphael", "Nogueira");

            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", completedName);
        }
    }
}