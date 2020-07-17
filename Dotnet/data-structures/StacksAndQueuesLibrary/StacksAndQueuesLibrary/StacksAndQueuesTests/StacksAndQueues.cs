using System;
using Xunit;
using StacksAndQueuesLibrary;

namespace StacksAndQueuesTests
{
    public class StackDay1Tests
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
        /// Test 3
        /// </summary>
        [Fact]
        public void CanPopNodeOffTheStack()
        {
            // Arrange
            Stack stack = new Stack();
            string expected = "chocolate";
            // Act
            stack.Push("candy cane");
            stack.Push("chocolate");
            Node returnFromMethod = stack.Pop();
            // Assert
            Assert.Equal(expected, returnFromMethod.Value);
        }

        /// <summary>
        /// Test 4
        /// </summary>
        [Fact]
        public void CanEmptyStackByPoppingMultipuleTimes()
        {
            // Arrange
            Stack stack = new Stack();
            // Act
            stack.Push("candy cane");
            stack.Push("chocolate");
            stack.Pop();
            stack.Pop();
            // Assert
            Assert.Null(stack.Top);
        }

        /// <summary>
        /// Test 5
        /// </summary>
        [Fact]
        public void PeekWillReturnTheValueOfTopIfStackIsNotEmpty()
        {
            // Arrange
            Stack stack = new Stack();
            // Act
            stack.Push("candy cane");
            stack.Push("chocolate");
            string returnFromMethod = stack.Peek();
            // Assert
            Assert.Equal("chocolate", returnFromMethod);
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

        /// <summary>
        /// Test 7. Part 2
        /// </summary>
        [Fact]
        public void PopAnEmptyStackWillTrowAnError()
        {
            Stack stack = new Stack();
            // Act
            Exception e = Assert.Throws<System.Exception>(() => stack.Pop());
            string errorMessage = "The stack is empty.";
            // Assert
            Assert.Equal(errorMessage, e.Message);
        }
    }
}
