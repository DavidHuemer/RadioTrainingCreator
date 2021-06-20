using RadioTrainingCreator.GUI.Services.Services.MessageServices;
using Xunit;

namespace RadioTrainingCreator.Tests.GUI.Services
{
    public class MessageServiceHandler_Tests
    {
        #region GetCorrectMessageService

        /// <summary>
        /// Checks if the MessageServiceHandler returns the test-environment service
        /// </summary>
        [Fact]
        public void ReturnConsoleService_Test()
        {
            var service = MessageServiceHandler.GetCorrectMessageService();
            Assert.True(service is ConsoleMessageService);
        }

        /// <summary>
        /// Checks if the MessageServiceHandler returns the MessageBoxService
        /// </summary>
        [Fact]
        public void ReturnMessageBoxService_ByVariable_Test()
        {
            var service = MessageServiceHandler.GetCorrectMessageService(false);
            Assert.True(service is MessageBoxMessageService);
        }

        /// <summary>
        /// Checks if the MessageServiceHandler returns the ConsoleMessageService
        /// </summary>
        [Fact]
        public void ReturnConsoleService_ByVariable_Test()
        {
            var service = MessageServiceHandler.GetCorrectMessageService(true);
            Assert.True(service is ConsoleMessageService);
        }

        #endregion
    }
}
