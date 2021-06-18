using RadioTrainingCreator.GUI.ViewModels.Basics;
using RadioTrainingCreator.GUI.ViewModels.WelcomeViewModels.NewProjectViewModels;

namespace RadioTrainingCreator.GUI.ViewModels.WelcomeViewModels
{
    public class WelcomeWindowViewModel : WindowViewModel
    {
        public NewProjectViewModel NewProjectViewModel { get; set; }

        public WelcomeWindowViewModel() : base("Wilkommen zum Funkübung Ersteller")
        {
            NewProjectViewModel = new NewProjectViewModel();
        }
    }
}
