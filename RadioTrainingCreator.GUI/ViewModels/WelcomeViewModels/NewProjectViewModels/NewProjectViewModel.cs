using RadioTrainingCreator.Data.Files;
using RadioTrainingCreator.GUI.Services.Interfaces.FileInterfaces;
using RadioTrainingCreator.GUI.ViewModels.Basics;
using RadioTrainingCreator.GUI.ViewModels.MainWindowViewModels;
using System;

namespace RadioTrainingCreator.GUI.ViewModels.WelcomeViewModels.NewProjectViewModels
{
    public class NewProjectViewModel : CloseAbleViewModel
    {
        public NewProjectDataViewModel DataViewModel { get; set; }

        public NewProjectViewModel(IFileDialogService fileDialogService)
        {
            DataViewModel = new NewProjectDataViewModel(fileDialogService);
            DataViewModel.Init(ProjectCreated);
        }

        public NewProjectViewModel()
        {

        }

        public void ProjectCreated(CreatedRadioTraining createdRadioTraining)
        {
            MainWindowViewModel.Instance.Open(createdRadioTraining.FilePath, createdRadioTraining.RadioTraining);
            Close();
        }
    }
}
