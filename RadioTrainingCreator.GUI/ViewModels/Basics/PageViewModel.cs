using MVVM.Tools;
using RadioTrainingCreator.Data;

namespace RadioTrainingCreator.GUI.ViewModels.Basics
{
    /// <summary>
    /// Base class for all PageViewModels
    /// </summary>
    public abstract class PageViewModel : BaseViewModel
    {
        public PageViewModel(string displayName)
        {
            DisplayName = displayName;
            CurrentRadioTraining = CurrentOpenedProject.Instance.RadioTraining;
        }

        #region Properties

        public RadioTraining CurrentRadioTraining { get; set; }
        public string DisplayName { get; set; } = "";

        #endregion

        #region Commands

        public RelayCommand<PageViewModel> Add => new RelayCommand<PageViewModel>(o => { DoAdd(); }, o => true);

        #endregion

        public abstract void DoAdd();
    }
}
