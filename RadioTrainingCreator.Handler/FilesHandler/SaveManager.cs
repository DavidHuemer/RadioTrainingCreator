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
    }
}
