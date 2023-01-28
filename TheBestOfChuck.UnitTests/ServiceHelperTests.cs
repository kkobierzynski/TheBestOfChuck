using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestOfChuck.Exceptions;
using TheBestOfChuck.Services;

namespace TheBestOfChuck.UnitTests
{
    public class ServiceHelperTests
    {
        private readonly ServiceHelper _serviceHelper;

        public ServiceHelperTests() 
        {
            _serviceHelper= new ServiceHelper();
        }

        [Theory]
        [InlineData("test", 0)]
        [InlineData("test", -2)]
        [InlineData(null, 2)]
        public void isExceedingLength_InvalidInputData_ThrowsException(string joke, int length)
        {
            //Arrange

            //Act
            var result = () => _serviceHelper.isExceedingLength(joke, length);

            //Assert
            result.Should().Throw<InvalidInputDataException>();
        }

        [Theory]
        [InlineData("test", 3)]
        [InlineData("  ", 1)]
        [InlineData("Test test", 8)]
        public void isExceedingLength_JokeLengthGreaterThanLength_ReturnsFalse(string joke, int length)
        {
            //Arrange

            //Act
            var result = _serviceHelper.isExceedingLength(joke, length);

            //Assert
            result.Should().Be(false);
        }

        [Theory]
        [InlineData("test", 4)]
        [InlineData("  ", 2)]
        [InlineData("Test Test", 100)]
        public void isExceedingLength_JokeLengthSmallerThanLength_ReturnsTrue(string joke, int length)
        {
            //Arrange

            //Act
            var result = _serviceHelper.isExceedingLength(joke, length);

            //Assert
            result.Should().Be(true);
        }

    }
}
