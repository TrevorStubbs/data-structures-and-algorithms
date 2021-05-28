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
                if(boxList.IndexOf(box) == boxList.Count - 1)
                    Console.WriteLine($"{box}");
                else
                    Console.Write($"{box}, ");
            }

            var input2 = new List<int>() { 12, 100, 50, 49, 48, 47, 46, 45, 44, 43, 42, 41, 40 };
            var boxList2 = TwoPalletsV2(input2);

            foreach (var box in boxList2)
            {
                if (boxList2.IndexOf(box) == boxList2.Count - 1)
                    Console.WriteLine($"{box}");
                else
                    Console.Write($"{box}, ");
            }
        }

        public static List<int> TwoPalletsV2(List<int> inputPallet)
        {
            var checker = inputPallet[0];
            inputPallet.RemoveAt(0);

            if (checker != inputPallet.Count)
                throw new Exception("The input data is invalid.");

            inputPallet.Sort();
            inputPallet.Reverse();

            var palletA = new List<int>();
            palletA.Add(inputPallet[0]);
            inputPallet.RemoveAt(0);

            var palletB = new List<int>(inputPallet);            

            foreach (var box in inputPallet)
            {
                palletA.Add(box);
                palletB.Remove(box);

                if(IsListABiggerThanListB(palletA, palletB))
                {
                    return palletA;
                }
            }

            return null;
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

                        if (IsPalletABiggerThanPalletB(palletA, palletB))
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

        private static Pallet BuildSmallestHeaviestPalletAV2(Pallet originalPallet, int numberOfIndexes, List<List<int>> listOfIndexes = null)
        {
            // Base Case
            if (numberOfIndexes > originalPallet.NumberOfBoxes)
            {
                return null;
            }

            if (listOfIndexes == null)
            {
                listOfIndexes = new List<List<int>>();
                listOfIndexes.Add(new List<int>() { originalPallet.Boxes[0], originalPallet.Boxes[1] });
            }

            // Best pallets is: number of boxes Min (at least 2), Total Weights at max.
            var listOfPalletAs = new List<Pallet>(); //if listOfPalletAs.Count > 0 the return the Pallet from this group that has the highest weight.

            var tempList = new List<List<int>>();
            foreach (var list in listOfIndexes)
            {
                List<int> weights = new List<int>();

                foreach (var number in list)
                {
                    weights.Add(number);
                }

                foreach (var weight in originalPallet.Boxes)
                {
                    
                    var indexList = new List<int>();
                    indexList.Add(originalPallet.Boxes.IndexOf(weight));

                    foreach (var box in originalPallet.Boxes)
                    {
                        indexList.Add(originalPallet.Boxes.IndexOf(box));
                        List<int> weightsA = new List<int>() { weight };
                        List<int> weightsB = new List<int>(originalPallet.Boxes);

                        weightsB.RemoveAt(weightsB.IndexOf(weight));
                        if (!(originalPallet.Boxes.IndexOf(box) == originalPallet.Boxes.IndexOf(weight)))
                        {
                            weightsA.Add(box);
                            weightsB.RemoveAt(weightsB.IndexOf(box));

                            Pallet palletA = new Pallet(weightsA.Count, weightsA);
                            Pallet palletB = new Pallet(weightsB.Count, weightsB);

                            if (IsPalletABiggerThanPalletB(palletA, palletB))
                                listOfPalletAs.Add(palletA);
                        }

                        tempList.Add(indexList);
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
            var pallet = BuildSmallestHeaviestPalletAV2(originalPallet, numberOfIndexes++, tempList);

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

        private static bool IsPalletABiggerThanPalletB(Pallet palletA, Pallet palletB)
        {
            if (palletA.TotalWeight > palletB.TotalWeight)
            {
                Console.WriteLine($"PalletA: {palletA.TotalWeight}, PalletB: {palletB.TotalWeight}");
                return true;
            }

            return false;
        }

        private static bool IsListABiggerThanListB(List<int> palletA, List<int> palletB)
        {
            var palletASum = GetSumOfList(palletA);
            var palletBSum = GetSumOfList(palletB);

            if (palletASum > palletBSum)
            {
                Console.WriteLine($"PalletA: {palletASum}, PalletB: {palletBSum}");
                return true;
            }

            return false;
        }

        private static int GetSumOfList(List<int> inputList)
        {
            int sum = 0;
            foreach (var box in inputList)
            {
                sum += box;
            }

            return sum;
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
