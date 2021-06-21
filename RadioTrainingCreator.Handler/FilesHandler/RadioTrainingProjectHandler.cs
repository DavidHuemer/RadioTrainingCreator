using RadioTrainingCreator.Data;
using RadioTrainingCreator.Data.Files;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace RadioTrainingCreator.Handler.FilesHandler
{
    public static class RadioTrainingProjectHandler
    {
        #region Create

        /// <summary>
        /// Creates the radio training file
        /// </summary>
        /// <param name="folderPath">The path in that the file should be created</param>
        /// <param name="radioTrainingName">The name of the radioTraining (without the file extension)</param>
        /// <param name="author">The author of the radio training</param>
        /// <param name="comment">The comment of the radioTraining</param>
        /// <returns>The created RadioTraining</returns>
        public static CreatedRadioTraining CreateRadioTraining(string folderPath, string radioTrainingName,
            string author, string comment)
        {
            CreeateDirectoryWhenRequired(folderPath);

            string projectFile = $@"{Path.Combine(folderPath, radioTrainingName)}.fue";

            if (File.Exists(projectFile))
                throw new IOException($"The file {projectFile} is already existing");

            var radioTraining = new RadioTraining
            {
                Name = radioTrainingName,
                Author = author,
                Comment = comment
            };

            SaveRadioTraining(projectFile, radioTraining);

            return new CreatedRadioTraining
            {
                RadioTraining = radioTraining,
                FilePath = projectFile
            };
        }

        /// <summary>
        /// Creates the directory if the directory is not existing yet
        /// </summary>
        /// <param name="folder">The folder path that should be checked</param>
        private static void CreeateDirectoryWhenRequired(string folder)
        {
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
        }

        #endregion

        #region Save

        /// <summary>
        /// Saves the RadioTraining object to a specific path
        /// </summary>
        /// <param name="filePath">The path where the RadioTraining should be saved</param>
        /// <param name="radioTraining">The RadioTraining that should be saved</param>
        public static void SaveRadioTraining(string filePath, RadioTraining radioTraining)
        {
            var formatter = new BinaryFormatter();
            var stream = File.Open(filePath, FileMode.Create);
            formatter.Serialize(stream, radioTraining);
            stream.Close();
        }

        #endregion

        #region Open

        public static RadioTraining LoadRadioTraining(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException($"The path {path} does not exist");

            try
            {
                var formatter = new BinaryFormatter();
                var stream = File.Open(path, FileMode.Open);
                var radioTraining = (RadioTraining)formatter.Deserialize(stream);
                stream.Close();
                return radioTraining;
            }
            catch(Exception ex)
            {
                throw new InvalidDataException(ex.Message);
            }
        }

        #endregion
    }
}
