using StacksAndQueuesLibrary;
using System;
using System.Collections;
using System.Text;

namespace FIFOAnimalShelter.Classes
{
    public class AnimalShelter
    {
        public Queue<Animal> Shelter = new Queue<Animal>();

        /// <summary>
        /// This take an animal object and puts it into the shelter
        /// </summary>
        /// <param name="animal">Takes an animal object.</param>
        public void Enqueue(Animal animal)
        {
            Shelter.Enqueue(animal);
        }

        /// <summary>
        /// Goes through the queue to find the first instance of that type of animal.
        /// </summary>
        /// <param name="perf"></param>
        /// <returns></returns>
        public Animal Dequeue(Animal perf)
        {
            switch (perf)
            {

            }

            Animal startChecker = Shelter.Front.Value;

            Node<Animal> start = Shelter.Front;
            start = Shelter.Dequeue();
            if (start.Value.GetType() == perf.GetType())
                return start.Value;
            else
                Shelter.Enqueue(start.Value);

            while(Shelter.Front.Value != startChecker)
            {
                Node<Animal> temp = Shelter.Dequeue();
                if (temp.Value.GetType() == perf.GetType())
                    return temp.Value;
                else
                    Shelter.Enqueue(temp.Value);
            }
            return null;
        }
    }
}
