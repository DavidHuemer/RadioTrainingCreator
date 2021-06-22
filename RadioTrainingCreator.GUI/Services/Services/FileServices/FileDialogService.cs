using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using RadioTrainingCreator.GUI.Services.Interfaces.FileInterfaces;

namespace RadioTrainingCreator.GUI.Services.FileServices
{
    public class FileDialogService : IFileDialogService
    {
        public string GetFolder()
        {
            var dialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true
            };
            CommonFileDialogResult result = dialog.ShowDialog();
            if (result == CommonFileDialogResult.Ok)
            {
                return dialog.FileName;
            }

            return "";
        }

        public string GetRadioTrainingFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Funkübungen (*.fue)|*.fue";

            if (openFileDialog.ShowDialog() == true)
                return openFileDialog.FileName;

            return null;
        }
    }
}
