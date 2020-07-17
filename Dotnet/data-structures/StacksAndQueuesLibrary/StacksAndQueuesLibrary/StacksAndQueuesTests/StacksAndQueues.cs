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
            Stack stack = new Stack();
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

    public class QueueDay1Tests
    {
        /// <summary>
        /// Test 8
        /// </summary>
        [Fact]
        public void CanEnqueueIntoQueue()
        {
            // Arrange
            Queue queue = new Queue();
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
            Queue queue = new Queue();
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
            Queue queue = new Queue();
            string expected = "Josie Cat";
            // Act
            queue.Enqueue("Josie Cat");
            queue.Enqueue("Belle Kitty");
            queue.Enqueue("Razzle");
            Node returnFromMethod = queue.Dequeue();

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
            Queue queue = new Queue();
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
            Queue queue = new Queue();
            
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
            Queue queue = new Queue();            

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
            Queue queue = new Queue();

            Exception e = Assert.Throws<System.Exception>(() => queue.Dequeue());
            string errorMessage = "The queue is empty.";

            Assert.Equal(errorMessage, e.Message);
        }


    }
}