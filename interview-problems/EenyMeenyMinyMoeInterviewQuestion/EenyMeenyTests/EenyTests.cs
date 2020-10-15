using System;
using System.Collections.Generic;
using Xunit;
using static EenyMeenyMinyMoeInterviewQuestion.Program;

namespace EenyMeenyTests
{
    public class EenyTests
    {
        [Fact]
        public void CanReturnExpectedAnswer()
        {
            // Arrange
            List<string> inputStrings = new List<string>() { "A", "B", "C", "D", "E" };
            string expected = "D";

            // Act
            string returnFromMethod = Meany(inputStrings, 3);

            // Assert
            Assert.Equal(expected, returnFromMethod);
        }

    }
}
