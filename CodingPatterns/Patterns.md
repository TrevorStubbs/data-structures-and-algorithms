# Coding Interview Patterns
- Reference: Educative.io Grokking the Coding Interview

## Sliding Window
- Try to reuse work that we have already done.
- The sliding window keeps track of the common elements from each pass 
    - Only add the new element and subtract the element no longer needed.
- Turns O(k*n) -> O(n)

``` CSharp
// While Loop
public static int UsingAWhileLoop(List<int> inputList)
{

    // Figure out the size of the window needs to be. 
    // Is it variable? How is it going to vary? 
    int windowSize = 5; 

    // These are the iterators for the window
    int windowEnd = 0; 
    int windowStart = 0;
    while(windowEnd < inputList.Count)
    {
        // Do something with the element at "windowEnd"
        something = inputList[windowEnd]


        // Figure out how to keep the window at the appropriate size. 
        if((windowEnd - windowStart) > windowSize)
        {
            // Do something with the beginning of the window.
            something -= inputList[windowStart];
            // Move the windowStart pointer.
            windowStart++;
        }

        // Iterate the windowEnd
        windowEnd++;
    }
}

// For Loop
public static int UsingAForLoop(List<int> inputList)
{
    int windowSize = 5;
    int windowStart = 0;

    for(int windowEnd = 0; windowEnd < inputList.Count; windowEnd++)
    {
        // Do something with the element at "windowEnd"
        something = inputList[windowEnd];

        if((windowEnd - windowStart) > windowSize)
        {
            // Do something with the beginning of the window.
            something -= inputList[windowStart];
            // Move the windowStart pointer.
            windowStart++;
        }
    }
}

```
## Two Pointer
## Fast & Slow
## Merge Intervals
## Cyclic Sort
## In-place Reversal of a Linked List
## Tree Breath First Search
## Tree Depth First Search
## Two Heaps
## Subset
## Modified Binary Search
## Bitwise XOR
## Top 'K' Elements
## K-Way Merge
## 0/1 Knapsack
## Topograical Sort
## 