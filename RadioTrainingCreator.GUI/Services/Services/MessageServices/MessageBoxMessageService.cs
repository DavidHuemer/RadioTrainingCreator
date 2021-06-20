using RadioTrainingCreator.GUI.Services.Interfaces;
using System.Windows;

namespace RadioTrainingCreator.GUI.Services.Services.MessageServices
{
    public class MessageBoxMessageService : IMessageService
    {
        public void Show(string text)
        {
            MessageBox.Show(text);
        }

        public void ShowError(string title, string error)
        {
            MessageBox.Show(error, title, MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.No);
        }

        public void ShowWarning(string title, string warning)
        {
            MessageBox.Show(warning, title, MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.No);
        }
    }
}
