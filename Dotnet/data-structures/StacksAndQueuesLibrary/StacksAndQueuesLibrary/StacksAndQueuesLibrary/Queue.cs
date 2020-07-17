using System;
using System.Collections.Generic;
using System.Text;

namespace StacksAndQueuesLibrary
{
    public class Queue
    {
        private Node Front { get; set; }
        private Node Rear { get; set; }

        public Queue()
        {
            Rear = Front;
        }

        public void Enqueue(string value)
        {
            Node newNode = new Node(value);

            if (Front == null)
            {
                Front = newNode;
                Rear = newNode;
            }
            else
            {
                Rear.Next = newNode;
                Rear = newNode;
            }
        }

        /// <summary>
        /// Call IsEmpty. If it's false return the value of Front else throw an error.
        /// </summary>
        /// <returns>Returns the value of Front or throws and error</returns>
        public string Peek()
        {
            if (IsEmpty())
            {
                throw new Exception("The queue is empty.");
            }
            else
                return Front.Value;
        }

        /// <summary>
        /// Look at the front node of the queue. Return true if it's empty else return false.
        /// </summary>
        /// <returns>True or false</returns>
        public bool IsEmpty()
        {
            if (Front == null)
                return true;
            else
                return false;
        }

        public Node Dequeue()
        {
            if (!IsEmpty())
            {
                Node temp = Front;
                Front = Front.Next;
                temp.Next = null;
                return temp;
            }
            else
            {
                throw new Exception("The queue is empty.");
            }
        }
    }
}
