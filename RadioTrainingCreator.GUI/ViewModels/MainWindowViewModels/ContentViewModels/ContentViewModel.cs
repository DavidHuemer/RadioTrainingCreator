﻿using RadioTrainingCreator.GUI.ViewModels.Basics;
using RadioTrainingCreator.GUI.ViewModels.MainWindowViewModels.ContentViewModels.FireDepartments;
using RadioTrainingCreator.GUI.ViewModels.MainWindowViewModels.ContentViewModels.Locations;

namespace RadioTrainingCreator.GUI.ViewModels.MainWindowViewModels.ContentViewModels
{
    /// <summary>
    /// Handles the navigation between the different pages
    /// </summary>
    public class ContentViewModel : BaseViewModel
    {
        public FireDepartmentsPageViewModel FireDepartmentsPage { get; set; }
        public LocationsPageViewModel LocationsPage { get; set; }

        public ContentViewModel()
        {
            FireDepartmentsPage = new FireDepartmentsPageViewModel();
            LocationsPage = new LocationsPageViewModel();
        }
    }
}