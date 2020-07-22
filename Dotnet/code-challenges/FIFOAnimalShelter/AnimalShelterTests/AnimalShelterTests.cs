using System;
using Xunit;
using FIFOAnimalShelter.Classes;
using StacksAndQueuesLibrary;

namespace AnimalShelterTests
{
    public class EnqueuTests
    {
        [Fact]
        public void CanEnqueueANewAnimal()
        {
            // Arrange
            AnimalShelter shelter = new AnimalShelter();
            Dog dog = new Dog() { Name = "Spot", Loudness = 10m };

            // Act
            shelter.Enqueue(dog);

            string expected = "Spot";
            string returnFromMethod = shelter.Shelter.Front.Value.Name;
            // Assert
            Assert.Equal(expected, returnFromMethod);
        }

        [Fact]
        public void CanEnqueueManyNewAnimals()
        {
            // Arrange
            AnimalShelter shelter = new AnimalShelter();
            Dog dog = new Dog() { Name = "Spot", Loudness = 10m };
            Dog dog1 = new Dog() { Name = "Leo", Loudness = 3m };
            Dog dog2 = new Dog() { Name = "Spike", Loudness = 55m };
            Cat cat = new Cat() { Name = "Josie", Cuteness = 1000m };
            Cat cat1 = new Cat() { Name = "Razzle", Cuteness = 4000m };
            Cat cat2 = new Cat() { Name = "Crazy", Cuteness = 6000m };

            // Act
            shelter.Enqueue(dog);
            shelter.Enqueue(cat);
            shelter.Enqueue(dog1);
            shelter.Enqueue(cat1);
            shelter.Enqueue(dog2);
            shelter.Enqueue(cat2);

            string expected = "Spot";
            string returnFromMethod = shelter.Shelter.Front.Value.Name;
            // Assert
            Assert.Equal(expected, returnFromMethod);
        }
    }

    public class DequeueTests
    {
        [Fact]
        public void CanDequeueAnItemFromTheShelter()
        {
            // Arrange
            AnimalShelter shelter = new AnimalShelter();
            Dog[] dogs = new Dog[4];
            //Dog testDog = new Dog();

            int counter = 1;
            foreach (Dog item in dogs)
            {
                shelter.Enqueue(new Dog() { Name = $"{counter++}" });
            }

            // Act
            Animal testNode = shelter.Dequeue("dog");
            string returnFromMethod = testNode.Name;
            string expected = "1";
            // Assert

            Assert.Equal(expected, returnFromMethod);
        }
        [Fact]
        public void CanDequeueTheSpecifiedTypeFromTheShelter()
        {
            // Arrange
            AnimalShelter shelter = new AnimalShelter();

            for (int i = 0; i < 8; i++)
            {
                if (i % 2 == 0)
                    shelter.Enqueue(new Cat());
                else
                    shelter.Enqueue(new Dog());
            }

            // Act
            Animal testNode = shelter.Dequeue("dog");
            var expected = new Dog();
            // Assert

            Assert.Equal(expected.GetType(), testNode.GetType());
        }

        [Fact]
        public void ReturnNullWhenTheTypeOfAnimalIsNotInTheShelter()
        {
            // Arrange
            AnimalShelter shelter = new AnimalShelter();
            Dog[] dogs = new Dog[4];
            Cat testCat = new Cat();

            int counter = 1;
            foreach (Dog item in dogs)
            {
                shelter.Enqueue(new Dog() { Name = $"{counter++}" });
            }

            Assert.Null(shelter.Dequeue("Cat"));
        }
    }
}
