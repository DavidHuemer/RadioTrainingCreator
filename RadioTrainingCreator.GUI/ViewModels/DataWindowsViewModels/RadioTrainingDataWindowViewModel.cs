using RadioTrainingCreator.Data.Files;
using RadioTrainingCreator.GUI.Services.Interfaces.FileInterfaces;
using RadioTrainingCreator.GUI.ViewModels.Basics;
using RadioTrainingCreator.GUI.ViewModels.WelcomeViewModels.NewProjectViewModels;
using System;
using System.ComponentModel;

namespace RadioTrainingCreator.GUI.ViewModels.DataWindowsViewModels
{
    public class RadioTrainingDataWindowViewModel : DataWindowViewModel<CreatedRadioTraining>
    {
        public NewProjectDataViewModel DataViewModel { get; set; }

        public RadioTrainingDataWindowViewModel(IFileDialogService fileDialogService) : base("Neue Funkübung erstellen")
        {
            DataViewModel = new NewProjectDataViewModel(fileDialogService);
            DataViewModel.Init(ProjectCreated);
        }

        private void ProjectCreated(CreatedRadioTraining createdRadioTraining)
        {
            ReturnData(createdRadioTraining);
        }
    }
}
