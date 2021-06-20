using RadioTrainingCreator.GUI.Services.Interfaces;
using RadioTrainingCreator.Handler.Diagnostics;

namespace RadioTrainingCreator.GUI.Services.Services.MessageServices
{
    /// <summary>
    /// Handles MessageService operations
    /// </summary>
    public static class MessageServiceHandler
    {
        /// <summary>
        /// Returns the correct MessageService depending on the environment
        /// </summary>
        /// <returns>Correct MessageService depending on the environment</returns>
        public static IMessageService GetCorrectMessageService()
        {
            bool isTestEnvironment = EnvironmentDetection.IsTestEnvironment();
            return GetCorrectMessageService(isTestEnvironment);
        }

        /// <summary>
        /// Returns the correct MessageService depending on the environment
        /// </summary>
        /// <param name="isTestEnvironment">Should be true when the environment is a test environment 
        /// and false when the application runs in normal mode</param>
        /// <returns>Correct MessageService depending on the environment</returns>
        public static IMessageService GetCorrectMessageService(bool isTestEnvironment)
        {
            if (isTestEnvironment)
            {
                return new ConsoleMessageService();
            }
            else
            {
                return new MessageBoxMessageService();
            }
        }
    }
}
 