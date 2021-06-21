using RadioTrainingCreator.GUI.ViewModels.DataWindowsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RadioTrainingCreator.GUI.Views.Windows.DataWindows
{
    /// <summary>
    /// Interaktionslogik für RadioTrainingDataWindow.xaml
    /// </summary>
    public partial class RadioTrainingDataWindow : Window
    {
        public RadioTrainingDataWindowViewModel DataViewModel { get; set; }

        public RadioTrainingDataWindow()
        {
            InitializeComponent();
        }

        public void SetUpDataContext(RadioTrainingDataWindowViewModel radioTrainingWindow)
        {
            DataViewModel = radioTrainingWindow;
            DataContext = radioTrainingWindow;
            Closing += radioTrainingWindow.Closing;
        }
    }
}
