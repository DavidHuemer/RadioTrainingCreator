using Moq;
using RadioTrainingCreator.Handler.FilesHandler;
using RadioTrainingCreator.Handler.Services.Interfaces.FileInterfaces;
using Xunit;

namespace RadioTrainingCreator.Tests.Handler.FilesHandler
{
    public class RecentlyOpenedFilesHandler_Tests
    {
        [Fact]
        public void GetRecentlyOpenedFiles_Test()
        {
            var mock = new Mock<IRecentlyOpenedFilesService>();
            mock.Setup(service => service.GetRecentlyOpenedProjectsJSON()).Returns("[\"C:/Test/uebung.fue\"]");

            var handler = new RecentlyOpenedFilesHandler(mock.Object);
            var recentlyOpenedList = handler.GetRecentlyOpenedFiles();
            Assert.Single(recentlyOpenedList);
            var recentlyOpened = recentlyOpenedList[0];
            Assert.Equal("uebung", recentlyOpened.Name);
            Assert.Equal("C:/Test/uebung.fue", recentlyOpened.Path);
        }

        [Fact]
        public void GetRecentlyOpenedFiles_EmptyArrJSONTest()
        {
            var mock = new Mock<IRecentlyOpenedFilesService>();
            mock.Setup(service => service.GetRecentlyOpenedProjectsJSON()).Returns("[]");

            var handler = new RecentlyOpenedFilesHandler(mock.Object);
            var recentlyOpenedList = handler.GetRecentlyOpenedFiles();
            Assert.Empty(recentlyOpenedList);
        }

        [Fact]
        public void GetRecentlyOpenedFiles_NoJSONTest()
        {
            var mock = new Mock<IRecentlyOpenedFilesService>();
            mock.Setup(service => service.GetRecentlyOpenedProjectsJSON()).Returns("");

            var handler = new RecentlyOpenedFilesHandler(mock.Object);
            var recentlyOpenedList = handler.GetRecentlyOpenedFiles();
            Assert.Empty(recentlyOpenedList);
        }
    }
}
