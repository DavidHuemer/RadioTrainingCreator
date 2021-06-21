using MVVM.Tools;
using RadioTrainingCreator.Data.Files;
using RadioTrainingCreator.GUI.Services.Interfaces.FileInterfaces;
using RadioTrainingCreator.GUI.ViewModels.Basics;
using RadioTrainingCreator.GUI.ViewModels.MainWindowViewModels;
using RadioTrainingCreator.Handler.FilesHandler;
using System;

namespace RadioTrainingCreator.GUI.ViewModels.WelcomeViewModels.NewProjectViewModels
{
    /// <summary>
    /// Contains the data needed for creating a new RadioTraining project
    /// </summary>
    public class NewProjectDataViewModel : BaseViewModel
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

        #region Private variables

        private readonly IFileDialogService fileDialogService;
        private string projectName = "";
        private string projectFolder = "";

        private Action<CreatedRadioTraining> projectCreatedCallback;

        #endregion

        public NewProjectDataViewModel(IFileDialogService fileDialogService)
        {
            this.fileDialogService = fileDialogService;
        }

        public void Init(Action<CreatedRadioTraining> projectCreatedCallback)
        {
            this.projectCreatedCallback = projectCreatedCallback;
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

        #region CreateRadioTraining

        public RelayCommand<string> CreateRadioTraining => new RelayCommand<string>(x =>
        {
            DoCreateRadioTraining();
        }, x => true);

        public void DoCreateRadioTraining()
        {
            Console.WriteLine("Create Radio Training");
            var createdRadioTraining = RadioTrainingProjectHandler
                .CreateRadioTraining(ProjectFolder, ProjectName, Author, Comment);

            projectCreatedCallback?.Invoke(createdRadioTraining);
        }

        #endregion

        #endregion

        #region UpdateFullPath

        /// <summary>
        /// Updates the full path
        /// </summary>
        private void UpdateFullPath()
        {
            var path = FilePathHandler.CombineRadioTrainingPath(ProjectFolder, ProjectName);
            FullPath = path;
        }

        #endregion
    }
}
