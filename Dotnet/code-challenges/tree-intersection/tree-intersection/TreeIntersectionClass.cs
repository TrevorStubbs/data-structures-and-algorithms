using System;
using System.Collections.Generic;
using System.Text;

namespace tree_intersection
{
    public static class TreeIntersectionClass
    {
        /// <summary>
        /// This method builds a hashset and then a list. It loops through the list checking to see if there are matches between the hashset and the list and if it is then I add it to an output list.
        /// I know this is ugly but I am burned out.
        /// </summary>
        /// <param name="tree1">An integer tree</param>
        /// <param name="tree2">An integer tree</param>
        /// <returns>returns a list of intersecting of integers</returns>
        public static List<int> TreeIntersection(Tree tree1, Tree tree2)
        {
            HashSet<int> hashTree = tree1.InOrderHash(tree1.Root);

            List<int> listTree = tree2.InOrderList(tree2.Root);

            List<int> outputList = new List<int>();

            foreach(var item in listTree)
            {
                if (hashTree.Contains(item))
                {
                    outputList.Add(item);
                }
            }

            return outputList;
        }
    }
}
