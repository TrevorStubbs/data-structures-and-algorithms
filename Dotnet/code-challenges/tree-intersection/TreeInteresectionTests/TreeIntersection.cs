using System;
using Xunit;
using tree_intersection;
using System.Collections.Generic;

namespace TreeInteresectionTests
{
    public class TreeIntersection
    {
        [Fact]
        public void ProvidedExample()
        {
            Tree tree1 = new Tree(150);
            Tree tree2 = new Tree(42);

     
            tree1.Add(tree1.Root, 100);
            tree1.Add(tree1.Root, 75);
            tree1.Add(tree1.Root, 160);
            tree1.Add(tree1.Root, 125);
            tree1.Add(tree1.Root, 175);
            tree1.Add(tree1.Root, 250);
            tree1.Add(tree1.Root, 200);
            tree1.Add(tree1.Root, 350);
            tree1.Add(tree1.Root, 300);
            tree1.Add(tree1.Root, 500);


            tree2.Add(tree2.Root, 100);
            tree2.Add(tree2.Root, 15);
            tree2.Add(tree2.Root, 125);
            tree2.Add(tree2.Root, 160);
            tree2.Add(tree2.Root, 175);
            tree2.Add(tree2.Root, 600);
            tree2.Add(tree2.Root, 200);
            tree2.Add(tree2.Root, 350);
            tree2.Add(tree2.Root, 4);
            tree2.Add(tree2.Root, 500);

            var returnFromMethod = TreeIntersectionClass.TreeIntersection(tree1, tree2);

            List<int> expected = new List<int>
            {
                100,125,160,175,200,350,500
            };

            Assert.NotNull(returnFromMethod);
            Assert.Equal(expected, returnFromMethod);
        }

        [Fact]
        public void MyOwnTest1()
        {
            Tree tree1 = new Tree(150);
            Tree tree2 = new Tree(42);


            tree1.Add(tree1.Root, 1);
            tree1.Add(tree1.Root, 7);
            tree1.Add(tree1.Root, 16);
            tree1.Add(tree1.Root, 15);

            tree2.Add(tree2.Root, 100);
            tree2.Add(tree2.Root, 15);
            tree2.Add(tree2.Root, 125);
            tree2.Add(tree2.Root, 16);
            tree2.Add(tree2.Root, 75);


            var returnFromMethod = TreeIntersectionClass.TreeIntersection(tree1, tree2);

            List<int> expected = new List<int>
            {
                15,16
            };

            Assert.NotNull(returnFromMethod);
            Assert.Equal(expected, returnFromMethod);
        }

        [Fact]
        public void NoMatches()
        {
            Tree tree1 = new Tree(150);
            Tree tree2 = new Tree(42);


            tree1.Add(tree1.Root, 1);
            tree1.Add(tree1.Root, 7);
            tree1.Add(tree1.Root, 16);
            tree1.Add(tree1.Root, 15);

            tree2.Add(tree2.Root, 100);
            tree2.Add(tree2.Root, 115);
            tree2.Add(tree2.Root, 125);
            tree2.Add(tree2.Root, 160);
            tree2.Add(tree2.Root, 750);


            var returnFromMethod = TreeIntersectionClass.TreeIntersection(tree1, tree2);

            List<int> expected = new List<int>
            {
            };

            Assert.NotNull(returnFromMethod);
            Assert.Equal(expected, returnFromMethod);
        }
    }
}
