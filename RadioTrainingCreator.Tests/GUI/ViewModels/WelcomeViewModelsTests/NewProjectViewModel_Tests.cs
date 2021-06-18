using Moq;
using RadioTrainingCreator.GUI.Services.Interfaces;
using RadioTrainingCreator.GUI.ViewModels.WelcomeViewModels.NewProjectViewModels;
using Xunit;

namespace RadioTrainingCreator.Tests.GUI.ViewModels.WelcomeViewModelsTests
{
    public class NewProjectViewModel_Tests
    {
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
