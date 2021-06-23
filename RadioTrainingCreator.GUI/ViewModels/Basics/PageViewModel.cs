using RadioTrainingCreator.Data;

namespace RadioTrainingCreator.GUI.ViewModels.Basics
{
    /// <summary>
    /// Base class for all PageViewModels
    /// </summary>
    public class PageViewModel : BaseViewModel
    {
        public RadioTraining CurrentRadioTraining { get; set; }

        public PageViewModel(string displayName)
        {
            DisplayName = displayName;
            CurrentRadioTraining = CurrentOpenedProject.Instance.RadioTraining;
        }

        public string DisplayName { get; set; } = "";
    }
}
