using MVVM.Tools;
using RadioTrainingCreator.GUI.ViewModels.Basics;
using System;

namespace RadioTrainingCreator.GUI.ViewModels.MainWindowViewModels.MenuViewModels
{
    public class MainMenuViewModel : BaseViewModel
    {
        public MainMenuViewModel()
        {

        }

        public RelayCommand<string> NewProject => new RelayCommand<string>(x =>
        {
            DoNewProject();
        }, x => true);

        public void DoNewProject()
        {
            Console.WriteLine("New Project clicked");
        }
    }
}
