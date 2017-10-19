using Xunit;

namespace BuilderPattern
{
    public class UserTests
    {
        [Fact]
        public void SomeTest()
        {
            var userForTest = new UserBuilder()
                                    .WithName("Dror Helper")
                                    .WithReputation(14000)
                                    .Build();
        }
    }
}