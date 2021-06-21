using RadioTrainingCreator.GUI.Services.Interfaces;
using System;
using System.Windows;

namespace RadioTrainingCreator.GUI.Services.Services.MessageServices
{
    public class ConsoleMessageService : IMessageService
    {
        public void Show(string text)
        {
            Console.WriteLine(text);
        }

        public MessageBoxResult Show(string title, string text, MessageBoxButton button, MessageBoxImage boxImage, MessageBoxResult defaultResult)
        {
            Console.WriteLine(text);
            return defaultResult;
        }

        public void ShowError(string title, string error)
        {
            Console.WriteLine($"ERROR: {error}");
        }

        public void ShowWarning(string title, string warning)
        {
            Console.WriteLine($"WARNING: {warning}");
        }
    }
}
