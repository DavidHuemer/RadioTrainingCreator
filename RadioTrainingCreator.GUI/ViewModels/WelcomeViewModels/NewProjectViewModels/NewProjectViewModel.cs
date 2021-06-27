using RadioTrainingCreator.Data.Files;
using RadioTrainingCreator.GUI.Services.FileServices;
using RadioTrainingCreator.GUI.Services.Interfaces.FileInterfaces;
using RadioTrainingCreator.GUI.ViewModels.MainWindowViewModels;

namespace RadioTrainingCreator.GUI.ViewModels.WelcomeViewModels.NewProjectViewModels
{
    public class NewProjectViewModel : WelcomeWindowPanelViewModel
    {
        public NewProjectDataViewModel DataViewModel { get; set; }

        public NewProjectViewModel(IFileDialogService fileDialogService)
        {
            DataViewModel = new NewProjectDataViewModel(fileDialogService);
            DataViewModel.Init(ProjectCreated);
        }

        public NewProjectViewModel() : this(new FileDialogService())
        {

        }

        public void ProjectCreated(CreatedRadioTraining createdRadioTraining)
        {
            MainWindowViewModel.Instance.Open(createdRadioTraining.FilePath, createdRadioTraining.RadioTraining);
            OpenProject(createdRadioTraining.FilePath, createdRadioTraining.RadioTraining);
        }
    }
}
