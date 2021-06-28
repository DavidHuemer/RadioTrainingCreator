using System;

namespace RadioTrainingCreator.Data
{
    [Serializable]
    public class FireDepartment
    {
        public string RadioCallName { get; set; } = "";
        public string Name { get; set; } = "";

        /// <summary>
        /// RadioCallName + Name
        /// </summary>
        public string FullName
        {
            get => $"{RadioCallName} {Name}";
        }
    }
}
