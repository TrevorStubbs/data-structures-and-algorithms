using StacksAndQueuesLibrary;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text;

namespace QueuesWithStacks.Classes
{
    public class PseudoQueue<T>
    {
        public Stack<T> Storage = new Stack<T>();
        public Stack<T> Temp = new Stack<T>();

        Node<T> Front { get; set; }
        Node<T> Rear { get; set; }

        public PseudoQueue()
        {
            Storage.Top = Temp.Top;
            Front = Storage.Top;
            Rear = Storage.Top; // May be a problem
        }

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
    }
}
