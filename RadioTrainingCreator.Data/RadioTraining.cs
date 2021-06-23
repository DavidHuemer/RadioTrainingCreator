using System;
using System.Collections.ObjectModel;

namespace RadioTrainingCreator.Data
{
    [Serializable]
    public class RadioTraining
    {
        public string Name { get; set; } = "";
        public string Author { get; set; } = "";
        public string Comment { get; set; } = "";

        public ObservableCollection<FireDepartment> FireDepartments { get; set; } = new ObservableCollection<FireDepartment>();
        public FireDepartment Florian { get; set; } = null;
    }
}
