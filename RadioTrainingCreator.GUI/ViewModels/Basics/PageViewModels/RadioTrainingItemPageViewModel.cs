namespace RadioTrainingCreator.GUI.ViewModels.Basics.PageViewModels
{
    public abstract class RadioTrainingItemPageViewModel<T> : PageViewModel where T : class
    {
        private T item;
        public T CurrentItem
        {
            get { return item; }
            set
            {
                item = value;
                if (item != null)
                    ShowUpdateCurrent(value);
            }
        }

        public RadioTrainingItemPageViewModel(string displayName) : base(displayName)
        {
            
        }

        public abstract void ShowUpdateCurrent(T item);
    }
}
