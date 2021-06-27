using RadioTrainingCreator.Data.Files;
using System;

namespace RadioTrainingCreator.Data
{
    /// <summary>
    /// Contains the currently opened project and its file
    /// </summary>
    public class CurrentOpenedProject
    {
        #region Singleton

        private static CurrentOpenedProject instance;
        public static CurrentOpenedProject Instance
        {
            get
            {
                if (instance == null)
                    instance = new CurrentOpenedProject();

                return instance;
            }
        }
        private CurrentOpenedProject()
        {

        }

        #endregion

        #region Properties

        public event EventHandler<EventArgs> CurrentProjectChanged;

        /// <summary>
        /// The current opened project
        /// </summary>
        public RadioTraining RadioTraining { get; set; }

        /// <summary>
        /// The filePath of the current opened project
        /// </summary>
        public string OpenedProjectFile { get; set; }

        #endregion

        #region Init

        /// <summary>
        /// Sets the radioTraining and the path
        /// </summary>
        /// <param name="radioTraining">The current opened RadioTraining</param>
        /// <param name="path">The path to the current opened RadioTraining</param>
        public void Init(RadioTraining radioTraining, string path)
        {
            RadioTraining = radioTraining;
            OpenedProjectFile = path;
            CurrentProjectChanged?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Sets the RadioTraining and the path
        /// </summary>
        /// <param name="createdRadioTraining">The created RadioTraining with the RadioTraining and the path</param>
        public void Init(CreatedRadioTraining createdRadioTraining)
        {
            Init(createdRadioTraining.RadioTraining, createdRadioTraining.FilePath);
        }
        
        #endregion
    }
}
