using System;
using System.ComponentModel;

namespace RadioTrainingCreator.Data.Basics
{
    /// <summary>
    /// Base class for all RadioTraining objects
    /// </summary>
    [Serializable]
    public class RadioTrainingObject : INotifyPropertyChanged
    {
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
