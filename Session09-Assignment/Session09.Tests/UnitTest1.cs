using Xunit;

namespace Session09.Tests
{
    public class FineCalculatorTests
    {
        private readonly global::FineCalculator _calculator;

        public FineCalculatorTests()
        {
            _calculator = new global::FineCalculator();
        }

        // Test 1: Addition
        [Fact]
        public void Add_ShouldReturnCorrectSum()
        {
            // Arrange
            int a = 10;
            int b = 5;

            // Act
            int result = _calculator.Add(a, b);

            // Assert
            Assert.Equal(15, result);
        }

        // Test 2: Addition should not return an incorrect result
        [Fact]
        public void Add_ShouldReturnNotEqual()
        {
            int result = _calculator.Add(10, 5);

            Assert.NotEqual(20, result);
        }

        // Test 3: Subtraction
        [Fact]
        public void Subtract_ShouldReturnCorrectDifference()
        {
            int result = _calculator.Subtract(10, 5);

            Assert.Equal(5, result);
        }

        // Test 4: Multiplication
        [Fact]
        public void Multiply_ShouldReturnCorrectResult()
        {
            int result = _calculator.Multiply(4, 5);

            Assert.Equal(20, result);
        }

        // Test 5: Multiplication should not return an incorrect result
        [Fact]
        public void Multiply_ShouldReturnNotEqual()
        {
            int result = _calculator.Multiply(4, 5);

            Assert.NotEqual(15, result);
        }

        // Test 6: Division by zero
        [Fact]
        public void Divide_ByZero_ShouldThrowException()
        {
            Assert.Throws<DivideByZeroException>(
                () => _calculator.Divide(10, 0)
            );
        }
    }
}