using System;

namespace RadioTrainingCreator.Data
{
    [Serializable]
    public class RadioTraining
    {
        public string Name { get; set; } = "";
        public string Author { get; set; } = "";
        public string Comment { get; set; } = "";
    }
}
