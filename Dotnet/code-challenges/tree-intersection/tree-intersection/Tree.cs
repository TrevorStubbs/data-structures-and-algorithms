using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace tree_intersection
{
    public class Tree
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

        /// <summary>
        /// An in order traversal of the tree to fill up a hashset.
        /// </summary>
        /// <param name="root">A Node Object</param>
        /// <returns>a filled hashset</returns>
        public HashSet<int> InOrderHash(Node root)
        {
            HashSet<int> set = new HashSet<int>();
            InOrderHash(set, root);

            return set;
        }

        /// <summary>
        /// Helper function to fill the hashset with items from the tree
        /// </summary>
        /// <param name="set">the hashset to be filled</param>
        /// <param name="root">The root node object</param>
        private void InOrderHash(HashSet<int> set, Node root)
        {
            if (root.LeftChild != null)
                InOrderHash(set, root.LeftChild);

            set.Add(root.Value);

            if (root.RightChild != null)
                InOrderHash(set, root.RightChild);
        }

        /// <summary>
        /// An in order traversal of the tree to fill up a list.
        /// </summary>
        /// <param name="root">A Node Object</param>
        /// <returns>a filled list</returns>
        public List<int> InOrderList(Node root)
        {
            List<int> list = new List<int>();
            InOrderList(list, root);

            return list;
        }

        /// <summary>
        /// Helper function to fill the list with items from the tree
        /// </summary>
        /// <param name="set">the list to be filled</param>
        /// <param name="root">The root node object</param>
        private void InOrderList(List<int> list, Node root)
        {
            if (root.LeftChild != null)
                InOrderList(list, root.LeftChild);

            list.Add(root.Value);

            if (root.RightChild != null)
                InOrderList(list, root.RightChild);
        }

        /// <summary>
        /// Add method to make the tree a BST.
        /// </summary>
        /// <param name="root">A Node for the root</param>
        /// <param name="value">A value to fill the new node</param>
        /// <returns>A filled Node Object</returns>
        public Node Add(Node root, int value)
        {
            if(root == null)
            {
                root = new Node(value);
                return root;
            }

            if (value < root.Value)
                root.LeftChild = Add(root.LeftChild, value);
            else if (value > root.Value)
                root.RightChild = Add(root.RightChild, value);

            return root;            
        }

    }
}
