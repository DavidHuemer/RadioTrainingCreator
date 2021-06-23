namespace RadioTrainingCreator.GUI.ViewModels.Basics
{
    /// <summary>
    /// Base class for all EditorViewModels
    /// </summary>
    public abstract class EditorViewModel : BaseViewModel
    {
        public bool IsVisible { get; set; } = false;

        public void Add()
        {
            IsVisible = true;
        }
    }
}
