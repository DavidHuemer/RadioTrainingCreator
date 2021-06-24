using System;

namespace RadioTrainingCreator.GUI.ViewModels.Basics
{
    public class CloseAbleViewModel : BaseViewModel
    {
        private Action closeCallback;

        /// <summary>
        /// Inits the close callback
        /// </summary>
        /// <param name="closeCallback">The callback that should be called when the viewmodel closes</param>
        public void InitClose(Action closeCallback)
        {
            this.closeCallback = closeCallback;
        }

        /// <summary>
        /// Calls the close callback
        /// </summary>
        public void Close()
        {
            closeCallback?.Invoke();
        }
    }
}
