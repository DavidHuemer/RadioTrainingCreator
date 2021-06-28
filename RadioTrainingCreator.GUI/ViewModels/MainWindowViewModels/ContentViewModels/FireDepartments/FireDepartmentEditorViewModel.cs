using RadioTrainingCreator.Data;
using RadioTrainingCreator.Data.Extensions;
using RadioTrainingCreator.GUI.ViewModels.Basics.EditorViewModels;

namespace RadioTrainingCreator.GUI.ViewModels.MainWindowViewModels.ContentViewModels.FireDepartments
{
    public class FireDepartmentEditorViewModel : RadioTrainingEditorViewModel<FireDepartment>
    {
        #region Properties

        #region RadioCallName

        private string radioCallName = "";
        public string RadioCallName
        {
            get => radioCallName;
            set
            {
                radioCallName = value;
                UpdateCanSave();
            }
        }

        #endregion

        #region Name

        private string name = "";
        public string Name
        {
            get => name; 
            set
            {
                name = value;
                UpdateCanSave();
            }
        }

        #endregion

        #endregion

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

        protected override void UpdateCanSave()
        {
            var areEmpty = StringExtensions.AreEmpty(RadioCallName, Name);
            CanSave = !areEmpty;
        }

        protected override void UpdateCurrent()
        {
            throw new System.NotImplementedException();
        }
    }
}
