using RadioTrainingCreator.Data.Files;
using RadioTrainingCreator.GUI.ViewModels.Basics;
using RadioTrainingCreator.Handler.FilesHandler;
using RadioTrainingCreator.Handler.Services.Interfaces.FileInterfaces;
using RadioTrainingCreator.Handler.Services.Services.FileServices;
using System.Collections.Generic;
using System.IO;

namespace RadioTrainingCreator.GUI.ViewModels.WelcomeViewModels.OpenProjectViewModels
{
    public class OpenProjectViewModel : BaseViewModel
    {
        private readonly RecentlyOpenedFilesHandler RecentlyOpenedFilesHandler;

        public OpenProjectViewModel(IRecentlyOpenedFilesService recentlyOpenedFilesService = null)
        {
            if (recentlyOpenedFilesService == null)
                recentlyOpenedFilesService = new RecentlyOpenedFilesService();

            RecentlyOpenedFilesHandler = new RecentlyOpenedFilesHandler(recentlyOpenedFilesService);
            RecentlyOpenedProjects = RecentlyOpenedFilesHandler.GetRecentlyOpenedFiles();
        }

        public OpenProjectViewModel() : this(null)
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

        public void OpenRecentlyOpenedFile(RecentlyOpenedProject recentlyOpenedProject)
        {
            try
            {
                var recentlyOpened = RadioTrainingProjectHandler.LoadRadioTraining(recentlyOpenedProject.Path);
            }
            catch(FileNotFoundException fileNotFoundEx)
            {
                //MessageService.AskQ
                MessageService
            }
            catch(InvalidDataException invalidDataExpection)
            {

            }
        }
    }
}
