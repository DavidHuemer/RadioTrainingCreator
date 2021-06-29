using RadioTrainingCreator.Handler.FilesHandler;

namespace RadioTrainingCreator.GUI.ViewModels.Basics.EditorViewModels
{
    /// <summary>
    /// Base class for all editors that edits a RadioTrainingObject
    /// </summary>
    /// <typeparam name="T">The type of the RadioTrainingObject</typeparam>
    public abstract class RadioTrainingEditorViewModel<T> : EditorViewModel where T : class
    {
        public T CurrentObject { get; set; } = null;

        /// <summary>
        /// Should be called when the editor should update an "item"
        /// </summary>
        public void ShowUpdateItem(T item)
        {
            IsVisible = true;
            CurrentObject = item;
            Clear();
            SetProperties(item);
        }

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

            Hide();
            SaveManager.Instance.Unsave();
        }

        /// <summary>
        /// Sets the properties of the item
        /// </summary>
        /// <param name="item">The item which properties should be copied</param>
        protected abstract void SetProperties(T item);
    }
}
