using RadioTrainingCreator.Data;
using RadioTrainingCreator.GUI.Services.Interfaces;
using RadioTrainingCreator.GUI.Services.Services.WindowServices;
using RadioTrainingCreator.GUI.ViewModels.Basics;
using RadioTrainingCreator.GUI.ViewModels.MainWindowViewModels;
using RadioTrainingCreator.GUI.ViewModels.WelcomeViewModels.NewProjectViewModels;
using RadioTrainingCreator.GUI.ViewModels.WelcomeViewModels.OpenProjectViewModels;
using RadioTrainingCreator.GUI.Views.Windows;
using System;

namespace RadioTrainingCreator.GUI.ViewModels.WelcomeViewModels
{
    public class WelcomeWindowViewModel : WindowViewModel
    {
        public NewProjectViewModel NewProjectViewModel { get; set; }
        public OpenProjectViewModel OpenProjectViewModel { get; set; }

        private IWindowService windowService;

        public WelcomeWindowViewModel() : base("Wilkommen zum Funkübung Ersteller")
        {
            //services
            windowService = WindowServiceHandler.GetCorrectWindowService();

            OpenProjectViewModel = new OpenProjectViewModel();
            OpenProjectViewModel.InitOpenProject(ProjectOpened);

            NewProjectViewModel = new NewProjectViewModel();
            NewProjectViewModel.InitOpenProject(ProjectOpened);
        }

        private void ProjectOpened(string filePath, RadioTraining radioTraining)
        {
            try
            {
                MainWindowViewModel.Instance.Open(filePath, radioTraining);
                MainWindow.Instance.Show();
                CloseWindow();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageService.ShowError("Fehler beim öffnen", $"Konnte das Project nicht öffnen");
            }
        }
    }
}
