using Creational.Singleton;
using Xunit;

namespace CreationalTests
{

    public class SingletonTests
    {
        [Fact]
        public void CanInstantiateTheClass()
        {
            Logger _sutLogger = Logger.Instance;

            Assert.NotNull(_sutLogger);
            Assert.IsType<Logger>(_sutLogger);
        }


        [Fact]
        public void OnlyOneInstanceIsCreated()
        {
            Logger _sutLoggerInstanceOne = Logger.Instance;
            Logger _sutLoggerInstanceTwo = Logger.Instance;

            Assert.Equal(_sutLoggerInstanceOne, _sutLoggerInstanceTwo);
        }
    }
}
