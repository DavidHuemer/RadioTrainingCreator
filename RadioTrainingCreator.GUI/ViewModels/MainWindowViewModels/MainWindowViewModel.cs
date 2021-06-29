using MVVM.Tools;
using RadioTrainingCreator.Data;
using RadioTrainingCreator.GUI.Services.Services.FileServices;
using RadioTrainingCreator.GUI.ViewModels.Basics;
using RadioTrainingCreator.GUI.ViewModels.MainWindowViewModels.ContentViewModels;
using RadioTrainingCreator.Handler;
using RadioTrainingCreator.Handler.FilesHandler;
using System;
using System.ComponentModel;

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

        public MainWindowViewModel() : base("RadioTrainingCreator")
        {
            CurrentRadioTraining = CurrentOpenedProject.Instance.RadioTraining;
            CurrentOpenedProject.Instance.CurrentProjectChanged += CurrentProject_Changed;
            CurrentOpenedProject.Instance.ProjectPropertyChanged += ProjectProperty_Changed;

            ContentVM = new ContentViewModel();
        }

        public void WindowClosing(object sender, CancelEventArgs e)
        {
            SaveService.CheckSaving(MessageService, e);
        }

        #endregion

        public RadioTraining CurrentRadioTraining { get; set; }

        public ContentViewModel ContentVM { get; set; }

        /// <summary>
        /// Opens the RadioTraining
        /// </summary>
        /// <param name="path">The path to the RadioTrainingFile that will be opened</param>
        public void Open(string path)
        {
            //var radioTraining = RadioTrainingProjectHandler.LoadRadioTraining();
        }

        /// <summary>
        /// Opens the RadioTraining
        /// </summary>
        /// <param name="path">The path to the radioTrainingFile</param>
        /// <param name="radioTraining">The radioTraining that will be opened</param>
        public void Open(string path, RadioTraining radioTraining)
        {
            CurrentOpenedProject.Instance.Init(radioTraining, path);
            HandlerLib.Instance.RecentlyOpenedFilesHandler.AddRecentlyOpenedFile(path);
        }

        private void CurrentProject_Changed(object sender, EventArgs e)
        {
            CurrentRadioTraining = CurrentOpenedProject.Instance.RadioTraining;
        }

        private void ProjectProperty_Changed(object sender, EventArgs e)
        {
            SaveManager.Instance.Unsave();
        }

        public RelayCommand<string> Save => new RelayCommand<string>(o => { DoSave(); }, o => true);
        public void DoSave() => SaveService.Save(MessageService);
    }
}
