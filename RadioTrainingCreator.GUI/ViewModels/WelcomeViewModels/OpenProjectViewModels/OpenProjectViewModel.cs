using MVVM.Tools;
using RadioTrainingCreator.Data;
using RadioTrainingCreator.Data.Files;
using RadioTrainingCreator.GUI.Services.FileServices;
using RadioTrainingCreator.GUI.Services.Interfaces;
using RadioTrainingCreator.GUI.Services.Interfaces.FileInterfaces;
using RadioTrainingCreator.GUI.Services.Services.WindowServices;
using RadioTrainingCreator.GUI.ViewModels.Basics;
using RadioTrainingCreator.GUI.ViewModels.MainWindowViewModels;
using RadioTrainingCreator.Handler.FilesHandler;
using RadioTrainingCreator.Handler.Services.Interfaces.FileInterfaces;
using RadioTrainingCreator.Handler.Services.Services.FileServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace RadioTrainingCreator.GUI.ViewModels.WelcomeViewModels.OpenProjectViewModels
{
    public class OpenProjectViewModel : CloseAbleViewModel
    {
        #region Private variables

        private readonly RecentlyOpenedFilesHandler RecentlyOpenedFilesHandler;
        private readonly IWindowService windowService;
        private readonly IFileDialogService fileDialogService;

        #endregion

        public OpenProjectViewModel(IRecentlyOpenedFilesService recentlyOpenedFilesService, 
            IFileDialogService fileDialogService)
        {
            windowService = WindowServiceHandler.GetCorrectWindowService();
            this.fileDialogService = fileDialogService;
            RecentlyOpenedFilesHandler = new RecentlyOpenedFilesHandler(recentlyOpenedFilesService);

            RecentlyOpenedProjects = RecentlyOpenedFilesHandler.GetRecentlyOpenedFiles();
        }

        public OpenProjectViewModel() : this(new RecentlyOpenedFilesService(), new FileDialogService())
        {

        }


        #region Properties

        public List<RecentlyOpenedProject> RecentlyOpenedProjects { get; set; } = new List<RecentlyOpenedProject>();
        
        private RecentlyOpenedProject selectedRecentlyOpenedProject = null;
        public RecentlyOpenedProject SelectedRecentlyOpenedProject
        {
            get { return selectedRecentlyOpenedProject; }
            set
            {
                selectedRecentlyOpenedProject = value;
                OpenRecentlyOpenedFile(value);
            }
        }

        #endregion

        #region Commands

        public RelayCommand<string> OpenProject => new RelayCommand<string>(x =>
        {
            DoOpenProject();
        }, x => true);

        public void DoOpenProject()
        {
            Console.WriteLine("Open Project clicked");
            var radioTrainingFilePath = fileDialogService.GetRadioTrainingFile();
            OpenProjectAndClose(radioTrainingFilePath);
        }

        #endregion

        /// <summary>
        /// Opens the recently opened file
        /// </summary>
        /// <param name="recentlyOpenedProject">The recently opened file that should be opened</param>
        public void OpenRecentlyOpenedFile(RecentlyOpenedProject recentlyOpenedProject)
        {
            if (recentlyOpenedProject == null)
                return;

            try
            {
                var projectToOpen = RadioTrainingProjectHandler.LoadRadioTraining(recentlyOpenedProject.Path);
                OpenProjectAndClose(recentlyOpenedProject.Path, projectToOpen);
            }
            catch(FileNotFoundException fileNotFoundEx)
            {
                Console.WriteLine(fileNotFoundEx.Message);
                var result = MessageService.Show("Fehler beim laden", 
                    $"Die Datei {recentlyOpenedProject.Path} ist nicht vorhanden, " +
                    $"soll diese Datein von der Liste der zuletzt geöffneten Project entfernt werden?", 
                    MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);

                if(result == MessageBoxResult.Yes)
                {
                    RecentlyOpenedFilesHandler.RemoveRecentlyOpenedFile(recentlyOpenedProject);
                }

            }
            catch(InvalidDataException invalidDataExpection)
            {
                Console.WriteLine(invalidDataExpection.Message);
                var result = MessageService.Show("Fehler beim laden",
                    $"Die Datei {recentlyOpenedProject.Path} konnte nicht geladen werden, " +
                    $"soll diese Datein von der Liste der zuletzt geöffneten Project entfernt werden?",
                    MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);

                if (result == MessageBoxResult.Yes)
                {
                    RecentlyOpenedFilesHandler.RemoveRecentlyOpenedFile(recentlyOpenedProject);
                }
            }
        }

        public void OpenProjectAndClose(string path, RadioTraining radioTraining)
        {
            MainWindowViewModel.Instance.Open(path, radioTraining);
            windowService.Open(MainWindowViewModel.Instance);
            Close();
        }

        public void OpenProjectAndClose(string path)
        {
            if (path == null)
                return;

            try
            {
                var radioTraining = RadioTrainingProjectHandler.LoadRadioTraining(path);
                MainWindowViewModel.Instance.Open(path, radioTraining);
                windowService.Open(MainWindowViewModel.Instance);
                Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageService.ShowWarning("Fehler beim öffnen", "Konnte die Funkübung nicht öffnen");
            }
        }
    }
}
