namespace RadioTrainingCreator.GUI.ViewModels.Basics
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
        public void Add()
        {
            Clear();
            IsVisible = true;
        }

        /// <summary>
        /// Clears the properties
        /// </summary>
        public abstract void Clear();
    }
}
