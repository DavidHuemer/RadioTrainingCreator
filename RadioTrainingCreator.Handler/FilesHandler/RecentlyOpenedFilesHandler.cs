using RadioTrainingCreator.Handler.Services.Interfaces.FileInterfaces;

namespace RadioTrainingCreator.Handler.FilesHandler
{
    public class RecentlyOpenedFilesHandler
    {
        private IRecentlyOpenedFilesService recentlyOpenedFilesService;

        public RecentlyOpenedFilesHandler(IRecentlyOpenedFilesService recentlyOpenedFilesService)
        {
            this.recentlyOpenedFilesService = recentlyOpenedFilesService;
        }
    }
}
