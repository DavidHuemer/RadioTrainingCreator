using MVVM.Tools;
using RadioTrainingCreator.Data;
using System;

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
            CurrentOpenedProject.Instance.CurrentProjectChanged += CurrentProject_Changed;
        }

        private void CurrentProject_Changed(object sender, EventArgs e)
        {
            CurrentRadioTraining = CurrentOpenedProject.Instance.RadioTraining;
        }

        #region Properties

        public RadioTraining CurrentRadioTraining { get; set; }
        public string DisplayName { get; set; } = "";

        #endregion

        #region Commands

        public RelayCommand<PageViewModel> Add => new RelayCommand<PageViewModel>(o => { DoAdd(); }, o => true);
        public abstract void DoAdd();

        #endregion
    }
}
