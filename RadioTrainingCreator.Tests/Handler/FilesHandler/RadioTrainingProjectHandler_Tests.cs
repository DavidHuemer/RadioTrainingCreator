using RadioTrainingCreator.Handler.FilesHandler;
using RadioTrainingCreator.Tests.Basics;
using System.IO;
using Xunit;

namespace RadioTrainingCreator.Tests.Handler.FilesHandler
{
    public class RadioTrainingProjectHandler_Tests : BaseTest
    {
        //const string RADRIO_TRAINING_NAME = "testUebung"

        /// <summary>
        /// Checks if the RadioTrainingProjectHandler creates a folder when no folder is existing
        /// </summary>
        [Fact]
        public void Create_Project_CreateFolder_Test()
        {
            string path = $"{TEST_ENVIRONMENT}NotExistingDirectory";

            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }

            RadioTrainingProjectHandler.CreateRadioTraining(path, "testUebung", "", "");
            Assert.True(Directory.Exists(path));
        }

        /// <summary>
        /// Checks if an IOExeption is thrown if the file is already existing
        /// </summary>
        [Fact]
        public void Create_Project_FileExisting_Test()
        {
            string folderPath = $"{TEST_ENVIRONMENT}CreateNewProjectDirectory";
            RequireExistingFile(folderPath, "uebung.fue");
            Assert.Throws<IOException>(() => RadioTrainingProjectHandler.CreateRadioTraining(folderPath, "uebung", "", ""));
        }

        /// <summary>
        /// Checks if the file is created
        /// </summary>
        [Fact]
        public void Create_Project_FileCreated_Test()
        {
            string folderPath = $"{TEST_ENVIRONMENT}CreateNewProjectDirectory";
            var filePath = RequireNotExistingFile(folderPath, "uebung.fue");
            RadioTrainingProjectHandler.CreateRadioTraining(folderPath, "uebung", "", "");
            Assert.True(File.Exists(filePath));
        }


    }
}
