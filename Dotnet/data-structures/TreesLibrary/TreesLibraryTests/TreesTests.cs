using System;
using Xunit;
using TreesLibrary;
using System.Collections.Generic;

namespace TreesLibraryTests
{
    public class InstantiatingTreeTests
    {
        [Fact]
        public void CanInstantiateAnEmptyTree()
        {
            // Arrange
            Tree<string> tree = new Tree<string>();
            // Act
            // Assert
            Assert.Null(tree.Root);
        }

        [Fact]
        public void CanInstantiateATreeWithASingleRootNode()
        {
            // Arrange
            Tree<string> tree = new Tree<string>("I Am Dog");
            // Act
            string expected = "I Am Dog";
            // Assert
            Assert.NotNull(tree.Root);
            Assert.Equal(expected, tree.Root.Value);
        }

        [Fact]
        public void CanAddALeftChildAndRightChildToASingleRootNode()
        {
            //Arrange
            Tree<string> tree = new Tree<string>("Root");
            //Act
            tree.Root.RightChild = new Node<string>("RightChild");
            tree.Root.LeftChild = new Node<string>("LeftChild");
            string rightExpected = "RightChild";
            string leftExpected = "LeftChild";
            //Assert
            Assert.NotNull(tree.Root.RightChild);
            Assert.Equal(rightExpected, tree.Root.RightChild.Value);
            Assert.NotNull(tree.Root.LeftChild);
            Assert.Equal(leftExpected, tree.Root.LeftChild.Value);
        }
    }

    public class PreOrderInOrderAndPostOrderTests
    {
        [Fact]
        public void CanReturnACollectionFromAPreorderTraversal()
        {
            // Arrange

            Tree<int> tree = new Tree<int>();

            Node<int> root = new Node<int>(1);
            Node<int> two = new Node<int>(2);
            Node<int> three = new Node<int>(3);
            Node<int> four = new Node<int>(4);
            Node<int> five = new Node<int>(5);
            Node<int> six = new Node<int>(6);
            Node<int> seven = new Node<int>(7);            

            tree.Root = root;

            root.LeftChild = two;
            root.RightChild = three;

            two.LeftChild = four;
            two.RightChild = five;

            three.LeftChild = six;
            three.RightChild = seven;

            List<int> order = new List<int>()
            {
                1,2,4,5,3,6,7
            };

            // Act

            List<int> preOrder = tree.PreOrder(tree.Root);

            // Assert
            Assert.Equal(order, preOrder);
        }

        [Fact]
        public void CanReturnACollectionFromAnInorderTraversal()
        {
            // Arrange

            Tree<int> tree = new Tree<int>();

            Node<int> root = new Node<int>(1);
            Node<int> two = new Node<int>(2);
            Node<int> three = new Node<int>(3);
            Node<int> four = new Node<int>(4);
            Node<int> five = new Node<int>(5);
            Node<int> six = new Node<int>(6);
            Node<int> seven = new Node<int>(7);

            tree.Root = root;

            root.LeftChild = two;
            root.RightChild = three;

            two.LeftChild = four;
            two.RightChild = five;

            three.LeftChild = six;
            three.RightChild = seven;

            List<int> order = new List<int>()
            {
                4,2,5,1,6,3,7
            };

            // Act

            List<int> preOrder = tree.InOrder(tree.Root);

            // Assert
            Assert.Equal(order, preOrder);
        }

        [Fact]
        public void CanReturnACollectionFromAPostorderTraversal()
        {
            // Arrange

            Tree<int> tree = new Tree<int>();

            Node<int> root = new Node<int>(1);
            Node<int> two = new Node<int>(2);
            Node<int> three = new Node<int>(3);
            Node<int> four = new Node<int>(4);
            Node<int> five = new Node<int>(5);
            Node<int> six = new Node<int>(6);
            Node<int> seven = new Node<int>(7);

            tree.Root = root;

            root.LeftChild = two;
            root.RightChild = three;

            two.LeftChild = four;
            two.RightChild = five;

            three.LeftChild = six;
            three.RightChild = seven;

            List<int> order = new List<int>()
            {
                4,5,2,6,7,3,1
            };

            // Act

            List<int> preOrder = tree.PostOrder(tree.Root);

            // Assert
            Assert.Equal(order, preOrder);
        }

    }
}
