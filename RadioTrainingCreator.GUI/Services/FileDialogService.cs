using RadioTrainingCreator.GUI.Services.Interfaces;
using System.Windows.Forms;

namespace RadioTrainingCreator.GUI.Services
{
    public class FileDialogService : IFileDialogService
    {
        public string GetFolder()
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    return fbd.SelectedPath;

                return "";
            }
        }
    }
}
