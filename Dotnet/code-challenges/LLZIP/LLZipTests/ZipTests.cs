using System;
using Xunit;
using static LLZIP.Program;
using LinkedListLibrary;

namespace LLZipTests
{
    public class ZipTests
    {
        [Fact]
        public void CanZipListsOfTheSameSize()
        {
            LinkedList list1 = new LinkedList();

            list1.Append(1);
            list1.Append(3);
            list1.Append(2);

            LinkedList list2 = new LinkedList();

            list2.Append(5);
            list2.Append(9);
            list2.Append(4);

            ZipLists(list1, list2);

            string outputFromMethod = list1.ToString();

            string expected = "1 -> 5 -> 3 -> 9 -> 2 -> 4 -> Null";

            Assert.Equal(expected, outputFromMethod);
        }

        [Fact]
        public void CanZipListsWithList2LargerThanList1()
        {
            LinkedList list1 = new LinkedList();

            list1.Append(1);
            list1.Append(3);

            LinkedList list2 = new LinkedList();

            list2.Append(5);
            list2.Append(9);
            list2.Append(4);

            ZipLists(list1, list2);

            string outputFromMethod = list1.ToString();

            string expected = "1 -> 5 -> 3 -> 9 -> 4 -> Null";

            Assert.Equal(expected, outputFromMethod);
        }

        [Fact]
        public void CanZipListsWithList1LargerThanList2()
        {
            LinkedList list1 = new LinkedList();

            list1.Append(1);
            list1.Append(3);
            list1.Append(2);

            LinkedList list2 = new LinkedList();

            list2.Append(5);
            list2.Append(9);

            ZipLists(list1, list2);

            string outputFromMethod = list1.ToString();

            string expected = "1 -> 5 -> 3 -> 9 -> 2 -> Null";

            Assert.Equal(expected, outputFromMethod);
        }

        [Fact]
        public void ThrowsAnErrorIfOneOfTheListsAreEmpty()
        {
            LinkedList list1 = new LinkedList();

            list1.Append(1);
            list1.Append(3);
            list1.Append(2);

            LinkedList list2 = new LinkedList();

            Exception e = Assert.Throws<System.Exception>(() => ZipLists(list1, list2));

            string errorMessage = "You cannot zip an empty list.";

            Assert.Equal(errorMessage, e.Message);

        }
    }
}
