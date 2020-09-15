using System;
using System.Collections;
using System.Collections.Generic;

namespace MatchingLeafsOnTwoTrees
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree tree1 = new Tree(150);
            Tree tree2 = new Tree(150);


            tree1.Add(tree1.Root, 100);
            tree1.Add(tree1.Root, 160);
            tree1.Add(tree1.Root, 60);

            tree2.Add(tree2.Root, 100);
            tree2.Add(tree2.Root, 160);
            tree2.Add(tree2.Root, 60);


            Console.WriteLine(MatchingLeafsOnTwoTrees(tree1, tree2));
        }

        public static bool MatchingLeafsOnTwoTrees(Tree tree1, Tree tree2)
        {
            Queue<int> que = tree1.LeafQueueBuild(tree1.Root);

            bool firstCheck = tree2.MatchChecker(que, tree2.Root);
            bool output = FinalCheck(que, firstCheck);

            return output;
        }

        public static bool FinalCheck(Queue<int> que, bool helper)
        {
            if (helper && que.TryPeek(out _))
            {
                return true;
            }
            return false;
        }
    }
}
