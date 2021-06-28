using MVVM.Tools;

namespace RadioTrainingCreator.GUI.ViewModels.Basics.EditorViewModels
{
    /// <summary>
    /// Base class for all EditorViewModels
    /// </summary>
    public abstract class EditorViewModel : BaseViewModel
    {
        public bool IsVisible { get; set; } = false;

        /// <summary>
        /// Should be called when the editor should create a new "item"
        /// </summary>
        public virtual void ShowCreateNew()
        {
            Clear();
            IsVisible = true;
        }

        /// <summary>
        /// Clears the properties
        /// </summary>
        public abstract void Clear();

        #region Commands

        #region Save

        public RelayCommand<string> Save => new RelayCommand<string>(o => { DoSave(); }, o => true);

        protected abstract void DoSave();

        #endregion

        protected abstract void CreateNew();
        protected abstract void UpdateCurrent();

        #endregion
    }
}
