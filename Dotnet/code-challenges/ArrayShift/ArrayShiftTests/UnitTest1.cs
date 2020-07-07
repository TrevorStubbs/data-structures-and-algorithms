using System;
using Xunit;
using static ArrayShift.Program;

namespace ArrayShiftTests
{
    public class UnitTest1
    {
        /// <summary>
        /// Tests to see if the first example provided is correct
        /// </summary>
        [Fact]
        public void ReturnsExpectedArrayFromInsertShiftArray1()
        {
            // arrange
            int[] testArray = new int[] { 2, 4, 6, 8 };
            int testValue = 5;
            int[] expectedArray = new int[] { 2, 4, 5, 6, 8 };

            // Act
            int[] newArray = InsertShiftArray(testArray, testValue);

            // assert
            Assert.Equal(expectedArray, newArray);
        }

        /// <summary>
        /// Tests to see if the second example provided is correct
        /// </summary>
        [Fact]
        public void ReturnsExpectedArrayFromInsertShiftArray2()
        {
            // arrange
            int[] testArray = new int[] { 4, 8, 15, 23, 42 };
            int testValue = 16;
            int[] expectedArray = new int[] { 4, 8, 15, 16, 23, 42 };

            // Act
            int[] newArray = InsertShiftArray(testArray, testValue);

            // assert
            Assert.Equal(expectedArray, newArray);
        }

        [Fact]
        public void DoesNotReturnABadArrayFromInsertShiftArray1()
        {
            // arrange
            int[] testArray = new int[] { 4, 8, 15, 23, 42 };
            int testValue = 16;
            int[] expectedArray = new int[] { 4, 8, 15, 23, 16, 42 };

            // Act
            int[] newArray = InsertShiftArray(testArray, testValue);

            // assert
            Assert.NotEqual(expectedArray, newArray);
        }

        [Fact]
        public void DoesNotReturnABadArrayFromInsertShiftArray2()
        {
            // arrange
            int[] testArray = new int[] { 4, 8, 15, 23, 42, 156, 112 };
            int testValue = 16;
            int[] expectedArray = new int[] { 4, 8, 15, 23, 16, 42 };

            // Act
            int[] newArray = InsertShiftArray(testArray, testValue);

            // assert
            Assert.NotEqual(expectedArray, newArray);
        }
    }
}
