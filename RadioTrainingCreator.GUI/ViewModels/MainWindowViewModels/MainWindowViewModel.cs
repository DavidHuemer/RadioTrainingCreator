using RadioTrainingCreator.GUI.ViewModels.Basics;

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
    }
}
