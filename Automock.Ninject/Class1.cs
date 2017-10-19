using BrainSample;
using FakeItEasy;
using Ninject;
using Xunit;

namespace Automock.Ninject
{
    public class BrainTests
    {
        public void MyTest()
        {
            var autoMock = new AutoMockingContainer();

            var fakeMouth = autoMock.GetFake<IMouth>();
            var fakeHand = autoMock.GetFake<IHand>();
            A.CallTo(() => fakeHand.TouchIron(A<Iron>._)).Throws<BurnException>();

            var brain = autoMock.Create<Brain>();
            var iron = new Iron {IsHot = true};

            brain.TouchIron(iron);

            A.CallTo(() => fakeMouth.Yell()).MustHaveHappened();
        }
    }

    public class AutoMockingContainer
    {
        private readonly IKernel _kernel;

        public AutoMockingContainer()
        {
            _kernel = new StandardKernel();
        }

        public T GetFake<T>()
        {
           // _kernel.Bind<T>().To<Mock<T>>();

            return _kernel.Get<T>();
        }

        public T Create<T>()
        {
            return _kernel.Get<T>();
        }
    }
}
