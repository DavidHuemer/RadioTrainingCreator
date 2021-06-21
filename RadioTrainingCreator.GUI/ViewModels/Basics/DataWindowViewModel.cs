using System.ComponentModel;

namespace RadioTrainingCreator.GUI.ViewModels.Basics
{
    public abstract class DataWindowViewModel<T> : WindowViewModel where T : class
    {
        public delegate void ReturnDataDel(T data);
        private ReturnDataDel returnDataDel;

        /// <summary>
        /// Defines if something has returned
        /// </summary>
        protected bool hasReturned;

        public DataWindowViewModel(string title) : base(title)
        {

        }

        /// <summary>
        /// Inits the DataWindow
        /// </summary>
        /// <param name="del">The callback that is called when the viewModel wants to return something</param>
        public void Init(ReturnDataDel del)
        {
            returnDataDel = del;
        }

        /// <summary>
        /// Is called when the viewModel wants to return something
        /// </summary>
        /// <param name="data">The returning data</param>
        protected void ReturnData(T data)
        {
            returnDataDel?.Invoke(data);
            CloseWindow();
        }

        /// <summary>
        /// Is called when the window closes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Closing(object sender, CancelEventArgs e)
        {
            if (!hasReturned)
                ReturnData(null);
        }
    }
}
