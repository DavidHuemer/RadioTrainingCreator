using RadioTrainingCreator.Handler.Diagnostics;
using Xunit;

namespace RadioTrainingCreator.Tests.Handler.Diagnostics
{
    public class EnvironmentDetection_Tests
    {
        /// <summary>
        /// Checks if the environment is a testing environment
        /// </summary>
        [Fact]
        public void IsTestEnvironment_Test()
        {
            Assert.True(EnvironmentDetection.IsTestEnvironment());
        }
    }
}
