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

        /// <summary>
        /// Adds or updates the recently opened file with the specific path
        /// </summary>
        /// <param name="path">The path that will be addded</param>
        public void AddRecentlyOpenedFile(string path)
        {
            var recentlyOpened = new RecentlyOpenedProject
            {
                Name = Path.GetFileNameWithoutExtension(path),
                Path = path
            };

            AddRecentlyOpenedFile(recentlyOpened);
        }

        /// <summary>
        /// Adds the recently opened file
        /// </summary>
        /// <param name="recentlyOpenedFile">The recently opened file that will be added</param>
        public void AddRecentlyOpenedFile(RecentlyOpenedProject recentlyOpenedFile)
        {
            var recentlyOpenedList = GetRecentlyOpenedFiles();
            var existing = recentlyOpenedList
                .Where(x => x.Path == recentlyOpenedFile.Path)
                .FirstOrDefault();

            if (existing != null)
            {
                recentlyOpenedList.Remove(existing);
            }

            recentlyOpenedList.Insert(0, recentlyOpenedFile);
            SaveRecentlyOpenedFiles(recentlyOpenedList);
        }

        /// <summary>
        /// Returns the list of the recently opened files
        /// </summary>
        /// <returns>List of the recently opened files</returns>
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
                var recentlyOpenedFiles = new List<RecentlyOpenedProject>();
                SaveRecentlyOpenedFiles(recentlyOpenedFiles);
                return recentlyOpenedFiles;
            }
        }

        /// <summary>
        /// Saves the recently opened files
        /// </summary>
        /// <param name="recentlyOpenedFiles">The lis of recently opened files that will be saved</param>
        public void SaveRecentlyOpenedFiles(List<RecentlyOpenedProject> recentlyOpenedFiles)
        {
            var json = JsonConvert.SerializeObject(recentlyOpenedFiles);
            recentlyOpenedFilesService.Save(json);
        }
    }
}
