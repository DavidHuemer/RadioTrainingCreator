using RadioTrainingCreator.GUI.ViewModels.Basics;

namespace RadioTrainingCreator.GUI.ViewModels.WelcomeViewModels.NewProjectViewModels
{
    public class NewProjectViewModel : BaseViewModel
    {
        public string ProjectName { get; set; } = "";
        public string ProjectFolder { get; set; } = "";
        public string FullPath { get; set; } = "";
        public string Author { get; set; } = "";
        public string Comment { get; set; } = "";
    }
}
