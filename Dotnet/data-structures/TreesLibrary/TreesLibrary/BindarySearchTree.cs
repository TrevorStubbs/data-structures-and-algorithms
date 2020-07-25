using System;
using System.Collections.Generic;
using System.Data;
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

        /// <summary>
        /// The main method for adding a number to the BST
        /// </summary>
        /// <param name="value">Takes an integer to build the node</param>
        public void Add(int value)
        {
            Root = Add(Root, value);
        }

        /// <summary>
        /// Helper method for the add method. Does all the recursion.
        /// Compaires the value to the root and either moves left or right. 
        /// When a leaf is found the value is place in its proper place.
        /// </summary>
        /// <param name="root">The current root node</param>
        /// <param name="value">Takes an integer to build the node</param>
        /// <returns>Returns the current root node</returns>
        public Node<int> Add(Node<int> root, int value)
        {
            if (root == null)
            {
                root = new Node<int>(value);
                return root;
            }

            if (value < root.Value)
                root.LeftChild = Add(root.LeftChild, value);
            else if (value > root.Value)
                root.RightChild = Add(root.RightChild, value);

            return root;
        }

        /// <summary>
        /// Method to check if the entered value is in the tree
        /// </summary>
        /// <param name="value">An integer for the value</param>
        /// <returns>Returns a boolean</returns>
        public bool Contains(int value)
        {
            if (Root == null)
                return false;
            else
                return Contains(Root, value);
        }

        /// <summary>
        /// The helper method for the above Contains method. This has the recursion.
        /// This checks to see if the selected value is larger or smaller than the root and either moves left or right
        /// down the tree until either the end is found or the node is found.
        /// </summary>
        /// <param name="root">The current root node</param>
        /// <param name="value">The int value that is searched</param>
        /// <returns>Returns a boolean to the caller</returns>
        public bool Contains(Node<int> root, int value)
        {
            bool output = false;

            if (value < root.Value)
            {
                if (root.LeftChild != null)
                    output = Contains(root.LeftChild, value);
            }
            else if (value > root.Value)
            {
                if (root.RightChild != null)
                    output = Contains(root.RightChild, value);
            }
            else if (root.Value == value)
            {
                output = true;
            }

            return output;

        }


    }
}
