using System;
using System.Collections.Generic;
using System.Text;

namespace Add2ReversedLinkedLists
{
    public class ListNode
    {
        public int Val { get; set; }
        public ListNode Next;
        public ListNode(int val=0, ListNode next=null)
        {
            Val = val;
            Next = next;
        }
    }
}
