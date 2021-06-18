namespace RadioTrainingCreator.GUI.ViewModels.Basics
{
    public abstract class WindowViewModel : BaseViewModel
    {
        public string Title { get; set; } = "";

        public WindowViewModel(string title)
        {
            Title = title;
        }
    }
}
