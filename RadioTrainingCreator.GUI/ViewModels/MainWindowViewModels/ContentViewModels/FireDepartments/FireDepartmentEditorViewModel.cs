using RadioTrainingCreator.Data;
using RadioTrainingCreator.GUI.ViewModels.Basics;

namespace RadioTrainingCreator.GUI.ViewModels.MainWindowViewModels.ContentViewModels.FireDepartments
{
    public class FireDepartmentEditorViewModel : EditorViewModel<FireDepartment>
    {
        public string RadioCallName { get; set; } = "";
        public string Name { get; set; } = "";

        public override void Clear()
        {
            RadioCallName = "";
            Name = "";
        }
    }
}
