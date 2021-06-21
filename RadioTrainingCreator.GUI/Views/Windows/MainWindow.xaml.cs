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
                    return new MainWindow();

                return instance;
            }
        }

        #endregion

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
