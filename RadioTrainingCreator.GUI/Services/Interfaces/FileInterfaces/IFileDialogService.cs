namespace RadioTrainingCreator.GUI.Services.Interfaces.FileInterfaces
{
    public interface IFileDialogService
    {
        /// <summary>
        /// Returns the path to a folder
        /// </summary>
        /// <returns>Path to a folder</returns>
        string GetFolder();

        /// <summary>
        /// Returns the path to a RadioTraining file
        /// </summary>
        /// <returns>Path to a RadioTraining file</returns>
        string GetRadioTrainingFile();
    }
}
