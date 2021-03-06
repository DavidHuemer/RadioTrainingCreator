using RadioTrainingCreator.Data.RadioTrainingObjects;
using RadioTrainingCreator.GUI.ViewModels.Basics.PageViewModels;

namespace RadioTrainingCreator.GUI.ViewModels.MainWindowViewModels.ContentViewModels.Locations
{
    public class LocationsPageViewModel : RadioTrainingItemPageViewModel<Location>
    {
        public LocationEditorViewModel LocationEditor { get; set; }

        public LocationsPageViewModel() : base("Koordinaten")
        {
            LocationEditor = new LocationEditorViewModel();
        }

        public override void DoAdd()
        {
            throw new System.NotImplementedException();
        }

        public override void ShowUpdateCurrent(Location item)
        {
            throw new System.NotImplementedException();
        }
    }
}
