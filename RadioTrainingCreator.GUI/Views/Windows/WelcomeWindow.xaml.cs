using RadioTrainingCreator.GUI.ViewModels.WelcomeViewModels;
using System.Windows;

namespace RadioTrainingCreator.GUI.Views.Windows
{
    /// <summary>
    /// Interaktionslogik für WelcomeWindow.xaml
    /// </summary>
    public partial class WelcomeWindow : Window
    {
        public WelcomeWindow()
        {
            InitializeComponent();

            var vm = DataContext as WelcomeWindowViewModel;
            vm.Init(Close);
            DataContext = vm;
        }
    }
}
