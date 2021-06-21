using RadioTrainingCreator.Data.Files;
using RadioTrainingCreator.GUI.Services.Interfaces.FileInterfaces;
using RadioTrainingCreator.GUI.ViewModels.Basics;
using RadioTrainingCreator.GUI.ViewModels.MainWindowViewModels;
using System;

namespace RadioTrainingCreator.GUI.ViewModels.WelcomeViewModels.NewProjectViewModels
{
    public class NewProjectViewModel : BaseViewModel
    {
        public NewProjectDataViewModel DataViewModel { get; set; }

        private readonly IFileDialogService fileDialogService;

        private Action projectCreated;

        public NewProjectViewModel(IFileDialogService fileDialogService)
        {
            this.fileDialogService = fileDialogService;
            DataViewModel = new NewProjectDataViewModel(fileDialogService);
            DataViewModel.Init(ProjectCreated);
        }

        public NewProjectViewModel()
        {

        }

        public void Init(Action projectCreated)
        {
            this.projectCreated = projectCreated;
        }

        public void ProjectCreated(CreatedRadioTraining createdRadioTraining)
        {
            MainWindowViewModel.Instance.Open(createdRadioTraining.FilePath, createdRadioTraining.RadioTraining);
            projectCreated?.Invoke();
        }
    }
}
