using System;
using Xunit;
using static ArrayShift.Program;

namespace ArrayShiftTests
{
    public class UnitTest1
    {
        [Fact]
        public void CanReturnArrayFromInsertShiftArray()
        {
            // arrange
            int[] testArray = new int[] { 1, 2, 3, 4, 5 };
            int testValue = 6;

            // Act
            int[] newArray = InsertShiftArray(testArray, testValue);

            // assert
            Assert.Equal(6, newArray[5]);
        }
    }
}
