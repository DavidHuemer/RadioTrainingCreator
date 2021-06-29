using RadioTrainingCreator.Data.Basics;
using System;

namespace RadioTrainingCreator.Data
{
    [Serializable]
    public class FireDepartment : RadioTrainingObject
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
