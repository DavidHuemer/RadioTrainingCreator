using MVVM.Tools;
using RadioTrainingCreator.Data.Files;
using RadioTrainingCreator.GUI.Services.FileServices;
using RadioTrainingCreator.GUI.Services.Interfaces.FileInterfaces;
using RadioTrainingCreator.Handler.FilesHandler;
using RadioTrainingCreator.Handler.Services.Interfaces.FileInterfaces;
using RadioTrainingCreator.Handler.Services.Services.FileServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace RadioTrainingCreator.GUI.ViewModels.WelcomeViewModels.OpenProjectViewModels
{
    public class OpenProjectViewModel : WelcomeWindowPanelViewModel
    {
        #region Private variables

        private readonly RecentlyOpenedFilesHandler RecentlyOpenedFilesHandler;
        private readonly IFileDialogService fileDialogService;

        #endregion

        #region Constructor

        public OpenProjectViewModel(IRecentlyOpenedFilesService recentlyOpenedFilesService, 
            IFileDialogService fileDialogService)
        {
            this.fileDialogService = fileDialogService;
            RecentlyOpenedFilesHandler = new RecentlyOpenedFilesHandler(recentlyOpenedFilesService);

            RecentlyOpenedProjects = RecentlyOpenedFilesHandler.GetRecentlyOpenedFiles();
        }

        public OpenProjectViewModel() : this(new RecentlyOpenedFilesService(), new FileDialogService())
        {

        }

        #endregion

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

        #region Browse

        public RelayCommand<string> BrowseFiles => new RelayCommand<string>(x =>
        {
            DoBrowse();
        }, x => true);

        public void DoBrowse()
        {
            Console.WriteLine("Open Project clicked");
            var radioTrainingFilePath = fileDialogService.GetRadioTrainingFile();
            OpenBrowsedFile(radioTrainingFilePath);
        }

        #endregion

        #endregion

        #region Open recently opened

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
                OpenProject(recentlyOpenedProject.Path, projectToOpen);
            }
            catch(FileNotFoundException fileNotFoundEx)
            {
                ShowFileNotFoundException(recentlyOpenedProject, fileNotFoundEx);

            }
            catch (InvalidDataException invalidDataExpection)
            {
                ShowInvalidDataException(recentlyOpenedProject, invalidDataExpection);
            }
        }

        #region Show exceptions

        private void ShowFileNotFoundException(RecentlyOpenedProject recentlyOpenedProject, FileNotFoundException fileNotFoundEx)
        {
            Console.WriteLine(fileNotFoundEx.Message);
            var result = MessageService.Show("Fehler beim laden",
                $"Die Datei {recentlyOpenedProject.Path} ist nicht vorhanden, " +
                $"soll diese Datein von der Liste der zuletzt geöffneten Project entfernt werden?",
                MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);

            if (result == MessageBoxResult.Yes)
            {
                RecentlyOpenedFilesHandler.RemoveRecentlyOpenedFile(recentlyOpenedProject);
            }
        }
        private void ShowInvalidDataException(RecentlyOpenedProject recentlyOpenedProject, InvalidDataException invalidDataExpection)
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

        #endregion

        #endregion

        #region Open browsed file

        /// <summary>
        /// Opens the file that was selected by the file browser
        /// </summary>
        /// <param name="path">The path of the file that was selected by the file browser</param>
        public void OpenBrowsedFile(string path)
        {
            if (path == null)
                return;

            try
            {
                var radioTraining = RadioTrainingProjectHandler.LoadRadioTraining(path);
                OpenProject(path, radioTraining);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageService.ShowWarning("Fehler beim öffnen", "Konnte die Funkübung nicht öffnen");
            }
        }

        #endregion
    }
}
