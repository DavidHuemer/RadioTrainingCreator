using RadioTrainingCreator.GUI.Services.Interfaces;
using RadioTrainingCreator.GUI.ViewModels.Basics;
using RadioTrainingCreator.GUI.ViewModels.MainWindowViewModels;
using RadioTrainingCreator.GUI.Views.Windows;

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
        }

        private void OpenMainWindowViewModel(MainWindowViewModel mainWindowViewModel)
        {
            MainWindow.Instance.Show();
            //MainWindow.Instance.DataContext = mainWindowViewModel;
        }
    }
}
