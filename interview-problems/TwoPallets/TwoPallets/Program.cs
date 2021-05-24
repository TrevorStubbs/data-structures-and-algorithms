using System;
using System.Collections.Generic;

namespace TwoPallets
{
    class Program
    {
        // You are given a pallet of boxes in a list, each number in the list represents a box's weight. The first digit in the list is how many boxes are in the pallet. You need to separate out the boxes so that the first pallet weights more than the second pallet. But there needs to be the least number of boxes in the first pallet as possible.
        // Constraints
        // Number of boxes in pallet A needs to be >= 2.
        // Any duplicate weights needs to be in the same pallet.
        // Sample: [ 5, 5, 3, 1, 2, 4 ]

        // Loop through to add up weights. If there is at least 1 match in that loop then return the pallet with the greatest weight. If not move to the next number of boxes.
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var input = new List<int>() { 5, 5, 3, 1, 2, 4 };

            var boxList = BuildSmallestHeaviestPalletA(input);

            foreach (var box in boxList)
            {
                Console.Write($"{box} ");
            }
        }

        public static List<int> BuildSmallestHeaviestPalletA(List<int> totalPallet)
        {
            var minimumPalletSize = 2;
            var originalPallet = new Pallet(totalPallet);

            // Tests Pallets
            //var listA = new List<int>() { originalPallet.Boxes[0], originalPallet.Boxes[1] };
            //var listB = new List<int>() { originalPallet.Boxes[2], originalPallet.Boxes[3], originalPallet.Boxes[4] };
            //var palletA = new Pallet(listA.Count, listA);
            //var palletB = new Pallet(listB.Count, listB);


            Pallet SmallestHeaviestPallet = BuildSmallestHeaviestPalletA(originalPallet, minimumPalletSize);


            return SmallestHeaviestPallet.Boxes;
        }

        private static Pallet BuildSmallestHeaviestPalletA(Pallet originalPallet, int numberOfIndexes)
        {
            // Base Case
            if (numberOfIndexes > originalPallet.NumberOfBoxes)
            {
                return null;
            }


            // Best pallets is: number of boxes Min (at least 2), Total Weights at max.
            var listOfPalletAs = new List<Pallet>(); //if listOfPalletAs.Count > 0 the return the Pallet from this group that has the highest weight.

            foreach (var weight in originalPallet.Boxes)
            {

                foreach (var box in originalPallet.Boxes)
                {
                    List<int> weightsA = new List<int>() { weight };
                    List<int> weightsB = new List<int>(originalPallet.Boxes);

                    weightsB.RemoveAt(weightsB.IndexOf(weight));
                    if (!(originalPallet.Boxes.IndexOf(box) == originalPallet.Boxes.IndexOf(weight)))
                    {
                        weightsA.Add(box);
                        weightsB.RemoveAt(weightsB.IndexOf(box));

                        Pallet palletA = new Pallet(weightsA.Count, weightsA);
                        Pallet palletB = new Pallet(weightsB.Count, weightsB);

                        if (CompareTwoPallets(palletA, palletB))
                            listOfPalletAs.Add(palletA);
                    }

                }


            }

            if (listOfPalletAs.Count > 0)
            {
                Pallet heaviestPallet = FindHeaviestPallet(listOfPalletAs);

                return heaviestPallet;
            }

            // Recursive
            // If we haven't found an appropriately sized pallet then increase the number of boxes to search.
            var pallet = BuildSmallestHeaviestPalletA(originalPallet, numberOfIndexes++);

            return pallet;
        }

        private static Pallet FindHeaviestPallet(List<Pallet> listOfPallets)
        {
            Pallet heaviest = new Pallet();

            foreach (var pallet in listOfPallets)
            {
                if (pallet.TotalWeight > heaviest.TotalWeight)
                    heaviest = pallet;
            }

            return heaviest;
        }

        private static bool CompareTwoPallets(Pallet palletA, Pallet palletB)
        {
            if (palletA.TotalWeight > palletB.TotalWeight)
            {
                Console.WriteLine($"PalletA: {palletA.TotalWeight}, PalletB: {palletB.TotalWeight}");
                return true;
            }

            return false;
        }

        public class Pallet
        {
            public int NumberOfBoxes { get; set; }
            public List<int> Boxes { get; set; }
            public int TotalWeight { get; set; }

            public Pallet()
            {
                NumberOfBoxes = 0;
                Boxes = null;
                TotalWeight = 0;
            }

            public Pallet(List<int> inputList)
            {
                NumberOfBoxes = inputList[0];
                Boxes = inputList;
                Boxes.RemoveAt(0);
                TotalWeight = CalculateWeights();
            }

            public Pallet(int boxNumber, List<int> inputList)
            {
                NumberOfBoxes = boxNumber;
                Boxes = inputList;
                TotalWeight = CalculateWeights();
            }

            public void UpdateBoxes(List<int> newList)
            {
                Boxes = newList;
                TotalWeight = CalculateWeights();
                NumberOfBoxes = Boxes.Count;
            }

            private int CalculateWeights()
            {
                var total = 0;
                foreach (var box in Boxes)
                {
                    total += box;
                }

                return total;
            }
        }
    }
}
