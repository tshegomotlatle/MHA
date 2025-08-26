using MHA.Implementations;

namespace MHA.Tests.Implementations
{
    public class MullItOverTests
    {
        [Fact]
        public void Calculate_WithSingleValidMul_ReturnsCorrectProduct()
        {
            // Arrange
            var input = "mul(3,4)";
            var sut = new MullItOver(input);

            // Act
            var result = sut.Calculate();

            // Assert
            Assert.Equal(12, result);
        }

        [Fact]
        public void Calculate_WithMultipleValidMuls_ReturnsSumOfProducts()
        {
            // Arrange
            var input = "mul(2,4)mul(5,5)mul(11,8)mul(8,5)";
            var sut = new MullItOver(input);

            // Act
            var result = sut.Calculate();

            // Assert
            Assert.Equal(161, result); // (2*4 + 5*5 + 11*8 + 8*5)
        }

        [Fact]
        public void Calculate_WithCorruptedMemory_IgnoresInvalidInstructions()
        {
            // Arrange
            var input = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";
            var sut = new MullItOver(input);

            // Act
            var result = sut.Calculate();

            // Assert
            Assert.Equal(161, result); // only valid mul() are processed
        }

        [Fact]
        public void Calculate_WithNoValidMul_ReturnsZero()
        {
            // Arrange
            var input = "random text with mul(2,,3) and mul (4,5)";
            var sut = new MullItOver(input);

            // Act
            var result = sut.Calculate();

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Calculate_WithMaximumThreeDigitNumbers_WorksCorrectly()
        {
            // Arrange
            var input = "mul(999,123)";
            var sut = new MullItOver(input);

            // Act
            var result = sut.Calculate();

            // Assert
            Assert.Equal(999 * 123, result);
        }

        [Fact]
        public void Calculate_WithLeadingZeros_ParsesCorrectly()
        {
            // Arrange
            var input = "mul(007,05)";
            var sut = new MullItOver(input);

            // Act
            var result = sut.Calculate();

            // Assert
            Assert.Equal(7 * 5, result);
        }

        [Fact]
        public void Calculate_WithLargeInput_PerformsCorrectly()
        {
            // Arrange
            var input = string.Concat(Enumerable.Repeat("mul(3,3)", 1000));
            var sut = new MullItOver(input);

            // Act
            var result = sut.Calculate();

            // Assert
            Assert.Equal(1000 * 9, result);
        }
    }
}
