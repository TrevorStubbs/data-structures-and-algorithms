using System;
using Xunit;
using LinkedListLibrary;

namespace LinkedListTests
{
    public class LinkedListTests
    {
        [Fact]
        public void CanInstantiateEmptyLinkedList()
        {
            LinkedList list = new LinkedList();
            Assert.Null(list.Head);
        }

        [Fact]
        public void CanInsertIntoLinkedList()
        {
            LinkedList list = new LinkedList();
            list.Insert(4);

            Assert.Equal(4, list.Head.Value);
        }

        [Fact]
        public void CanInsertMultipleNodesInLinkedList()
        {
            LinkedList list = new LinkedList();
            list.Insert(4);
            list.Insert(8);
            list.Insert(12);
            list.Insert(16);
            list.Insert(23);
            list.Insert(42);

            Assert.Equal(42, list.Head.Value);
        }

        [Fact]
        public void CanFindValueInList()
        {
            LinkedList list = new LinkedList();
            list.Insert(4);
            list.Insert(8);
            list.Insert(12);
            list.Insert(15);
            list.Insert(23);
            list.Insert(42);

            int searchForvalue = 15;
            bool exists = list.Includes(searchForvalue);

            Assert.True(exists);
        }

        [Fact]
        public void CannotFindValueInList()
        {
            LinkedList list = new LinkedList();
            list.Insert(4);
            list.Insert(8);
            list.Insert(12);
            list.Insert(15);
            list.Insert(23);
            list.Insert(42);

            int searchForvalue = 16;
            bool exists = list.Includes(searchForvalue);

            Assert.False(exists);
        }

        [Fact]
        public void CanReturnValuesInLinkedLists()
        {
            LinkedList list = new LinkedList();
            list.Insert(4);
            list.Insert(8);
            list.Insert(12);
            list.Insert(15);
            list.Insert(23);
            list.Insert(42);

            string outputFromMethod = list.ToString();

            string expected = "42 -> 23 -> 15 -> 12 -> 8 -> 4 -> Null";
            Assert.Equal(expected, outputFromMethod);
        }
    }
}
