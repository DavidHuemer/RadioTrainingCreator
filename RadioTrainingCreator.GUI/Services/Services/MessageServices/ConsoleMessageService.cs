using RadioTrainingCreator.GUI.Services.Interfaces;
using System;

namespace RadioTrainingCreator.GUI.Services.Services.MessageServices
{
    public class ConsoleMessageService : IMessageService
    {
        public void Show(string text)
        {
            Console.WriteLine(text);
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
