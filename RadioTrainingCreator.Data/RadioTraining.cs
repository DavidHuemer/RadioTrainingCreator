using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace RadioTrainingCreator.Data
{
    [Serializable]
    public class RadioTraining : INotifyPropertyChanged
    {
        public string Name { get; set; } = "";
        public string Author { get; set; } = "";
        public string Comment { get; set; } = "";

        public ObservableCollection<FireDepartment> FireDepartments { get; set; } = new ObservableCollection<FireDepartment>();
        public FireDepartment Florian { get; set; } = null;

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
