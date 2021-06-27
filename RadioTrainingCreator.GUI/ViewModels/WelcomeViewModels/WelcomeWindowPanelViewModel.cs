using RadioTrainingCreator.Data;
using RadioTrainingCreator.GUI.ViewModels.Basics;
using System;

namespace RadioTrainingCreator.GUI.ViewModels.WelcomeViewModels
{
    public class WelcomeWindowPanelViewModel : BaseViewModel
    {
        private Action<string, RadioTraining> openProjectCallback;

        /// <summary>
        /// Inits the project created callback
        /// </summary>
        /// <param name="closeCallback">The callback that should be called when the viewmodel wants to open a project</param>
        public void InitOpenProject(Action<string, RadioTraining> closeCallback)
        {
            this.openProjectCallback = closeCallback;
        }

        /// <summary>
        /// Calls the open project callback
        /// </summary>
        public void OpenProject(string filePath, RadioTraining radioTraining)
        {
            openProjectCallback?.Invoke(filePath, radioTraining);
        }
    }
}
