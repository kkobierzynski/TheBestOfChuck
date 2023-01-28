using Castle.Core.Logging;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using System.ComponentModel.Design;
using TheBestOfChuck.Exceptions;
using TheBestOfChuck.Services;

namespace TheBestOfChuck.UnitTests
{
    public class CollectDataServiceTests
    {
        private readonly CollectDataService _collectData;
        private readonly ILogger<CollectDataService> _logger;
        private readonly Mock<IServiceHelper> _serviceHelper = new Mock<IServiceHelper>();
        private readonly Mock<IHttpClientService> _httpClientService = new Mock<IHttpClientService>();
        private readonly Mock<ISaveDataService> _saveDataService = new Mock<ISaveDataService>();

        public CollectDataServiceTests()
        {
            _collectData = new CollectDataService(_logger, _httpClientService.Object, _saveDataService.Object, _serviceHelper.Object);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-12)]
        public void collectMultipleJokesAsync_InvalidInputData_ThrowsException(int jokesNumber)
        {
            //Arrange

            //Act
            var result = () => _collectData.collectMultipleJokesAsync(jokesNumber);

            //Assert
            result.Should().ThrowAsync<InvalidInputDataException>();

        }

        [Theory]
        [InlineData(2, "test", 2, 0, false)]
        [InlineData(2, "test", 2, 2, true)]
        public void collectMultipleJokesAsync_WithCorrectInputData_ExecuteServicesCorrectNumberOfTimes(int jokesNumber, string joke, int clientServiceTimes, int dataServiceTimes, bool isExceeding)
        {
            //Arrange
            _httpClientService.Setup(x => x.ReturnChuckJoke()).ReturnsAsync(joke);
            _serviceHelper.Setup(x => x.isExceedingLength(It.IsAny<string>(), It.IsAny<int>())).Returns(isExceeding);
            
            //Act
            var result = _collectData.collectMultipleJokesAsync(jokesNumber);

            //Assert
            _httpClientService.Verify(x => x.ReturnChuckJoke(), Times.Exactly(clientServiceTimes));
            _saveDataService.Verify(x => x.SaveUniqueChuckJoke(joke), Times.Exactly(dataServiceTimes));

        }

    }
}