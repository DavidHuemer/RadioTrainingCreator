using System;
using System.Linq;

namespace RadioTrainingCreator.Handler.Diagnostics
{
    /// <summary>
    /// Handles environment detections
    /// </summary>
    public static class EnvironmentDetection
    {
        /// <summary>
        /// Checks if the application is running in testMode
        /// </summary>
        /// <returns>If the application is running in testMode</returns>
        public static bool IsTestEnvironment()
        {
            string testAssemblyName = "xunit";
            var isUnitTesting = AppDomain.CurrentDomain.GetAssemblies()
                .Any(a => a.FullName.StartsWith(testAssemblyName));

            return isUnitTesting;
        }
        }
    }
}
