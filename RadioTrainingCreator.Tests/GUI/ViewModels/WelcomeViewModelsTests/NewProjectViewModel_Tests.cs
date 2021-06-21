using Moq;
using RadioTrainingCreator.Data;
using RadioTrainingCreator.GUI.Services.Interfaces.FileInterfaces;
using RadioTrainingCreator.GUI.ViewModels.WelcomeViewModels.NewProjectViewModels;
using RadioTrainingCreator.Tests.Basics;
using System;
using Xunit;

namespace RadioTrainingCreator.Tests.GUI.ViewModels.WelcomeViewModelsTests
{
    public class NewProjectViewModel_Tests : BaseTest
    {
        private bool callbackCalled = false;

        [Fact]
        public void Check_Callback()
        {
            var mock = new Mock<IFileDialogService>();
            var newProjectVm = new NewProjectViewModel(mock.Object);
            newProjectVm.Init(ProjectCreatedCallback);

            string folder = $"{TEST_ENVIRONMENT}";
            string name = $"uebung.fue";

            RequireNotExistingFile(folder, name);

            newProjectVm.DataViewModel.ProjectName = "uebung";
            newProjectVm.DataViewModel.ProjectFolder = folder;
            newProjectVm.DataViewModel.Author = "Max";
            newProjectVm.DataViewModel.Comment = "ExampleComment";

            newProjectVm.DataViewModel.DoCreateRadioTraining();
            Assert.True(callbackCalled);
        }

        private void ProjectCreatedCallback()
        {
            callbackCalled = true;
        }
    }
}
