namespace RadioTrainingCreator.Data.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Checks if a string of the values is empty
        /// </summary>
        /// <param name="values">The string params that should be checked</param>
        /// <returns>Returns if a string of the params is empty</returns>
        public static bool AreEmpty(params string[] values)
        {
            foreach (var item in values)
            {
                if (string.IsNullOrWhiteSpace(item))
                    return true;
            }

            return false;
        }
    }
}
