using System;
using Xunit;
using QueuesWithStacks.Classes;
using System.Text;

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
            Assert.Equal(expected, que.Peek());
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
            Assert.Equal(expected, que.Peek());
        }

        [Fact]
        public void ThowsErrorPseudoQueueIsEmpty()
        {
            PseudoQueue<int> que = new PseudoQueue<int>();

            Exception e = Assert.Throws<System.Exception>(() => que.Peek());
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

        [Fact]
        public void WillEmptyPseudoQueueAndBuildAString()
        {
            PseudoQueue<int> que = new PseudoQueue<int>();
            StringBuilder sb = new StringBuilder();
            // act
            que.Enqueue(5);
            que.Enqueue(10);
            que.Enqueue(15);
            que.Enqueue(20);

            for (int i = 0; i < 3; i++)
            {
                sb.Append($"{que.Dequeue()} -> ");
            }

            sb.Append($"{que.Dequeue()}");

            string expected = "5 -> 10 -> 15 -> 20";

            Assert.Equal(expected, sb.ToString());
        }

        [Fact]
        public void WillThrowAnErrorIfPseudoQueueIsEmpty()
        {
            PseudoQueue<int> que = new PseudoQueue<int>();
            // act
            que.Enqueue(5);
            que.Enqueue(10);
            que.Enqueue(15);
            que.Enqueue(20);

            for (int i = 0; i < 4; i++)
            {
                que.Dequeue();
            }

            Exception e = Assert.Throws<System.Exception>(() => que.Dequeue());

            string expected = "The pseudo-queue is empty.";

            Assert.Equal(expected, e.Message);
        }
    }
}
