using RadioTrainingCreator.Handler.Services.Interfaces.FileInterfaces;
using System;

namespace RadioTrainingCreator.Handler.Services.Services.FileServices
{
    public class RecentlyOpenedFilesService : IRecentlyOpenedFilesService
    {
        public void AddOrUpdateProject(string path)
        {
            throw new NotImplementedException();
        }

        public string GetRecentlyOpenedProjectsJSON()
        {
            return Properties.Settings.Default.RecentlyOpenedProjects;
        }

        public void Save(string json)
        {
            Properties.Settings.Default.RecentlyOpenedProjects = json;
            Properties.Settings.Default.Save();
        }
    }
}
