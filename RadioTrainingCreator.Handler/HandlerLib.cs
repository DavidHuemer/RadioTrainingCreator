namespace RadioTrainingCreator.Handler
{
    /// <summary>
    /// Contains handlers for the entire application
    /// </summary>
    public class HandlerLib
    {
        #region Singleton

        private static HandlerLib instance = null;
        public static HandlerLib Instance
        {
            get
            {
                if (instance == null)
                    instance = new HandlerLib();

                return instance;
            }
        }

        #endregion
    }
}
