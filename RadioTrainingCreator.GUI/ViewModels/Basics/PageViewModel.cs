namespace RadioTrainingCreator.GUI.ViewModels.Basics
{
    /// <summary>
    /// Base class for all PageViewModels
    /// </summary>
    public class PageViewModel : BaseViewModel
    {
        public PageViewModel(string displayName)
        {
            DisplayName = displayName;
        }

        public string DisplayName { get; set; } = "";
    }
}
