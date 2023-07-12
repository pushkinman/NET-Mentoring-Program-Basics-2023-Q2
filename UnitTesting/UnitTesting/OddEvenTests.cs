using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework.Internal.Execution;
using System.ComponentModel;
using System.Security.Cryptography;

namespace UnitTesting
{
    //    ### The OddEven Kata
    //  	- Write a program that prints numbers within specified range lets say 1 to 100. If number is odd print 'Odd'
    //  	  instead of the number.If number is even print 'Even' instead of number.Else print number[hint - if number is Prime].

    //    #### Steps :

    //    Lets divide into following steps:
    //  	- Prints numbers from 1 to 100
    //  	- Print "Even" instead of number, if the number is even, means divisible by 2
    //	    - Print "Odd" instead of number, if the number is odd, means not divisible by 2 but not divisible by itself too [hint - it should not be Prime]
    //	    - Print number, if it does not meet above two conditions, means if number is Prime
    //	    - Make method to accept any number of range [currently  we have 1 to 100]
    //	    - Create a new method to check Odd/Even/Prime of a single supplied method

    public class OddEvenTests
    {
        [TestCase(1, "Odd")]
        [TestCase(2, "Even")]
        [TestCase(3, "Prime")]
        [TestCase(4, "Even")]
        [TestCase(5, "Prime")]
        [TestCase(6, "Even")]
        [TestCase(7, "Prime")]
        [TestCase(8, "Even")]
        [TestCase(9, "Odd")]
        [TestCase(10, "Even")]
        [TestCase(11, "Prime")]
        public void PrintNumber_PrintsCorrectResult(int number, string expectedResult)
        {
            // Arrange
            OddEven oddEven = new OddEven();

            // Act
            string result = oddEven.PrintNumber(number);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}