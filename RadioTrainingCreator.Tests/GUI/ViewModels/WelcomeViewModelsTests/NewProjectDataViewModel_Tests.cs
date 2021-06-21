using Moq;
using RadioTrainingCreator.GUI.Services.Interfaces.FileInterfaces;
using RadioTrainingCreator.GUI.ViewModels.WelcomeViewModels.NewProjectViewModels;
using RadioTrainingCreator.Tests.Basics;
using Xunit;

namespace RadioTrainingCreator.Tests.GUI.ViewModels.WelcomeViewModelsTests
{
    public class NewProjectDataViewModel_Tests : BaseTest
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
            var vm = new NewProjectDataViewModel(mock.Object)
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
            var vm = new NewProjectDataViewModel(mock.Object)
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

            var vm = new NewProjectDataViewModel(mock.Object);
            vm.DoChooseFolder();
            Assert.Equal(expected, vm.ProjectFolder);
        }

        #endregion
    }
}
