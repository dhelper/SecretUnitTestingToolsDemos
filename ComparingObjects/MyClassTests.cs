using Xunit;

namespace ComparingObjects
{
    public class MyClassTests
    {
        [Fact]
        void BlahBlahBlah()
        {
            var sut = new ThisIsAUnit();

            var result = sut.AmazingMethod();

            Assert.Equal(1, result.MyInt);
            Assert.Equal("a string", result.MyString);
        }
    }
}