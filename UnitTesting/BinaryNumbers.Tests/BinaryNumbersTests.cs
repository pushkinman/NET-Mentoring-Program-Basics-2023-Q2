namespace BinaryNumbers.Tests
{
    [TestFixture]
    public class BinaryNumbersTests
    {
        private BinaryNumbers binaryNumbers;

        [SetUp]
        public void Setup()
        {
            binaryNumbers = new BinaryNumbers();
        }

        [Test]
        public void CountValidSequences_Length4_ReturnsExpectedResult()
        {
            // Arrange
            int length = 4;
            int expectedResult = 8;

            // Act
            int result = binaryNumbers.CountValidSequences(length);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void CountValidSequences_Length5_ReturnsExpectedResult()
        {
            // Arrange
            int length = 5;
            int expectedResult = 13;

            // Act
            int result = binaryNumbers.CountValidSequences(length);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void CountValidSequences_Length10_ReturnsExpectedResult()
        {
            // Arrange
            int length = 10;
            int expectedResult = 144;

            // Act
            int result = binaryNumbers.CountValidSequences(length);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void CountValidSequences_Length6_ReturnsExpectedResult()
        {
            // Arrange
            int length = 6; // Change the length as needed
            int expectedResult = 21; // Change the expected result as needed

            // Act
            int result = binaryNumbers.CountValidSequences(length);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void CountValidSequences_LengthZero_ThrowsArgumentException()
        {
            // Arrange
            int length = 0;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => binaryNumbers.CountValidSequences(length));
        }

        [Test]
        public void CountValidSequences_NegativeLength_ThrowsArgumentException()
        {
            // Arrange
            int length = -5;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => binaryNumbers.CountValidSequences(length));
        }
    }
}