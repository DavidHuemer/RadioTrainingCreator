using System;

namespace RadioTrainingCreator.GUI.ViewModels.Basics
{
    public abstract class WindowViewModel : BaseViewModel
    {
        public string Title { get; set; } = "";

        public WindowViewModel(string title)
        {
            Title = title;
        }

        /// <summary>
        /// Will be called when the viewModel wants to close the window
        /// </summary>
        private Action close;

        /// <summary>
        /// Inits the WindowViewModel
        /// </summary>
        /// <param name="close">The action that will be called when the viewmodel wants to close the window</param>
        public void Init(Action close)
        {
            this.close = close;
        }

        /// <summary>
        /// Closes the window
        /// </summary>
        public void CloseWindow()
        {
            close?.Invoke();
        }
    }
}
