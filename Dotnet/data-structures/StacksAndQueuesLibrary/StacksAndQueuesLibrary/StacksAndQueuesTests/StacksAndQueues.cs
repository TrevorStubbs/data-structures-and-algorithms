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
            Stack<string> stack = new Stack<string>();
            // Act
            stack.Push("candy cane");
            // Assert
            Assert.Equal("candy cane", stack.Peek());
            Assert.NotNull(stack.Peek());
        }

        /// <summary>
        /// Test 2
        /// </summary>
        [Fact]
        public void CanPushMultipuleNodesOnTheStack()
        {
            // Arrange
            Stack<string> stack = new Stack<string>();
            string expected = "chocolate";
            // Act
            stack.Push("candy cane");
            stack.Push("chocolate");
            // Assert
            string returnFromMethod = $"{stack.Peek()}";

            Assert.Equal(expected, returnFromMethod);
            Assert.NotNull(stack.Peek());
        }

        /// <summary>
        /// Test 3
        /// </summary>
        [Fact]
        public void CanPopNodeOffTheStack()
        {
            // Arrange
            Stack<string> stack = new Stack<string>();
            string expected = "chocolate";
            // Act
            stack.Push("candy cane");
            stack.Push("chocolate");
            Node<string> returnFromMethod = stack.Pop();
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
            Stack<string> stack = new Stack<string>();
            // Act
            stack.Push("candy cane");
            stack.Push("chocolate");
            stack.Pop();
            stack.Pop();
            Exception e = Assert.Throws<System.Exception>(() => stack.Peek());
            string errorMessage = "The stack is empty.";
            // Assert
            Assert.Equal(errorMessage, e.Message);
        }

        /// <summary>
        /// Test 5
        /// </summary>
        [Fact]
        public void PeekWillReturnTheValueOfTopIfStackIsNotEmpty()
        {
            // Arrange
            Stack<string> stack = new Stack<string>();
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
            Stack<string> stack = new Stack<string>();
            Exception e = Assert.Throws<System.Exception>(() => stack.Peek());
            string errorMessage = "The stack is empty.";          
            Assert.Equal(errorMessage, e.Message);
        }

        /// <summary>
        /// Test 7. Part 1
        /// </summary>
        [Fact]
        public void PeekWillThrowAnExceptionIfStackIsEmpty()
        {
            // Arrange
            Stack<string> stack = new Stack<string>();
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
            Stack<string> stack = new Stack<string>();
            // Act
            Exception e = Assert.Throws<System.Exception>(() => stack.Pop());
            string errorMessage = "The stack is empty.";
            // Assert
            Assert.Equal(errorMessage, e.Message);
        }
    }

    public class QueueDay1Tests
    {
        /// <summary>
        /// Test 8
        /// </summary>
        [Fact]
        public void CanEnqueueIntoQueue()
        {
            // Arrange
            Queue<string> queue = new Queue<string>();
            // Act
            queue.Enqueue("Josie Cat");

            // Assert
            Assert.Equal("Josie Cat", queue.Peek());
        }

        /// <summary>
        /// Test 9
        /// </summary>
        [Fact]
        public void CanSuccessfullyEnqueueMultipleValuesIntoAQueue()
        {
            // Arrange
            Queue<string> queue = new Queue<string>();
            // Act
            queue.Enqueue("Josie Cat");
            queue.Enqueue("Belle Kitty");

            // Assert
            Assert.Equal("Josie Cat", queue.Peek());
        }

        /// <summary>
        /// Test 10
        /// </summary>
        [Fact]
        public void CanSuccessfullyDequeueOutOfAQueueTheExpectedValue()
        {
            //Arrange
            Queue<string> queue = new Queue<string>();
            string expected = "Josie Cat";
            // Act
            queue.Enqueue("Josie Cat");
            queue.Enqueue("Belle Kitty");
            queue.Enqueue("Razzle");
            Node<string> returnFromMethod = queue.Dequeue();

            // Assert
            Assert.Equal(expected, returnFromMethod.Value);
        }

        /// <summary>
        /// Test 11
        /// </summary>
        [Fact]
        public void CanSuccessfullyPeekIntoAQueueSeeingTheExpectedValue()
        {
            //Arrange
            Queue<string> queue = new Queue<string>();
            string expected = "Josie Cat";
            // Act
            queue.Enqueue("Josie Cat");
            queue.Enqueue("Belle Kitty");
            queue.Enqueue("Razzle");
            string returnFromMethod = queue.Peek();

            // Assert
            Assert.Equal(expected, returnFromMethod);
        }

        /// <summary>
        /// Test 12
        /// </summary>
        [Fact]
        public void CanSuccessfullyEmptyAQueueAfterMultipleDequeues()
        {
            Queue<string> queue = new Queue<string>();
            
            queue.Enqueue("Josie Cat");
            queue.Enqueue("Belle Kitty");
            queue.Enqueue("Razzle");
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();

            Exception e = Assert.Throws<System.Exception>(() => queue.Peek());
            string errorMessage = "The queue is empty.";
           
            Assert.Equal(errorMessage, e.Message);
        }

        /// <summary>
        /// Test 13
        /// </summary>
        [Fact]
        public void CanSuccessfullyInstantiateAnEmptyPueue()
        {
            Queue<string> queue = new Queue<string>();            

            Exception e = Assert.Throws<System.Exception>(() => queue.Peek());
            string errorMessage = "The queue is empty.";

            Assert.Equal(errorMessage, e.Message);
        }

        /// <summary>
        /// Test 14
        /// </summary>
        [Fact]
        public void CallingDequeueOnEmptyQueueRaisesException()
        {
            Queue<string> queue = new Queue<string>();

            Exception e = Assert.Throws<System.Exception>(() => queue.Dequeue());
            string errorMessage = "The queue is empty.";

            Assert.Equal(errorMessage, e.Message);
        }


    }
}
