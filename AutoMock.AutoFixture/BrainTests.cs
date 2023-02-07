using AutoFixture;
using AutoFixture.AutoFakeItEasy;
using BrainSample;
using FakeItEasy;
using Xunit;

namespace AutoMock.AutoFixture
{
    public class BrainTests
    {
        [Fact]
        public void YellIfTouchHotIron_noAutoMocking()
        {
            var fakeMouth = A.Fake<IMouth>();

            var fakeHand = A.Fake<IHand>();
            A.CallTo(() => fakeHand.TouchIron(A<Iron>._)).Throws<BurnException>();

            var brain = new Brain(fakeHand, fakeMouth);

            brain.TouchIron(new Iron { IsHot = true });

            A.CallTo(() => fakeMouth.Yell()).MustHaveHappened();
        }

        [Fact]
        public void YellIfTouchHotIron()
        {
            var fixture = new Fixture().Customize(new AutoFakeItEasyCustomization());

            Fake<IMouth> fakeMouth = fixture.Freeze<Fake<IMouth>>();

            Fake<IHand> fakeHand = fixture.Freeze<Fake<IHand>>();
            A.CallTo(() => fakeHand.FakedObject.TouchIron(A<Iron>._)).Throws<BurnException>();

            var brain = fixture.Create<Brain>();

            brain.TouchIron(new Iron { IsHot = true });

            A.CallTo(() => fakeMouth.FakedObject.Yell()).MustHaveHappened();
        }

        [Fact]
        public void YellIfTouchHotIron2()
        {
            var a = new AutoMock();

            var fakeMouth = a.Fake<IMouth>();
            var fakeHand = a.Fake<IHand>();
            A.CallTo(() => fakeHand.TouchIron(A<Iron>._)).Throws<BurnException>();

            var brain = a.Real<Brain>();

            brain.TouchIron(new Iron { IsHot = true });

            A.CallTo(() => fakeMouth.Yell()).MustHaveHappened();
        }
    }

    internal class AutoMock
    {
        private readonly IFixture _fixture;

        public AutoMock()
        {
            _fixture = new Fixture().Customize(new AutoFakeItEasyCustomization());
        }

        public T Fake<T>() where T : class
        {
            return _fixture.Freeze<Fake<T>>().FakedObject;
        }

        public T Real<T>()
        {
            return _fixture.Create<T>();
        }
    }
}
