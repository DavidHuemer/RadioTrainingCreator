using RadioTrainingCreator.GUI.ViewModels.MainWindowViewModels;
using System.Windows;

namespace RadioTrainingCreator.GUI.Views.Windows
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Singleton

        private static MainWindow instance;
        public static MainWindow Instance
        {
            get
            {
                if (instance == null)
                    instance = new MainWindow();

                return instance;
            }
        }

        #endregion

        public MainWindow()
        {
            InitializeComponent();
            DataContext = MainWindowViewModel.Instance;
            MainWindowViewModel.Instance.Init(Close);
            Closing += MainWindowViewModel.Instance.WindowClosing;
        }
    }
}
