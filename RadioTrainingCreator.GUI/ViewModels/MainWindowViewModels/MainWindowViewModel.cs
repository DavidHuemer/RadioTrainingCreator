using RadioTrainingCreator.Data;
using RadioTrainingCreator.GUI.ViewModels.Basics;
using RadioTrainingCreator.Handler;

namespace RadioTrainingCreator.GUI.ViewModels.MainWindowViewModels
{
    public class MainWindowViewModel : WindowViewModel
    {
        #region Singleton

        private static MainWindowViewModel instance = null;
        public static MainWindowViewModel Instance
        {
            get
            {
                if (instance == null)
                    instance = new MainWindowViewModel();
                return instance;
            }
        }

        private MainWindowViewModel() : base("RadioTrainingCreator")
        {

        }

        #endregion

        /// <summary>
        /// Opens the RadioTraining
        /// </summary>
        /// <param name="path">The path to the RadioTrainingFile that will be opened</param>
        public void Open(string path)
        {
            //var radioTraining = RadioTrainingProjectHandler.LoadRadioTraining();
        }

        /// <summary>
        /// Opens the RadioTraining
        /// </summary>
        /// <param name="path">The path to the radioTrainingFile</param>
        /// <param name="radioTraining">The radioTraining that will be opened</param>
        public void Open(string path, RadioTraining radioTraining)
        {
            CurrentOpenedProject.Instance.Init(radioTraining, path);
            HandlerLib.Instance.RecentlyOpenedFilesHandler.AddRecentlyOpenedFile(path);
        }
    }
}
