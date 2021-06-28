using RadioTrainingCreator.Data;

namespace RadioTrainingCreator.Handler.FilesHandler
{
    public class SaveManager
    {
        #region Singleton

        private static SaveManager instance;
        public static SaveManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new SaveManager();

                return instance;
            }
        }

        #endregion

        private SaveManager()
        {

        }

        public bool IsSaved { get; private set; }

        public void Save()
        {
            string path = CurrentOpenedProject.Instance.OpenedProjectFile;
            var project = CurrentOpenedProject.Instance.RadioTraining;

            RadioTrainingProjectHandler.SaveRadioTraining(path, project);
            IsSaved = true;
        }

        public void Unsave()
        {
            IsSaved = false;
        }
    }
}
