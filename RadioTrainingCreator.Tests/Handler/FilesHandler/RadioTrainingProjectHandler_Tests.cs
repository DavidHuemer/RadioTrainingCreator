using Newtonsoft.Json;
using RadioTrainingCreator.Handler.FilesHandler;
using RadioTrainingCreator.Tests.Basics;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Xunit;

namespace RadioTrainingCreator.Tests.Handler.FilesHandler
{
    public class RadioTrainingProjectHandler_Tests : BaseTest
    {
        //const string RADRIO_TRAINING_NAME = "testUebung"

        #region Create_Tests

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

        [Fact]
        public void Create_Project_CorrectProject_Test()
        {
            string folderPath = $"{TEST_ENVIRONMENT}CreateNewProjectDirectory";
            var filePath = RequireNotExistingFile(folderPath, "uebung.fue");
            var created = RadioTrainingProjectHandler.CreateRadioTraining(folderPath, "uebung", "", "");
            var loadedRadioTraining = RadioTrainingProjectHandler.LoadRadioTraining(filePath);

            AssertAreEqual(created.RadioTraining, loadedRadioTraining);
        }

        #endregion

        #region Open Tests

        [Fact]
        public void Open_NotExistingFile_Test()
        {
            string folderPath = $"{TEST_ENVIRONMENT}CreateNewProjectDirectory";
            string filePath = RequireNotExistingFile(folderPath, "notExisting.fue");

            Assert.Throws<FileNotFoundException>(() => RadioTrainingProjectHandler.LoadRadioTraining(filePath));
        }

        [Fact]
        public void Open_Empty_Test()
        {
            string folderPath = $"{TEST_ENVIRONMENT}CreateNewProjectDirectory";
            string filePath = RequireExistingFile(folderPath, "emptyFileFormat.fue");
            Assert.Throws<InvalidDataException>(() => RadioTrainingProjectHandler.LoadRadioTraining(filePath));
        }

        [Fact]
        public void Open_WrongFile_Test()
        {
            string folderPath = $"{TEST_ENVIRONMENT}CreateNewProjectDirectory";
            string filePath = RequireExistingFile(folderPath, "wrongFileFormat.fue");

            var formatter = new BinaryFormatter();
            var stream = File.Open(filePath, FileMode.Create);
            formatter.Serialize(stream, new WrongFileFormat { Abc = "David" });
            stream.Close();

            Assert.Throws<InvalidDataException>(() => RadioTrainingProjectHandler.LoadRadioTraining(filePath));
        }

        #endregion

        #region Wrong File class

        /// <summary>
        /// Used for checking what happens when a wrong fileFormat is loaded
        /// </summary>
        [Serializable]
        class WrongFileFormat
        {
            public string Abc { get; set; }
        }

        #endregion
    }
}
