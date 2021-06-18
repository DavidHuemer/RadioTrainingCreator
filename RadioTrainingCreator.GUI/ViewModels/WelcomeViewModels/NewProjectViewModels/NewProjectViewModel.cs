using MVVM.Tools;
using RadioTrainingCreator.GUI.Services.Interfaces;
using RadioTrainingCreator.GUI.ViewModels.Basics;
using System;

namespace RadioTrainingCreator.GUI.ViewModels.WelcomeViewModels.NewProjectViewModels
{
    public class NewProjectViewModel : BaseViewModel
    {
        #region Properties

        public string ProjectName
        {
            get => projectName; set
            {
                projectName = value;
                UpdateFullPath();
            }
        }
        public string ProjectFolder
        {
            get => projectFolder; set
            {
                projectFolder = value;
                UpdateFullPath();
            }
        }
        public string FullPath { get; set; } = "";
        public string Author { get; set; } = "";
        public string Comment { get; set; } = "";

        #endregion

        private readonly IFileDialogService fileDialogService;
        private string projectName = "";
        private string projectFolder = "";

        public NewProjectViewModel(IFileDialogService fileDialogService)
        {
            this.fileDialogService = fileDialogService;
        }

        public NewProjectViewModel()
        {

        }

        #region Commands

        #region ChooseFolder

        public RelayCommand<string> ChooseFolder => new RelayCommand<string>(x =>
        {
            DoChooseFolder();
        }, x => true);
        public void DoChooseFolder()
        {
            Console.WriteLine("Choose folder");
            ProjectFolder = fileDialogService.GetFolder();
        }

        #endregion

        #endregion

        #region UpdateFullPath

        /// <summary>
        /// Updates the full path
        /// </summary>
        private void UpdateFullPath()
        {
            if (ShouldAddSlash(ProjectFolder))
            {
                FullPath = $@"{ProjectFolder}\{ProjectName}";
            }
            else
            {
                FullPath = $@"{ProjectFolder}{ProjectName}";
            }

        }

        /// <summary>
        /// Returns if a slash should be added to the folder path
        /// </summary>
        /// <param name="folderPath">The folder that will be checked</param>
        /// <returns>If a slash should be added to the folder</returns>
        private bool ShouldAddSlash(string folderPath)
        {
            if (folderPath.Length == 0)
                return false;

            int lastIndex = folderPath.Length - 1;

            if (folderPath[lastIndex] == '/' || folderPath[lastIndex] == '\\')
                return false;

            return true;
        }

        #endregion
    }
}
