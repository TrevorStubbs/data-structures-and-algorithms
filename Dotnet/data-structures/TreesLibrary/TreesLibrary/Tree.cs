using System;
using System.Collections.Generic;
using System.Text;

namespace TreesLibrary
{
    public class Tree<T>
    {
        public Node<T> Root { get; set; }

        public Tree()
        {

        }

        public Tree(T value)
        {
            Node<T> root = new Node<T>(value);
            Root = root;
        }

        public List<T> PreOrder(Node<T> root)
        {
            List<T> traversal = new List<T>();
            PreOrder(traversal, root);

            return traversal;
        }

        private void PreOrder(List<T> traversal, Node<T> root)
        {
            traversal.Add(root.Value);

            if (root.LeftChild != null)
                PreOrder(traversal, root.LeftChild);
            if (root.RightChild != null)
                PreOrder(traversal, root.RightChild);
        }

        public List<T> InOrder(Node<T> root)
        {
            List<T> traversal = new List<T>();
            InOrder(traversal, root);

            return traversal;
        }

        private void InOrder(List<T> traversal, Node<T> root)
        {
            if (root.LeftChild != null)
                InOrder(traversal, root.LeftChild);

            traversal.Add(root.Value);

            if (root.RightChild != null)
                InOrder(traversal, root.RightChild);
        }

        public List<T> PostOrder(Node<T> root)
        {
            List<T> traversal = new List<T>();
            PostOrder(traversal, root);

            return traversal;
        }

        private void PostOrder(List<T> traversal, Node<T> root)
        {
            if (root.LeftChild != null)
                PostOrder(traversal, root.LeftChild);

            if (root.RightChild != null)
                PostOrder(traversal, root.RightChild);

            traversal.Add(root.Value);
        }
    }
}
