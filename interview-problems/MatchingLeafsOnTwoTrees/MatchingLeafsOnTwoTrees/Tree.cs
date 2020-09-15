using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Text;

namespace MatchingLeafsOnTwoTrees
{
    class Tree
    {
        public Node Root { get; set; }

        public Tree()
        {

        }

        public Tree(int value)
        {
            Node root = new Node(value);
            Root = root;
        }

        public Node Add(Node root, int value)
        {
            if(root == null)
            {
                root = new Node(value);
                return root;
            }

            if (value < root.Value)
            {
                root.LeftChild = Add(root.LeftChild, value);
            }
            else if (value > root.Value)
            {
                root.RightChild = Add(root.RightChild, value);
            }

            return root;
        }

        public Queue<int> LeafQueueBuild(Node root)
        {
            Queue<int> que = new Queue<int>();
            LeafQueueBuild(que, root);

            return que;
        }

        private Queue<int> LeafQueueBuild(Queue<int> que, Node root)
        {
            if(root.LeftChild == null && root.RightChild == null)
            {
                que.Enqueue(root.Value);
            }

            if(root.LeftChild != null)
            {
                LeafQueueBuild(que, root.LeftChild);
            }
            if(root.RightChild != null)
            {
                LeafQueueBuild(que, root.RightChild);
            }

            return que;
        }

        public bool MatchChecker(Queue<int> que, Node root)
        {
            bool output = false;

            if(root.LeftChild == null && root.RightChild == null)
            {
                if(que.Dequeue() == root.Value)
                    output = true;
            }

            if(root.LeftChild != null)
            {
               output = MatchChecker(que, root.LeftChild);
            }
            if(root.RightChild != null)
            {
               output = MatchChecker(que, root.RightChild);
            }

            return output;
        }
    }
}
