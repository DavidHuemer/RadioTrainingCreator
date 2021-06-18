using System;
using System.IO;

namespace RadioTrainingCreator.Handler.FilesHandler
{
    /// <summary>
    /// Handles file path operations
    /// </summary>
    public static class FilePathHandler
    {
        /// <summary>
        /// Combines the folder with the filename
        /// </summary>
        /// <param name="folder">The path to the folder</param>
        /// <param name="name">The filename</param>
        /// <returns><The Combined path/returns>
        public static string CombinePath(string folder, string name)
        {
            string path = Path.Combine(folder, name);

            if (ShouldRemoveSlash(folder, name))
            {
                path = path.Substring(0, folder.Length - 1);
            }

            return path;
        }

        /// <summary>
        /// Combines the folder with the filename and adds the file extension
        /// </summary>
        /// <param name="folder">The path to the folder</param>
        /// <param name="name">The filename</param>
        /// <returns>Combined path</returns>
        public static string CombineRadioTrainingPath(string folder, string name)
        {
            string path = CombinePath(folder, name);

            if (name.Length > 0)
            {
                path = $"{path}.fue";
            }

            return path;
        }

        /// <summary>
        /// Returns if the last index should be removed because of the slash
        /// </summary>
        /// <param name="folder">The folder path</param>
        /// <param name="name">The filename</param>
        /// <returns><If the last index should be removed because of the slash/returns>
        private static bool ShouldRemoveSlash(string folder, string name)
        {
            if (name.Length > 0)
                return false;

            if (folder.Length == 0)
                return false;

            int lastIndex = folder.Length - 1;
            var lastChar = folder[lastIndex];

            if (lastChar == '\\' || lastChar == '/')
                return true;

            return false;
        }
    }
}
