using System;
using Xunit;
using StacksAndQueuesLibrary;

namespace StacksAndQueuesTests
{
    public class StackTests
    {
        /// <summary>
        /// Test 1
        /// </summary>
        [Fact]
        public void CanPushOnStack()
        {
            // Arrange
            Stack stack = new Stack();
            // Act
            stack.Push("candy cane");
            // Assert
            Assert.Equal("candy cane", stack.Top.Value);
            Assert.NotNull(stack.Top.Value);
        }

        /// <summary>
        /// Test 2
        /// </summary>
        [Fact]
        public void CanPushMultipuleNodesOnTheStack()
        {
            // Arrange
            Stack stack = new Stack();
            string expected = "chocolate candy cane";
            // Act
            stack.Push("candy cane");
            stack.Push("chocolate");
            // Assert
            string returnFromMethod = $"{stack.Top.Value} {stack.Top.Next.Value}";

            Assert.Equal(expected, returnFromMethod);
            Assert.NotNull(stack.Top.Value);
        }

        /// <summary>
        /// Test 5
        /// </summary>
        [Fact]
        public void PeekWillReturnTrueIfStackIsNotEmpty()
        {
            // Arrange
            Stack stack = new Stack();
            // Act
            stack.Push("candy cane");
            stack.Push("chocolate");
            bool returnFromMethod = stack.Peek();
            // Assert
            Assert.True(returnFromMethod);
        }

        /// <summary>
        /// Test 6
        /// </summary>
        [Fact]
        public void CanInstantiateAnEmptyStack()
        {
            Stack stack = new Stack();
            Assert.Null(stack.Top);
        }

        /// <summary>
        /// Test 7. Part 1
        /// </summary>
        [Fact]
        public void PeekWillThrowAnExceptionIfStackIsEmpty()
        {
            // Arrange
            Stack stack = new Stack();
            // Act
            Exception e = Assert.Throws<System.Exception>(() => stack.Peek());
            string errorMessage = "The stack is empty.";
            // Assert
            Assert.Equal(errorMessage, e.Message);
        }
    }
}
