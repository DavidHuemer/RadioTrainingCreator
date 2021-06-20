using Newtonsoft.Json;
using RadioTrainingCreator.Data.Files;
using RadioTrainingCreator.Handler.Services.Interfaces.FileInterfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RadioTrainingCreator.Handler.FilesHandler
{
    public class RecentlyOpenedFilesHandler
    {
        private readonly IRecentlyOpenedFilesService recentlyOpenedFilesService;

        public RecentlyOpenedFilesHandler(IRecentlyOpenedFilesService recentlyOpenedFilesService)
        {
            this.recentlyOpenedFilesService = recentlyOpenedFilesService;
        }

        public List<RecentlyOpenedProject> GetRecentlyOpenedFiles()
        {
            var json = recentlyOpenedFilesService.GetRecentlyOpenedProjectsJSON();

            try
            {
                var recentlyOpenedPaths = JsonConvert.DeserializeObject<List<string>>(json);
                return recentlyOpenedPaths
                    .Select(x => new RecentlyOpenedProject
                    {
                        Name = Path.GetFileNameWithoutExtension(x),
                        Path = x
                    })
                    .ToList();
            }
            catch
            {
                //json was wrong
                //Needs to save empty list
                return new List<RecentlyOpenedProject>();
            }
        }
    }
}
