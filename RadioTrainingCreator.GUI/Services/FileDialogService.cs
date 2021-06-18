using Microsoft.WindowsAPICodePack.Dialogs;
using RadioTrainingCreator.GUI.Services.Interfaces;
using System.Windows.Forms;

namespace RadioTrainingCreator.GUI.Services
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
            if(result == CommonFileDialogResult.Ok)
            {
                return dialog.FileName;
            }

            return "";
        }
    }
}
