using System.Windows;

namespace RadioTrainingCreator.GUI.Services.Interfaces
{
    public interface IMessageService
    {
        void Show(string text);

        void ShowWarning(string title, string warning);

        void ShowError(string title, string error);

        MessageBoxResult Show(string title, string text, MessageBoxButton button, MessageBoxImage boxImage, MessageBoxResult defaultResult);
    }
}
