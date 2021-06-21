using Newtonsoft.Json;
using System.IO;
using Xunit;

namespace RadioTrainingCreator.Tests.Basics
{
    public abstract class BaseTest
    {
        /// <summary>
        /// The base path of all files that work with paths
        /// </summary>
        public const string TEST_ENVIRONMENT = @"F:\Feuerwehr\Testing\";

        /// <summary>
        /// Makes sure that the folder and the file exists
        /// </summary>
        /// <param name="folder">The folder that must exist</param>
        /// <param name="fileName">The fileName that must exist in the folder</param>
        /// <returns>The path of the file that must exist</returns>
        protected string RequireExistingFile(string folder, string fileName)
        {
            RequireDirectory(folder);

            string filePath = Path.Combine(folder, fileName);
            if (!File.Exists(filePath))
            {
                using (var stream = File.Create(filePath))
                {
                    // Use stream
                }
            }

            return filePath;
        }

        /// <summary>
        /// Makes sure that the folder exists but not the file
        /// </summary>
        /// <param name="folder">The folder that must exist</param>
        /// <param name="fileName">The fileName that should not exist</param>
        /// <returns>The path of the file that can be created but that is not existing yet</returns>
        protected string RequireNotExistingFile(string folder, string fileName)
        {
            RequireDirectory(folder);

            string filePath = Path.Combine(folder, fileName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            return filePath;
        }

        /// <summary>
        /// Makes sure the folder exists
        /// </summary>
        /// <param name="folder">The folder that must exist</param>
        private void RequireDirectory(string folder)
        {
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
        }

        /// <summary>
        /// Checks if the two objects are equal
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        protected void AssertAreEqual(object obj1, object obj2)
        {
            var obj1Str = JsonConvert.SerializeObject(obj1);
            var obj2Str = JsonConvert.SerializeObject(obj2);
            Assert.Equal(obj1Str, obj2Str);
        }
    }
}
