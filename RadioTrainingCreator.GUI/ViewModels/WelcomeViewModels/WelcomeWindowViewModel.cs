using RadioTrainingCreator.GUI.Services;
using RadioTrainingCreator.GUI.Services.FileServices;
using RadioTrainingCreator.GUI.ViewModels.Basics;
using RadioTrainingCreator.GUI.ViewModels.WelcomeViewModels.NewProjectViewModels;
using RadioTrainingCreator.GUI.ViewModels.WelcomeViewModels.OpenProjectViewModels;

namespace RadioTrainingCreator.GUI.ViewModels.WelcomeViewModels
{
    public class WelcomeWindowViewModel : WindowViewModel
    {
        public NewProjectViewModel NewProjectViewModel { get; set; }
        public OpenProjectViewModel OpenProjectViewModel { get; set; }

        public WelcomeWindowViewModel() : base("Wilkommen zum Funkübung Ersteller")
        {
            NewProjectViewModel = new NewProjectViewModel(new FileDialogService());
            NewProjectViewModel.Init(CloseWindow);
            OpenProjectViewModel = new OpenProjectViewModel();
        }
    }
}
