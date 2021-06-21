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

        #region Adding

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

        #endregion

        #region Removing

        /// <summary>
        /// Removes the recentlyOpenedFile
        /// </summary>
        /// <param name="recentlyOpenedFile">The recently opened file that should be removed from the list</param>
        public void RemoveRecentlyOpenedFile(RecentlyOpenedProject recentlyOpenedFile)
        {
            var recentlyOpenedList = GetRecentlyOpenedFiles();
            var existing = recentlyOpenedList
                .Where(x => x.Path == recentlyOpenedFile.Path)
                .FirstOrDefault();

            if (existing != null)
            {
                recentlyOpenedList.Remove(existing);
            }

            SaveRecentlyOpenedFiles(recentlyOpenedList);
        }

        #endregion+

        #region GetRecentlyOpenedFiles

        /// <summary>
        /// Returns the list of the recently opened files
        /// </summary>
        /// <returns>List of the recently opened files</returns>
        public List<RecentlyOpenedProject> GetRecentlyOpenedFiles()
        {
            var json = recentlyOpenedFilesService.GetRecentlyOpenedProjectsJSON();

            try
            {
                var recentlyOpenedPaths = JsonConvert.DeserializeObject<List<RecentlyOpenedProject>>(json);
                return recentlyOpenedPaths
                    .Select(x => new RecentlyOpenedProject
                    {
                        Name = x.Name,
                        Path = x.Path
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

        #endregion

        #region SaveRecentlyOpenedFiles

        /// <summary>
        /// Saves the recently opened files
        /// </summary>
        /// <param name="recentlyOpenedFiles">The lis of recently opened files that will be saved</param>
        public void SaveRecentlyOpenedFiles(List<RecentlyOpenedProject> recentlyOpenedFiles)
        {
            var json = JsonConvert.SerializeObject(recentlyOpenedFiles);
            recentlyOpenedFilesService.Save(json);
        }

        #endregion
    }
}
