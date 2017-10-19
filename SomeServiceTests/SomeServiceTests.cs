using System.Threading.Tasks;
using FakeItEasy;
using Ninject;
using Ninject.MockingKernel.FakeItEasy;
using NUnit.Framework;

namespace SomeServiceTests
{
    [TestFixture]
    public class SomeServiceTests
    {
        private IFileCacher _fileCacher;
        private ISystemInfo _systemInfo;
        private ICreator<IFileCacher> _fileCacherCreator;
        private IEntityCreator _entityCreator;
        private SomeService _surveyService;

        [SetUp]
        public void CreateSurveyService()
        {
            _fileCacher = A.Fake<IFileCacher>();
            _systemInfo = A.Fake<ISystemInfo>();
            _entityCreator = A.Fake<IEntityCreator>();
            _fileCacherCreator = A.Fake<ICreator<IFileCacher>>();

            A.CallTo(() => _systemInfo.PlatformName).Returns("WIN");
            A.CallTo(() => _fileCacherCreator.Get()).Returns(_fileCacher);
            A.CallTo(() => _entityCreator.Create<SomeImportantResponse>())
                .Returns(new SomeImportantResponse(_systemInfo));

            _surveyService = new SomeService(_systemInfo, _entityCreator, A.Fake<ISettingsManager>(),
               _fileCacherCreator, A.Fake<IFileSystemManager>(), A.Fake<ILogger>());
        }

        [Test]
        public async Task GetTextsWhenServerDownloadFail()
        {

            A.CallTo(() => _fileCacher.GetFileAsync(A<string>._, A<string>._, A<string>._))
                .Returns(Task.FromResult<byte[]>(null));

            var result = await _surveyService.GetTextsAsync();

            Assert.IsFalse(result.HasError);
            Assert.NotNull(result.TheResult);
        }

        #region backup

/*
        [Test]
        public async Task GetTextsWhenServerDownloadFail_doneRight()
        {
            var kernel = new FakeItEasyMockingKernel();

            kernel.Bind<SomeService>().ToSelf();

            var fakeCacher = kernel.Get<IFileCacher>();
            var fakeCreator = kernel.Get<ICreator<IFileCacher>>();
            A.CallTo(() => fakeCreator.Get()).Returns(fakeCacher);

            var someService = kernel.Get<SomeService>();

            var result = await someService.GetTextsAsync();

            Assert.IsFalse(result.HasError);
            Assert.NotNull(result.TheResult);
        }
*/

        #endregion
    }

    #region Objects under test
    public interface IFileSystemManager
    {
    }

    public interface ILogger
    {
    }

    public interface ISettingsManager
    {
    }

    public class SomeImportantResponse
    {
        public SomeImportantResponse(ISystemInfo systemInfo)
        {

        }
    }

    public class SomeService
    {
        public SomeService(ISystemInfo systemInfo, IEntityCreator entityCreator, ISettingsManager settingsManager, ICreator<IFileCacher> fileCacherCreator, IFileSystemManager fileSystemManager, ILogger logger)
        {

        }

        public Task<TextOpResult> GetTextsAsync()
        {
            return Task.FromResult<TextOpResult>(null);
        }
    }

    public class TextOpResult
    {
        public bool HasError { get; set; }
        public object TheResult { get; set; }
    }

    public interface IEntityCreator
    {
        T Create<T>();
    }

    public interface ICreator<T>
    {
        T Get();
    }

    public interface ISystemInfo
    {
        string PlatformName { get; }
    }

    public interface IFileCacher
    {
        Task GetFileAsync(string s, string s1, string s2);
    }
    #endregion
}
