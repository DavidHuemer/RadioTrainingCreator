using RadioTrainingCreator.Data;
using RadioTrainingCreator.GUI.ViewModels.Basics;
using RadioTrainingCreator.GUI.ViewModels.Basics.PageViewModels;

namespace RadioTrainingCreator.GUI.ViewModels.MainWindowViewModels.ContentViewModels.FireDepartments
{
    public class FireDepartmentsPageViewModel : RadioTrainingItemPageViewModel<FireDepartment>
    {
        public FireDepartmentEditorViewModel FireDepartmentEditor { get; set; }

        public FireDepartmentsPageViewModel() : base("Feuerwehren")
        {
            FireDepartmentEditor = new FireDepartmentEditorViewModel();
        }

        public override void DoAdd()
        {
            FireDepartmentEditor.ShowCreateNew();
        }

        public override void ShowUpdateCurrent(FireDepartment item)
        {
            FireDepartmentEditor.ShowUpdateItem(item);
        }
    }
}
