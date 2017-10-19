using System.Collections.Generic;
using System.Linq;
using Shouldly;
using Xunit;

namespace ShouldlyTests
{
    public class ShouldlyVsXunit
    {
        [Fact]
        public void AddTest()
        {
            var calculator = new Calculator();

            var result = calculator.Add(2, 3);

            Assert.Equal(6, result);
        }

        [Fact]
        public void AddTest_Shouldly()
        {
            var calculator = new Calculator();

            var result = calculator.Add(2, 3);

            result.ShouldBe(6);
        }

        [Fact]
        public void GetDivisorsTest()
        {
            var calculator = new Calculator();

            var result = calculator.GetDivisors(20);

            Assert.Equal(new[] {2,3,5,7}, result);
        }

        [Fact]
        public void GetDivisorsTest_Shouldly()
        {
            var calculator = new Calculator();

            var result = calculator.GetDivisors(20);

            result.ShouldBe(new[] { 2, 3, 5, 7 });
        }
    }

    public class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public IEnumerable<int> GetDivisors(int n)
        {
            return from a in Enumerable.Range(2, n / 2)
                   where n % a == 0
                   select a;
        }
    }
}
