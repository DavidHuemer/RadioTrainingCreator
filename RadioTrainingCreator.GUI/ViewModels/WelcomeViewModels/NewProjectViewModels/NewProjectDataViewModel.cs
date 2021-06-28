using MVVM.Tools;
using RadioTrainingCreator.Data.Files;
using RadioTrainingCreator.GUI.Services.Interfaces.FileInterfaces;
using RadioTrainingCreator.GUI.ViewModels.Basics;
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
                UpdateCanCreate();
            }
        }
        public string ProjectFolder
        {
            get => projectFolder; set
            {
                projectFolder = value;
                UpdateFullPath();
                UpdateCanCreate();
            }
        }
        public string FullPath { get; set; } = "";
        public string Author { get; set; } = "";
        public string Comment { get; set; } = "";

        public bool CanCreate { get; set; } = false;

        #endregion

        #region Private variables

        private readonly IFileDialogService fileDialogService;
        private string projectName = "";
        private string projectFolder = "";

        private Action<CreatedRadioTraining> projectCreatedCallback;

        #endregion

        #region Init

        public NewProjectDataViewModel(IFileDialogService fileDialogService)
        {
            this.fileDialogService = fileDialogService;
        }

        public void Init(Action<CreatedRadioTraining> projectCreatedCallback)
        {
            this.projectCreatedCallback = projectCreatedCallback;
        }

        #endregion+

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
        }, x => CanCreate);

        public void DoCreateRadioTraining()
        {
            Console.WriteLine("Create Radio Training");
            var createdRadioTraining = RadioTrainingProjectHandler
                .CreateRadioTraining(ProjectFolder, ProjectName, Author, Comment);

            projectCreatedCallback?.Invoke(createdRadioTraining);
        }

        #endregion

        #endregion

        #region Update methods

        /// <summary>
        /// Updates the full path
        /// </summary>
        private void UpdateFullPath()
        {
            var path = FilePathHandler.CombineRadioTrainingPath(ProjectFolder, ProjectName);
            FullPath = path;
        }

        /// <summary>
        /// Checks if the project can be created
        /// </summary>
        public void UpdateCanCreate()
        {
            bool isSomethingEmpty = string.IsNullOrWhiteSpace(ProjectName)
                || string.IsNullOrWhiteSpace(ProjectFolder)
                || string.IsNullOrWhiteSpace(FullPath);

            CanCreate = !isSomethingEmpty;
        }

        #endregion
    }
}
