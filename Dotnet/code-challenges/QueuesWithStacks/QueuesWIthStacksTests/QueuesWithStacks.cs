using System;
using Xunit;
using QueuesWithStacks.Classes;

namespace QueuesWithStacksTests
{
    public class EnqueueWithStacksTests
    {
        [Fact]
        public void CanEnqueueWithMethod()
        {
            // arrange
            PseudoQueue<int> que = new PseudoQueue<int>();

            // act
            que.Enqueue(5);
            que.Enqueue(10);
            que.Enqueue(15);
            int expected = 15;
            // assert
            Assert.Equal(expected, que.Storage.Peek());
        }

        [Fact]
        public void CanEnqueueWhenPseudoQueueIsEmpty()
        {
            // arrange
            PseudoQueue<int> que = new PseudoQueue<int>();

            // act
            que.Enqueue(5);
            int expected = 5;
            // assert
            Assert.Equal(expected, que.Storage.Peek());
        }

        [Fact]
        public void ThowsErrorPseudoWueueIsEmpty()
        {
            PseudoQueue<int> que = new PseudoQueue<int>();

            Exception e = Assert.Throws<System.Exception>(() => que.Storage.Peek());
            string expected = "The stack is empty.";

            Assert.Equal(expected, e.Message);
        }
    }

    public class DequeueWithStacksTests
    {
        [Fact]
        public void CanDequeueFromAPseudoQueue()
        {
            PseudoQueue<int> que = new PseudoQueue<int>();

            // act
            que.Enqueue(5);
            que.Enqueue(10);
            que.Enqueue(15);
            que.Enqueue(20);
            
            int expected = 5;
            int returnFromMethod = que.Dequeue();
            // assert
            Assert.Equal(expected, returnFromMethod);
        }

        [Fact]
        public void CanDequeueFromAPseudoQueueTwice()
        {
            PseudoQueue<int> que = new PseudoQueue<int>();

            // act
            que.Enqueue(5);
            que.Enqueue(10);
            que.Enqueue(15);
            que.Enqueue(20);

            int expected = 10;
            que.Dequeue();
            int returnFromMethod = que.Dequeue();
            // assert
            Assert.Equal(expected, returnFromMethod);
        }
    }
}
