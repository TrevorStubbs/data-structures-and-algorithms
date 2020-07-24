using System;
using System.Collections.Generic;
using System.Text;

namespace TreesLibrary
{
    public class BindarySearchTree
    {
        public Node<int> Root { get; set; }

        /// <summary>
        /// Default constructor to build and empty Tree
        /// </summary>
        public BindarySearchTree()
        {

        }

        /// <summary>
        /// Constructor to build a new tree with a defined root node
        /// </summary>
        /// <param name="value">Take a parameter of the instantiation defined type</param>
        public BindarySearchTree(int value)
        {
            Node<int> root = new Node<int>(value);
            Root = root;
        }

        /// <summary>
        /// Move through the tree in a PreOrder (root first) fashion
        /// </summary>
        /// <param name="root">Take a parameter of the instantiation defined type</param>
        /// <returns>A list of the ordered nodes</returns>
        public List<int> PreOrder(Node<int> root)
        {
            List<int> traversal = new List<int>();
            PreOrder(traversal, root);

            return traversal;
        }

        /// <summary>
        /// Helper method for the PreOrder Method. Does the recursion.
        /// </summary>
        /// <param name="traversal">Takes the list defined by PreOrder above</param>
        /// <param name="root">Take the node of the root of the tree</param>
        private void PreOrder(List<int> traversal, Node<int> root)
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
        public List<int> InOrder(Node<int> root)
        {
            List<int> traversal = new List<int>();
            InOrder(traversal, root);

            return traversal;
        }

        /// <summary>
        /// Helper method for the InOrder Method. Does the recursion.
        /// </summary>
        /// <param name="traversal">Takes the list defined by InOrder above</param>
        /// <param name="root">Take the node of the root of the tree</param>
        private void InOrder(List<int> traversal, Node<int> root)
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
        public List<int> PostOrder(Node<int> root)
        {
            List<int> traversal = new List<int>();
            PostOrder(traversal, root);

            return traversal;
        }

        /// <summary>
        /// Helper method for the PostOrder Method. Does the recursion.
        /// </summary>
        /// <param name="traversal">Takes the list defined by PostOrder above</param>
        /// <param name="root">Take the node of the root of the tree</param>
        private void PostOrder(List<int> traversal, Node<int> root)
        {
            if (root.LeftChild != null)
                PostOrder(traversal, root.LeftChild);

            if (root.RightChild != null)
                PostOrder(traversal, root.RightChild);

            traversal.Add(root.Value);
        }

    }
}
