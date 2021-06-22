using MVVM.Tools;
using RadioTrainingCreator.Data.Files;
using RadioTrainingCreator.GUI.Services.FileServices;
using RadioTrainingCreator.GUI.Services.Interfaces;
using RadioTrainingCreator.GUI.Services.Interfaces.FileInterfaces;
using RadioTrainingCreator.GUI.Services.Services.WindowServices;
using RadioTrainingCreator.GUI.ViewModels.Basics;
using RadioTrainingCreator.GUI.ViewModels.DataWindowsViewModels;
using System;

namespace RadioTrainingCreator.GUI.ViewModels.MainWindowViewModels.MenuViewModels
{
    public class MainMenuViewModel : BaseViewModel
    {
        private readonly IWindowService windowService;
        private readonly IFileDialogService fileDialogService;

        public MainMenuViewModel(IFileDialogService fileDialogService)
        {
            windowService = WindowServiceHandler.GetCorrectWindowService();
            this.fileDialogService = fileDialogService;
        }

        public MainMenuViewModel() : this(new FileDialogService())
        {

        }

        public RelayCommand<string> NewProject => new RelayCommand<string>(x =>
        {
            DoCreateNewProject();
        }, x => true);

        public void DoCreateNewProject()
        {
            Console.WriteLine("New Project clicked");
            var newProjectVm = new RadioTrainingDataWindowViewModel(fileDialogService);
            newProjectVm.Init(NewProjectCreated);
            windowService.Open(newProjectVm);
        }

        private void NewProjectCreated(CreatedRadioTraining data)
        {
            if (data == null)
                return;
            MainWindowViewModel.Instance.Open(data.FilePath, data.RadioTraining);
        }
    }
}
