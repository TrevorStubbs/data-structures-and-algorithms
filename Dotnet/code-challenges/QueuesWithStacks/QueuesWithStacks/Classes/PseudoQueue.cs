using StacksAndQueuesLibrary;
using System;


namespace QueuesWithStacks.Classes
{
    public class PseudoQueue<T>
    {
        private Stack<T> Storage = new Stack<T>();
        private Stack<T> Temp = new Stack<T>();

        Node<T> Front { get; set; }
        Node<T> Rear { get; set; }

        /// <summary>
        /// Checks to see if the stack is empty. If it is then a push the new node onto the stack and point everything to it.
        /// If the stack has something in it then push the new node onto the stack and only point the rear to that node.
        /// </summary>
        /// <param name="value">Takes the value of the new node</param>
        public void Enqueue(T value)
        {
            if (Storage.IsEmpty())
            {
                Storage.Push(value);
                Rear = Storage.Top;
                Front = Storage.Top;
            }
            else
            {
                Storage.Push(value);
                Rear = Storage.Top;
            }
        }

        /// <summary>
        /// Take all the nodes and one by one put them into a temporary stack. The first node on the temp stack is the answer.
        /// Put all the nodes back into the storage stack.
        /// </summary>
        /// <returns>Returns the value of the "rear" node.</returns>
        public T Dequeue()
        {
            if (Storage.Top == null)
                throw new Exception("The pseudo-queue is empty.");

            while (Storage.Top != null)
            {
                Node<T> poppedNode = Storage.Pop();
                Temp.Push(poppedNode.Value);
            }

            Node<T> returnAnswer = Temp.Pop();

            while(Temp.Top != null)
            {
                Node<T> poppedNode = Temp.Pop();
                Storage.Push(poppedNode.Value);
            }

            return returnAnswer.Value;
        }

        public T Peek()
        {
            return Storage.Peek();
        }
    }
}
