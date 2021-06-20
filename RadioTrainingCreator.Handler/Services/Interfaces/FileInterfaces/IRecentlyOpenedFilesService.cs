using RadioTrainingCreator.Data.Files;
using System.Collections.Generic;

namespace RadioTrainingCreator.Handler.Services.Interfaces.FileInterfaces
{
    public interface IRecentlyOpenedFilesService
    {
        void AddOrUpdateProject(string path);

        string GetRecentlyOpenedProjectsJSON();
    }
}
