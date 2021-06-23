using MVVM.Tools;
using RadioTrainingCreator.GUI.ViewModels.Basics;
using RadioTrainingCreator.GUI.ViewModels.MainWindowViewModels.ContentViewModels.FireDepartments;
using RadioTrainingCreator.GUI.ViewModels.MainWindowViewModels.ContentViewModels.Locations;
using System;

namespace RadioTrainingCreator.GUI.ViewModels.MainWindowViewModels.ContentViewModels
{
    /// <summary>
    /// Handles the navigation between the different pages
    /// </summary>
    public class ContentViewModel : BaseViewModel
    {
        public FireDepartmentsPageViewModel FireDepartmentsPage { get; set; } = null;
        public LocationsPageViewModel LocationsPage { get; set; } = null;
        public PageViewModel CurrentPage { get; set; } = null;

        public ContentViewModel()
        {
            FireDepartmentsPage = new FireDepartmentsPageViewModel();
            LocationsPage = new LocationsPageViewModel();
            CurrentPage = FireDepartmentsPage;
        }

        public RelayCommand<PageViewModel> ChangePage => new RelayCommand<PageViewModel>(o => { DoChangePage(o); }, o => true);

        private void DoChangePage(PageViewModel o)
        {
            Console.WriteLine($"Change current page to {o.DisplayName}");
            CurrentPage = o;
        }
    }
}
