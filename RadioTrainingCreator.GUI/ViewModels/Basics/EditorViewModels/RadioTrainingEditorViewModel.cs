using RadioTrainingCreator.Handler.FilesHandler;

namespace RadioTrainingCreator.GUI.ViewModels.Basics.EditorViewModels
{
    public abstract class RadioTrainingEditorViewModel<T> : EditorViewModel where T : class
    {
        public T CurrentObject { get; set; } = null;

        protected override void DoSave()
        {
            if (CurrentObject == null)
            {
                CreateNew();
            }
            else
            {
                UpdateCurrent();
            }

            SaveManager.Instance.Unsave();
        }
    }
}
