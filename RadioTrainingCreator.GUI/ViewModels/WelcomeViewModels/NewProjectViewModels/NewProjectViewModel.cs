using MVVM.Tools;
using RadioTrainingCreator.GUI.Services.Interfaces;
using RadioTrainingCreator.GUI.ViewModels.Basics;
using System;

namespace RadioTrainingCreator.GUI.ViewModels.WelcomeViewModels.NewProjectViewModels
{
    public class NewProjectViewModel : BaseViewModel
    {
        #region Properties

        public string ProjectName { get; set; } = "";
        public string ProjectFolder { get; set; } = "";
        public string FullPath { get; set; } = "";
        public string Author { get; set; } = "";
        public string Comment { get; set; } = "";

        #endregion

        private readonly IFileDialogService fileDialogService;

        public NewProjectViewModel(IFileDialogService fileDialogService)
        {
            this.fileDialogService = fileDialogService;
        }

        public RelayCommand<string> ChooseFolder => new RelayCommand<string>(x =>
        {
            DoChooseFolder();
        }, x => true);

        public void DoChooseFolder()
        {
            Console.WriteLine("Choose folder");
            ProjectFolder = fileDialogService.GetFolder();
        }
    }
}
