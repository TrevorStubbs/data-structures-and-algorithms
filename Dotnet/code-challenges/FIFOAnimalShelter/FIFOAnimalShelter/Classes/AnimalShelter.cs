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
        /// Goes through the queue to find the first instance of the preferred type of animal.
        /// </summary>
        /// <param name="perf">Takes in a string of either "cat" or "dog"</param>
        /// <returns>Returns either null or the first cat or dog</returns>
        public Animal Dequeue(string perf)
        {

            Animal preference = new Animal();
            switch (perf)
            {
                case "cat":
                    preference = new Cat();
                    break;
                case "dog":
                    preference = new Dog();
                    break;
                default:
                    Console.WriteLine("Say Again");
                    break;
            }

            Animal startChecker = Shelter.Front.Value;

            Node<Animal> start = Shelter.Front;
            start = Shelter.Dequeue();
            if (start.Value.GetType() == preference.GetType())
            {
                return start.Value;
            }
            else
            {
                Shelter.Enqueue(start.Value);
            }

            while (Shelter.Front.Value != startChecker)
            {
                Node<Animal> temp = Shelter.Dequeue();
                if (temp.Value.GetType() == preference.GetType())
                    return temp.Value;
                else
                    Shelter.Enqueue(temp.Value);
            }
            return null;
        }
    }
}
