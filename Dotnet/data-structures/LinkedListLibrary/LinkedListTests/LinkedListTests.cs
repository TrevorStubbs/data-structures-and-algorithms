using System;
using Xunit;
using LinkedListLibrary;

namespace LinkedListTests
{
    public class LinkedListCreatingInsertingFindingAValueTests
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

    public class LinkedListAppendAddBeforeAddAfterTests
    {
        [Fact]
        public void CanAddANodeToTheEndOfALinkedList()
        {
            LinkedList list = new LinkedList();
            list.Insert(2);
            list.Insert(3);
            list.Insert(1);
            list.Append(5);
            string outputFromMethod = list.ToString();
            string expected = "1 -> 3 -> 2 -> 5 -> Null";
            Assert.Equal(expected, outputFromMethod);
        }
        [Fact]
        public void CanAppendIfListIsEmpty()
        {
            LinkedList list = new LinkedList();
            list.Append(1);
            string outputFromMethod = list.ToString();
            string expected = "1 -> Null";
            Assert.Equal(expected, outputFromMethod);
        }

        [Fact]
        public void CanAppendMutlipuleNodesToTheEndOfALinkedList()
        {
            LinkedList list = new LinkedList();
            list.Append(1);
            list.Append(2);
            string outputFromMethod = list.ToString();
            string expected = "1 -> 2 -> Null";
            Assert.Equal(expected, outputFromMethod);
        }

        [Fact]
        public void CanInsertANodeLocatedInTheMiddleOfALinkedList()
        {
            LinkedList list = new LinkedList();
            list.Insert(2);
            list.Insert(3);
            list.Insert(1);
            list.InsertBefore(3, 5);
            string outputFromMethod = list.ToString();
            string expected = "1 -> 5 -> 3 -> 2 -> Null";
            Assert.Equal(expected, outputFromMethod);
        }
        [Fact]
        public void CanInsertANodeBeforeTheFirstNodeInALinkedList()
        {
            LinkedList list = new LinkedList();
            list.Insert(2);
            list.Insert(3);
            list.Insert(1);
            list.InsertBefore(1, 5);
            string outputFromMethod = list.ToString();
            string expected = "5 -> 1 -> 3 -> 2 -> Null";
            Assert.Equal(expected, outputFromMethod);
        }
        [Fact]
        public void CanAddBefore3()
        {
            LinkedList list = new LinkedList();
            list.Insert(2);
            list.Insert(2);
            list.Insert(1);
            list.InsertBefore(2, 5);
            string outputFromMethod = list.ToString();
            string expected = "1 -> 5 -> 2 -> 2 -> Null";
            Assert.Equal(expected, outputFromMethod);
        }
        [Fact]
        public void WillThrowAnErrorIfTheValueDoesNotExsistInALinkedListUsingInsertBefore()
        {
            LinkedList list = new LinkedList();
            list.Insert(2);
            list.Insert(3);
            list.Insert(1);
            Exception e = Assert.Throws<System.Exception>(() => list.InsertBefore(4, 5));
            string errorMessage = "That value does not exist.";

            Assert.Equal(errorMessage, e.Message);
        }

        [Fact]
        public void CanInsertANodeInTheMiddleOfTheLinkedList()
        {
            LinkedList list = new LinkedList();

            list.Insert(2);
            list.Insert(3);
            list.Insert(1);

            list.InsertAfter(3, 5);

            string outputFromMethod = list.ToString();

            string expected = "1 -> 3 -> 5 -> 2 -> Null";
            Assert.Equal(expected, outputFromMethod);
        }

        [Fact]
        public void CanInsertANodeInTheMiddleOfTheLinkedListV2()
        {
            LinkedList list = new LinkedList();

            list.Insert(2);
            list.Insert(2);
            list.Insert(1);

            list.InsertAfter(2, 5);

            string outputFromMethod = list.ToString();

            string expected = "1 -> 2 -> 5 -> 2 -> Null";
            Assert.Equal(expected, outputFromMethod);
        }

        [Fact]
        public void CanInsertANodeAfterTheLastNodeOfTheLinkedList()
        {
            LinkedList list = new LinkedList();

            list.Insert(2);
            list.Insert(3);
            list.Insert(1);

            list.InsertAfter(2, 5);

            string outputFromMethod = list.ToString();

            string expected = "1 -> 3 -> 2 -> 5 -> Null";
            Assert.Equal(expected, outputFromMethod);
        }

        [Fact]
        public void WillThrowAnErrorIfTheValueDoesNotExsistInALinkedListUsingInsertAfter()
        {
            LinkedList list = new LinkedList();

            list.Insert(2);
            list.Insert(3);
            list.Insert(1);

            Exception e = Assert.Throws<System.Exception>(() => list.InsertAfter(4, 5));
            string errorMessage = "That value does not exist.";

            Assert.Equal(errorMessage, e.Message);
        }
    }
    public class LinkedListTestsFindTheKthNodeTests
    { 
        [Fact]
        public void ReturnsExceptionWhenKIsLargerThanTheList()
        {
            LinkedList list = new LinkedList();

            list.Insert(2);
            list.Insert(8);
            list.Insert(3);
            list.Insert(1);

            Exception e = Assert.Throws<System.Exception>(() => list.KthFromTheEnd(6));
            string errorMessage = "There are not that many nodes in this list.";

            Assert.Equal(errorMessage, e.Message);
        }

        [Fact]
        public void CanReturnValueAtTheEndOfTheList()
        {
            LinkedList list = new LinkedList();

            list.Insert(2);
            list.Insert(8);
            list.Insert(3);
            list.Insert(1);

            int outputFromMethod = list.KthFromTheEnd(0);

            int expected = 2;

            Assert.Equal(expected, outputFromMethod);
        }

        [Fact]
        public void ReturnsExceptionWhenKIsANegativeNumber()
        {
            LinkedList list = new LinkedList();

            list.Insert(2);
            list.Insert(8);
            list.Insert(3);
            list.Insert(1);

            Exception e = Assert.Throws<System.Exception>(() => list.KthFromTheEnd(-6));
            string errorMessage = "You cannot enter a negative number.";

            Assert.Equal(errorMessage, e.Message);
        }

        [Fact]
        public void CanFindKthValueWhenListIsOne()
        {
            LinkedList list = new LinkedList();

            list.Insert(2);

            int outputFromMethod = list.KthFromTheEnd(0);

            int expected = 2;

            Assert.Equal(expected, outputFromMethod);
        }

        [Fact]
        public void CanFindKthValueHappyPath()
        {
            LinkedList list = new LinkedList();

            list.Insert(2);
            list.Insert(8);
            list.Insert(3);
            list.Insert(1);

            int outputFromMethod = list.KthFromTheEnd(2);

            int expected = 3;

            Assert.Equal(expected, outputFromMethod);
        }
    }
    public class LinkedListTestsMakeCyclic
    {
        [Fact]
        public void CanMakeLinkedListCyclic()
        {
            LinkedList cyclicList = new LinkedList();
            cyclicList.Insert(6);
            cyclicList.Insert(5);
            cyclicList.Insert(4);
            cyclicList.Insert(3);
            cyclicList.Insert(2);
            cyclicList.Insert(1);
            cyclicList.MakeCyclic(6);

            var isCyclic = IsCyclic(cyclicList);
            var cycleLength = FindCyclicLLLength(cyclicList.Head);
            var cycleStart = FindCycleStart(cyclicList.Head);

            Assert.True(isCyclic);
            Assert.Equal(1, cycleLength);
            Assert.Equal(6, cycleStart.Value);
        }

        private static bool IsCyclic(LinkedList inputLL)
        {
            // Set the 2 pointers to the head.
            var slow = inputLL.Head;
            var fast = inputLL.Head;

            // Since Fast will be running before slow we only need check to see if fast is null (or fast.Next)
            while (fast != null && fast.Next != null)
            {
                // Travers the LL
                // Slow will be slow.Next
                // Fast will always be fast.Next.Next
                slow = slow.Next;
                fast = fast.Next.Next;

                // If fast and slow are pointing to the same node then the LL is cyclical.
                if (slow == fast)
                    return true;
            }

            return false;
        }

        private static int FindCyclicLLLength(Node head)
        {
            int result = 1;
            Node fast = head;
            Node slow = head;
            Node cycleStart = null;

            while (fast != null && fast.Next != null)
            {
                fast = fast.Next.Next;
                slow = slow.Next;

                if (fast == slow)
                {
                    cycleStart = slow;
                    break;
                }
            }

            slow = slow.Next;

            while (cycleStart != slow)
            {
                result++;
                slow = slow.Next;
            }

            return result;
        }

        private static Node FindCycleStart(Node head)
        {
            int cycleLength = 0;
            Node slow = head;
            Node fast = head;
            while (fast != null && fast.Next != null)
            {
                fast = fast.Next.Next;
                slow = slow.Next;

                if (slow == fast)
                {
                    cycleLength = CalcCycleLength(slow);
                    break;
                }
            }

            return FindStart(head, cycleLength);
        }

        private static int CalcCycleLength(Node slow)
        {
            Node current = slow;
            int cycleLength = 0;
            do
            {
                current = current.Next;
                cycleLength++;
            }
            while (current != slow);

            return cycleLength;
        }

        private static Node FindStart(Node head, int cycleLength)
        {
            Node pointer1 = head, pointer2 = head;
            while (cycleLength > 0)
            {
                pointer2 = pointer2.Next;
                cycleLength--;
            }

            while (pointer1 != pointer2)
            {
                pointer1 = pointer1.Next;
                pointer2 = pointer2.Next;
            }

            return pointer1;
        }
    }
}
