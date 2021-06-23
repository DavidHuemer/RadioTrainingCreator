using RadioTrainingCreator.GUI.ViewModels.Basics;

namespace RadioTrainingCreator.GUI.ViewModels.MainWindowViewModels.ContentViewModels.FireDepartments
{
    public class FireDepartmentsPageViewModel : PageViewModel
    {
        public FireDepartmentEditorViewModel FireDepartmentEditor { get; set; }

        public FireDepartmentsPageViewModel() : base("Feuerwehren")
        {
            FireDepartmentEditor = new FireDepartmentEditorViewModel();
        }
    }
}
