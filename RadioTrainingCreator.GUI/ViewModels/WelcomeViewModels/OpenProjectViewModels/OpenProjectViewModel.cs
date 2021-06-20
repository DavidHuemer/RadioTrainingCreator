using RadioTrainingCreator.GUI.ViewModels.Basics;
using RadioTrainingCreator.Handler.FilesHandler;
using RadioTrainingCreator.Handler.Services.Interfaces.FileInterfaces;
using RadioTrainingCreator.Handler.Services.Services.FileServices;

namespace RadioTrainingCreator.GUI.ViewModels.WelcomeViewModels.OpenProjectViewModels
{
    public class OpenProjectViewModel : BaseViewModel
    {
        private RecentlyOpenedFilesHandler RecentlyOpenedFilesHandler;

        public OpenProjectViewModel(IRecentlyOpenedFilesService recentlyOpenedFilesService = null)
        {
            if (recentlyOpenedFilesService == null)
                recentlyOpenedFilesService = new RecentlyOpenedFilesService();

            RecentlyOpenedFilesHandler = new RecentlyOpenedFilesHandler(recentlyOpenedFilesService);
        }
    }
}
