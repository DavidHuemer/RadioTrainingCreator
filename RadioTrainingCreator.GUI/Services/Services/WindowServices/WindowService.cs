using RadioTrainingCreator.GUI.Services.Interfaces;
using RadioTrainingCreator.GUI.ViewModels.Basics;
using RadioTrainingCreator.GUI.ViewModels.DataWindowsViewModels;
using RadioTrainingCreator.GUI.ViewModels.MainWindowViewModels;
using RadioTrainingCreator.GUI.Views.Windows;
using RadioTrainingCreator.GUI.Views.Windows.DataWindows;

namespace RadioTrainingCreator.GUI.Services.Services.WindowServices
{
    public class WindowService : IWindowService
    {
        public void Open(BaseViewModel viewModel)
        {
            if(viewModel is MainWindowViewModel)
            {
                OpenMainWindowViewModel(viewModel as MainWindowViewModel);
            }

            if(viewModel is RadioTrainingDataWindowViewModel)
            {
                ShowRadioTrainingDataWindowViewModel(viewModel as RadioTrainingDataWindowViewModel);
            }
        }

        private void OpenMainWindowViewModel(MainWindowViewModel mainWindowViewModel)
        {
            MainWindow.Instance.Show();
            //MainWindow.Instance.DataContext = mainWindowViewModel;
        }

        private void ShowRadioTrainingDataWindowViewModel(RadioTrainingDataWindowViewModel radioTrainingWindow)
        {
            var window = new RadioTrainingDataWindow();
            window.SetUpDataContext(radioTrainingWindow);
            window.ShowDialog();
        }
    }
}
