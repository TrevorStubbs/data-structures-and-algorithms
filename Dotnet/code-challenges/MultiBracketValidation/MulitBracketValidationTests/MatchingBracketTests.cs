using System;
using Xunit;
using StacksAndQueuesLibrary;
using static MultiBracketValidation.Program;

namespace MulitBracketValidationTests
{
    public class MatchingBracketTests
    {
        [Fact]
        public void CanMatchBrackets()
        {
            // Arrange
            string input = "{}";
            // Act
            Assert.True(MultiBracketValidationMethod(input));
            // Assert
        }
        [Theory]
        [InlineData("{}(){}")]
        [InlineData("()[[Extra Characters]]")]
        [InlineData("(){}[[]]")]
        [InlineData("{}{Code}[Fellows](())")]

        public void CanMatchManyBrackets(string input)
        {
            Assert.True(MultiBracketValidationMethod(input));
        }
        [Theory]
        [InlineData("[({}]")]
        [InlineData("(](")]
        [InlineData("{(})")]
        public void FalseWhenBracketsDontMatch(string input)
        {
            Assert.False(MultiBracketValidationMethod(input));
        }
    }
}
