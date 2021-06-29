using RadioTrainingCreator.GUI.Services.Interfaces;
using RadioTrainingCreator.Handler.FilesHandler;
using System.ComponentModel;
using System.Windows;

namespace RadioTrainingCreator.GUI.Services.Services.FileServices
{
    public static class SaveService
    {
        /// <summary>
        /// Checks if the project needs to be saved before closing and asks the user to do so
        /// </summary>
        /// <param name="messageService">The message Service that asks the user</param>
        /// <param name="e">The CancelEventArgs that can cancel the window closing</param>
        public static void CheckSaving(IMessageService messageService, CancelEventArgs e)
        {
            if (!SaveManager.Instance.IsSaved)
            {
                var messageResult = messageService.Show("Speichern?", "Soll die Funkübung gespeichert werden", MessageBoxButton.YesNoCancel, MessageBoxImage.Question, MessageBoxResult.Yes);

                switch (messageResult)
                {
                    case MessageBoxResult.Yes:
                        SaveManager.Instance.Save();
                        break;
                    case MessageBoxResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }
    }
}
