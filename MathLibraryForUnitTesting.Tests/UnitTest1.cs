using Moq;
using Xunit;

namespace MathLibraryForUnitTesting.Tests
{
    public class CalculatorServiceTests
    {
        private readonly Mock<ILogger> _mockLogger;
        private readonly CalculatorService _calculatorService;

        public CalculatorServiceTests()
        {
            _mockLogger = new Mock<ILogger>();
            _calculatorService = new CalculatorService(_mockLogger.Object);
        }

        [Theory]
        [InlineData(2, 3, 5)]
        [InlineData(-1, -1, -2)]
        [InlineData(0, 0, 0)]
        public void Add_ShouldReturnCorrectSum(int a, int b, int expected)
        {
            // Act
            int result = _calculatorService.Add(a, b);

            // Assert
            Assert.Equal(expected, result);
            _mockLogger.Verify(logger => logger.Log(It.Is<string>(s => s.Contains($"{a} + {b} = {result}"))), Times.Once);
        }

        [Theory]
        [InlineData(5, 3, 2)]
        [InlineData(3, 5, -2)]
        [InlineData(0, 0, 0)]
        public void Subtract_ShouldReturnCorrectDifference(int a, int b, int expected)
        {
            // Act
            int result = _calculatorService.Subtract(a, b);

            // Assert
            Assert.Equal(expected, result);
            _mockLogger.Verify(logger => logger.Log(It.Is<string>(s => s.Contains($"{a} - {b} = {result}"))), Times.Once);
        }
    }
}
