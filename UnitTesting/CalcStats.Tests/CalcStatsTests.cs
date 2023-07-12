namespace CalcStats.Tests
{
    //  #### Calc Stats:

	//  Your task is to process a sequence of integer numbers
	//  to determine the following statistics:

	//	o) minimum value
	//	o) maximum value
	//	o) number of elements in the sequence
	//	o) average value

	//  For example: [6, 9, 15, -2, 92, 11]

	//	o) minimum value = -2
	//	o) maximum value = 92
	//	o) number of elements in the sequence = 6
	//	o) average value = 18.166666

    [TestFixture]
    public class CalcStatsTests
    {
        private CalcStats calcStats;

        [SetUp]
        public void Setup()
        {
            calcStats = new CalcStats();
        }

        [Test]
        public void MinValue_ReturnsMinimumValue()
        {
            // Arrange
            int[] numbers = { 6, 9, 15, -2, 92, 11 };

            // Act
            int result = calcStats.MinValue(numbers);

            // Assert
            Assert.AreEqual(-2, result);
        }

        [Test]
        public void MinValue_NullOrEmptyArray_ThrowsArgumentException()
        {
            // Arrange
            int[] numbers = null;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => calcStats.MinValue(numbers));
        }

        [Test]
        public void MaxValue_ReturnsMaximumValue()
        {
            // Arrange
            int[] numbers = { 6, 9, 15, -2, 92, 11 };

            // Act
            int result = calcStats.MaxValue(numbers);

            // Assert
            Assert.AreEqual(92, result);
        }

        [Test]
        public void MaxValue_NullOrEmptyArray_ThrowsArgumentException()
        {
            // Arrange
            int[] numbers = null;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => calcStats.MaxValue(numbers));
        }

        [Test]
        public void NumberOfElements_ReturnsNumberOfElements()
        {
            // Arrange
            int[] numbers = { 6, 9, 15, -2, 92, 11 };

            // Act
            int result = calcStats.NumberOfElements(numbers);

            // Assert
            Assert.AreEqual(6, result);
        }

        [Test]
        public void NumberOfElements_NullArray_ThrowsArgumentException()
        {
            // Arrange
            int[] numbers = null;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => calcStats.NumberOfElements(numbers));
        }

        [Test]
        public void AverageValue_ReturnsAverageValue()
        {
            // Arrange
            int[] numbers = { 6, 9, 15, -2, 92, 11 };

            // Act
            double result = calcStats.AverageValue(numbers);

            // Assert
            Assert.AreEqual(18.166666, result, 0.000001);
        }

        [Test]
        public void AverageValue_NullOrEmptyArray_ThrowsArgumentException()
        {
            // Arrange
            int[] numbers = null;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => calcStats.AverageValue(numbers));
        }
    }

}