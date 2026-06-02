

using Xunit.Abstractions;

namespace Nexus.Domain.Tests
{
    public class ShouldProyect
    {
        private readonly ITestOutputHelper _output;

        public ShouldProyect(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void CreateProyectShouldWork()
        {

            Assert.True(true);
        }
    }
}