using Moq;
using RadioTrainingCreator.Data;
using RadioTrainingCreator.GUI.Services.Interfaces;
using RadioTrainingCreator.GUI.Services.Interfaces.FileInterfaces;
using RadioTrainingCreator.GUI.ViewModels.WelcomeViewModels.NewProjectViewModels;
using RadioTrainingCreator.Tests.Basics;
using Xunit;

namespace RadioTrainingCreator.Tests.GUI.ViewModels.WelcomeViewModelsTests
{
    public class NewProjectViewModel_Tests : BaseTest
    {
        #region UpdateFullPath

        [Theory]
        [InlineData(@"C:\Feuerwehr", "Uebung", "Uebung.fue", @"C:\Feuerwehr\Uebung.fue")]
        [InlineData(@"C:\Feuerwehr\", "Uebung", "Uebung.fue", @"C:\Feuerwehr\Uebung.fue")]
        [InlineData(@"C:\Feuerwehr", "", "", @"C:\Feuerwehr")]
        [InlineData(@"C:\Feuerwehr\", "", "", @"C:\Feuerwehr")]
        [InlineData(@"", "Uebung", "Uebung.fue", @"Uebung.fue")]
        public void UpdateFullPath_Tests(string folder, string name, string nameExpected, string expected)
        {
            var mock = new Mock<IFileDialogService>();
            var vm = new NewProjectViewModel(mock.Object)
            {
                ProjectName = name
            };
            Assert.Equal(nameExpected, vm.FullPath);
            vm.ProjectFolder = folder;
            Assert.Equal(expected, vm.FullPath);
        }

        [Theory]
        [InlineData(@"C:\Feuerwehr", "Uebung", @"C:\Feuerwehr", @"C:\Feuerwehr\Uebung.fue")]
        [InlineData(@"C:\Feuerwehr\", "Uebung", @"C:\Feuerwehr", @"C:\Feuerwehr\Uebung.fue")]
        [InlineData(@"C:\Feuerwehr", "", @"C:\Feuerwehr", @"C:\Feuerwehr")]
        [InlineData(@"C:\Feuerwehr\", "", @"C:\Feuerwehr", @"C:\Feuerwehr")]
        [InlineData(@"", "Uebung", "", @"Uebung.fue")]
        public void UpdateFullPath_FolderFirst_Tests(string folder, string name, string folderExpected, string fullExpected)
        {
            var mock = new Mock<IFileDialogService>();
            var vm = new NewProjectViewModel(mock.Object)
            {
                ProjectFolder = folder
            };
            Assert.Equal(folderExpected, vm.FullPath);
            vm.ProjectName = name;
            Assert.Equal(fullExpected, vm.FullPath);
        }

        #endregion
        
        #region GetFolder

        [Theory]
        [InlineData(@"F:\Feuerwehr")]
        [InlineData(@"F:\Feuerwehr\")]
        [InlineData(@"")]
        public void GetFolder_Tests(string expected)
        {
            var mock = new Mock<IFileDialogService>();
            mock.Setup(service => service.GetFolder()).Returns(expected);

            var newProjectViewModel = new NewProjectViewModel(mock.Object);
            newProjectViewModel.DoChooseFolder();
            Assert.Equal(expected, newProjectViewModel.ProjectFolder);
        }

        #endregion

        #region CurrentOpenedProject

        /// <summary>
        /// Checks if the current opened project is the created project
        /// </summary>
        [Fact]
        public void CurrentOpenedProject_Test()
        {
            var mock = new Mock<IFileDialogService>();
            mock.Setup(service => service.GetFolder()).Returns("");

            string folder = $"{TEST_ENVIRONMENT}";
            string name = $"uebung.fue";

            RequireNotExistingFile(folder, name);

            var newProjectViewModel = new NewProjectViewModel(mock.Object)
            {
                ProjectName = "uebung",
                ProjectFolder = folder,
                Author = "Max",
                Comment = "ExampleComment"
            };

            newProjectViewModel.DoCreateRadioTraining();
            //CurrentOpenedProject.Instance.RadioTraining.Name ==
            Assert.Equal("uebung", CurrentOpenedProject.Instance.RadioTraining.Name);
            Assert.Equal("Max", CurrentOpenedProject.Instance.RadioTraining.Author);
            Assert.Equal("ExampleComment", CurrentOpenedProject.Instance.RadioTraining.Comment);
        }

        /// <summary>
        /// Checks if the current opened filePath is correct
        /// </summary>
        [Fact]
        public void CurrenttProjectFilePath_Test()
        {
            var mock = new Mock<IFileDialogService>();
            mock.Setup(service => service.GetFolder()).Returns("");

            string folder = $"{TEST_ENVIRONMENT}";
            string name = $"uebung.fue";

            RequireNotExistingFile(folder, name);

            var newProjectViewModel = new NewProjectViewModel(mock.Object)
            {
                ProjectName = "uebung",
                ProjectFolder = folder,
                Author = "Max",
                Comment = "ExampleComment"
            };

            string fullPath = $"{folder}{name}";

            newProjectViewModel.DoCreateRadioTraining();
            Assert.Equal(fullPath, CurrentOpenedProject.Instance.OpenedProjectFile);
        }

        #endregion
    }
}
