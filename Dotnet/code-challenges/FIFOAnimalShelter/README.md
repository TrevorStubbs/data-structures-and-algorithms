## FIFO Animal Shelter
*Author: Trevor Stubbs*

---

### Problem Domain
- Create a class called AnimalShelter which holds only dogs and cats. The shelter operates using a first-in, first-out approach.
- Implement the following methods:
    - `enqueue(animal)`: adds animal to the shelter. animal can be either a dog or a cat object.
    - `dequeue(pref)`: returns either a dog or a cat. If pref is not "dog" or "cat" then return null.

---

### Inputs and Expected Outputs (Enqueue(animal)

Interal State(Before) | Input1 | Internal State(After) |
| :--- | :----------- | :----------- |
| [Dog Object, Cat Object, Cat Object] | Dog Object | [Dog Object, Dog Object, Cat Object, Cat Object]


### Inputs and Expected Outputs (Dequeue(perf))

| Input | Output|
--- | --- | ---
"cat" or "dog" | Cat Object or Dog Object


---

### Big O (Enqueue(animal)


| Time | Space |
| :----------- | :----------- |
| O(1) | O(1) |

### Big O (Enqueue(animal)

| Time | Space |
| :----------- | :----------- |
| O(n) | O(1) |

---


### Whiteboard Visual
![WhiteBoard](assets/CodeChallenges12.png)


---

### Change Log
- 1.4: README and Summary Comments
- 1.3: Tests
- 1.2: Dequeue(perf) Finished
- 1.1: Enqueue(Animal) Finished
- 1.0: Repo Setup 

---

For more information on Markdown: https://www.markdownguide.org/cheat-sheet