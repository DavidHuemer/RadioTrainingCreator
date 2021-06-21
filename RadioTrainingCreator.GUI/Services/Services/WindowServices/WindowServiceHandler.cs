using RadioTrainingCreator.GUI.Services.Interfaces;
using RadioTrainingCreator.Handler.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioTrainingCreator.GUI.Services.Services.WindowServices
{
    public class WindowServiceHandler
    {
        public static IWindowService GetCorrectWindowService()
        {
            bool isTestEnvironment = EnvironmentDetection.IsTestEnvironment();
            return GetCorrectWindowService(isTestEnvironment);
        }

        /// <summary>
        /// Returns the correct MessageService depending on the environment
        /// </summary>
        /// <param name="isTestEnvironment">Should be true when the environment is a test environment 
        /// and false when the application runs in normal mode</param>
        /// <returns>Correct MessageService depending on the environment</returns>
        public static IWindowService GetCorrectWindowService(bool isTestEnvironment)
        {
            if (isTestEnvironment)
            {
                return new TestingWindowService();
            }
            else
            {
                return new WindowService();
            }
        }
    }
}
