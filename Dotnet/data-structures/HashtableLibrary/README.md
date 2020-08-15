# StacksAndQueues
This Data Structure demonstrates how a hashtable is constructed.

## Challenge
1. Adding a key/value to your hashtable results in the value being in the data structure
1. Retrieving based on a key returns the value stored
1. Successfully returns null for a key that does not exist in the hashtable
1. Successfully handle a collision within the hashtable
1. Successfully retrieve a value from a bucket within the hashtable that has a collision
1.Successfully hash a key to an in-range value

## Approach & Efficiency
- Hashtable<T>.GetHash(string key) Time: O(1) | Space: O(1)
- Hashtable<T>.Add(string key, T value) Time: O(1) | Space: O(1)
- Hashtable<T>.Contains(string key) Time: O(1) | Space: O(1)



## API
- Hashtable<>.Add(string key)
- Hashtable<>.Contains(string key, T value)

---