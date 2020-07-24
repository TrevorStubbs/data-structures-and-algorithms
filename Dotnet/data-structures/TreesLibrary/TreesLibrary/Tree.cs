using System;
using System.Collections.Generic;
using System.Text;

namespace TreesLibrary
{
    public class Tree<T>
    {
        public Node<T> Root { get; set; }

        /// <summary>
        /// Default constructor to build and empty Tree
        /// </summary>
        public Tree()
        {

        }

        /// <summary>
        /// Constructor to build a new tree with a defined root node
        /// </summary>
        /// <param name="value">Take a parameter of the instantiation defined type</param>
        public Tree(T value)
        {
            Node<T> root = new Node<T>(value);
            Root = root;
        }

        /// <summary>
        /// Move through the tree in a PreOrder (root first) fashion
        /// </summary>
        /// <param name="root">Take a parameter of the instantiation defined type</param>
        /// <returns>A list of the ordered nodes</returns>
        public List<T> PreOrder(Node<T> root)
        {
            List<T> traversal = new List<T>();
            PreOrder(traversal, root);

            return traversal;
        }

        /// <summary>
        /// Helper method for the PreOrder Method. Does the recursion.
        /// </summary>
        /// <param name="traversal">Takes the list defined by PreOrder above</param>
        /// <param name="root">Take the node of the root of the tree</param>
        private void PreOrder(List<T> traversal, Node<T> root)
        {
            traversal.Add(root.Value);

            if (root.LeftChild != null)
                PreOrder(traversal, root.LeftChild);
            if (root.RightChild != null)
                PreOrder(traversal, root.RightChild);
        }

        /// <summary>
        /// Move through the tree in a InOrder (root in the middle) fashion
        /// </summary>
        /// <param name="root">Take a parameter of the instantiation defined type</param>
        /// <returns>A list of the ordered nodes</returns>
        public List<T> InOrder(Node<T> root)
        {
            List<T> traversal = new List<T>();
            InOrder(traversal, root);

            return traversal;
        }

        /// <summary>
        /// Helper method for the InOrder Method. Does the recursion.
        /// </summary>
        /// <param name="traversal">Takes the list defined by InOrder above</param>
        /// <param name="root">Take the node of the root of the tree</param>
        private void InOrder(List<T> traversal, Node<T> root)
        {
            if (root.LeftChild != null)
                InOrder(traversal, root.LeftChild);

            traversal.Add(root.Value);

            if (root.RightChild != null)
                InOrder(traversal, root.RightChild);
        }

        /// <summary>
        /// Move through the tree in a PostOrder (root last) fashion
        /// </summary>
        /// <param name="root">Take a parameter of the instantiation defined type</param>
        /// <returns>A list of the ordered nodes</returns>
        public List<T> PostOrder(Node<T> root)
        {
            List<T> traversal = new List<T>();
            PostOrder(traversal, root);

            return traversal;
        }

        /// <summary>
        /// Helper method for the PostOrder Method. Does the recursion.
        /// </summary>
        /// <param name="traversal">Takes the list defined by PostOrder above</param>
        /// <param name="root">Take the node of the root of the tree</param>
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
