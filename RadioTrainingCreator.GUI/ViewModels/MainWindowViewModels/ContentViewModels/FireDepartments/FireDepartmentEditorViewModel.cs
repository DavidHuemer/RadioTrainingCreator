using RadioTrainingCreator.Data;
using RadioTrainingCreator.GUI.ViewModels.Basics.EditorViewModels;

namespace RadioTrainingCreator.GUI.ViewModels.MainWindowViewModels.ContentViewModels.FireDepartments
{
    public class FireDepartmentEditorViewModel : RadioTrainingEditorViewModel<FireDepartment>
    {
        public string RadioCallName { get; set; } = "";
        public string Name { get; set; } = "";

        public override void Clear()
        {
            RadioCallName = "";
            Name = "";
        }

        protected override void CreateNew()
        {
            var newFireDepartment = new FireDepartment
            {
                RadioCallName = RadioCallName,
                Name = Name,
            };

            CurrentOpenedProject.Instance.RadioTraining.FireDepartments.Add(newFireDepartment);
            Hide();
        }

        protected override void UpdateCurrent()
        {
            throw new System.NotImplementedException();
        }
    }
}
