using System;
using System.Collections.Generic;
using System.Text;

namespace MatchingLeafsOnTwoTrees
{
    public class Node
    {
        public Node LeftChild { get; set; }
        public Node RightChild { get; set; }
        public int Value { get; set; }

        public Node(int value)
        {
            Value = value;
        }
    }
}
