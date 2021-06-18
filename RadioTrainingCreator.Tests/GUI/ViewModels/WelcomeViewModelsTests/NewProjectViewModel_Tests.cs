using Moq;
using RadioTrainingCreator.GUI.Services.Interfaces;
using RadioTrainingCreator.GUI.ViewModels.WelcomeViewModels.NewProjectViewModels;
using Xunit;

namespace RadioTrainingCreator.Tests.GUI.ViewModels.WelcomeViewModelsTests
{
    public class NewProjectViewModel_Tests
    {
        #region UpdateFullPath

        [Theory]
        [InlineData(@"C:\Feuerwehr", "Uebung", @"C:\Feuerwehr\Uebung")]
        [InlineData(@"C:\Feuerwehr\", "Uebung", @"C:\Feuerwehr\Uebung")]
        [InlineData(@"C:\Feuerwehr", "", @"C:\Feuerwehr\")]
        [InlineData(@"C:\Feuerwehr\", "", @"C:\Feuerwehr\")]
        [InlineData(@"", "Uebung", @"Uebung")]
        public void UpdateFullPath_Tests(string folder, string name, string expected)
        {
            var mock = new Mock<IFileDialogService>();
            var vm = new NewProjectViewModel(mock.Object)
            {
                ProjectName = name
            };
            Assert.Equal(name, vm.FullPath);
            vm.ProjectFolder = folder;
            Assert.Equal(expected, vm.FullPath);
        }

        [Theory]
        [InlineData(@"C:\Feuerwehr", "Uebung", @"C:\Feuerwehr\", @"C:\Feuerwehr\Uebung")]
        [InlineData(@"C:\Feuerwehr\", "Uebung", @"C:\Feuerwehr\", @"C:\Feuerwehr\Uebung")]
        [InlineData(@"C:\Feuerwehr", "", @"C:\Feuerwehr\", @"C:\Feuerwehr\")]
        [InlineData(@"C:\Feuerwehr\", "", @"C:\Feuerwehr\", @"C:\Feuerwehr\")]
        [InlineData(@"", "Uebung", "", @"Uebung")]
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
    }
}
