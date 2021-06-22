using MVVM.Tools;
using RadioTrainingCreator.Data.Files;
using RadioTrainingCreator.GUI.Services.FileServices;
using RadioTrainingCreator.GUI.Services.Interfaces;
using RadioTrainingCreator.GUI.Services.Interfaces.FileInterfaces;
using RadioTrainingCreator.GUI.Services.Services.WindowServices;
using RadioTrainingCreator.GUI.ViewModels.Basics;
using RadioTrainingCreator.GUI.ViewModels.DataWindowsViewModels;
using RadioTrainingCreator.Handler.FilesHandler;
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

        #region Commands

        #region New Project

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

        #endregion

        #region Open Project

        public RelayCommand<string> OpenProject => new RelayCommand<string>(x =>
        {
            DoOpenProject();
        }, x => true);

        public void DoOpenProject()
        {
            Console.WriteLine("Open Project clicked");
            var radioTrainingFilePath = fileDialogService.GetRadioTrainingFile();
            DoOpenProject(radioTrainingFilePath);
        }

        #endregion

        #region Close Command

        public RelayCommand<string> Close => new RelayCommand<string>(x =>
        {
            DoCloseProject();
        }, x => true);

        public void DoCloseProject()
        {
            MainWindowViewModel.Instance.CloseWindow();
        }

        #endregion

        #endregion

        private void NewProjectCreated(CreatedRadioTraining data)
        {
            if (data == null)
                return;
            MainWindowViewModel.Instance.Open(data.FilePath, data.RadioTraining);
        }

        public void DoOpenProject(string path)
        {
            if (path == null)
                return;

            try
            {
                var radioTraining = RadioTrainingProjectHandler.LoadRadioTraining(path);
                MainWindowViewModel.Instance.Open(path, radioTraining);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageService.ShowWarning("Fehler beim öffnen","Konnte die Funkübung nicht öffnen");
            }
        }
    }
}
