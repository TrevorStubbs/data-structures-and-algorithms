using FIFOAnimalShelter.Classes;
using System;
using StacksAndQueuesLibrary;

namespace FIFOAnimalShelter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Kyungrae! Thanks for your hard work.");

            EnqueueTheShelter();
            Console.WriteLine();
            DequeueTheShelter();
        }

        /// <summary>
        /// This tests if the queueing works
        /// </summary>
        static void EnqueueTheShelter()
        {
            AnimalShelter shelter = new AnimalShelter();

            Dog dog = new Dog() { Name = "Spot", Loudness = 10m };
            shelter.Enqueue(dog);

            Cat cat = new Cat() { Name = "Josie", Cuteness = 1000m };
            shelter.Enqueue(cat);

            Console.Write("First Animal ");
            Node<Animal> animal = shelter.Shelter.Dequeue();
            Console.WriteLine(animal.Value.Name);

            Console.Write("Second Animal ");
            animal = shelter.Shelter.Dequeue();
            Console.WriteLine(animal.Value.Name);
        }


        /// <summary>
        /// This tests if the dequeueing works
        /// </summary>
        static void DequeueTheShelter()
        {
            AnimalShelter shelter = new AnimalShelter();

            Dog dog = new Dog() { Name = "Spot", Loudness = 10m };
            shelter.Enqueue(dog);

            Cat cat = new Cat() { Name = "Josie", Cuteness = 200m };
            shelter.Enqueue(cat);

            Dog dog1 = new Dog() { Name = "Leo", Loudness = 3m };
            shelter.Enqueue(dog);

            Cat cat1 = new Cat() { Name = "Razzle", Cuteness = 4000m };
            shelter.Enqueue(cat);

            Dog dog2 = new Dog() { Name = "Spike", Loudness = 55m };
            shelter.Enqueue(dog);

            Cat cat2 = new Cat() { Name = "Crazy", Cuteness = 6000m };
            shelter.Enqueue(cat);

            Cat emptyCat = new Cat();
            Dog emptyDog = new Dog();

            Animal animal = shelter.Dequeue("dog");

            Console.WriteLine(animal.Name);
        }
    }
}
