using System;
using System.Collections.Generic;

namespace _03_AnimalHierarchy
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var listOfDogs = new List<Animal>();
            var dog1 = new Dog(6, "Sharo", 'M');
            var dog2 = new Dog(14, "Reks", 'M');
            var dog3 = new Dog(13, "Bari", 'M');
            var dog4 = new Dog(6, "Ayra", 'F');
            listOfDogs.Add(dog1);
            listOfDogs.Add(dog2);
            listOfDogs.Add(dog3);
            listOfDogs.Add(dog4);

            var listOfFrogs = new List<Animal>();
            var frog1 = new Frog(2, "Jaborana", 'F');
            var frog2 = new Frog(5, "Jabcho", 'M');
            var frog3 = new Frog(2, "Giolcho", 'M');
            listOfFrogs.Add(frog1);
            listOfFrogs.Add(frog2);
            listOfFrogs.Add(frog3);

            var listOfCats = new List<Animal>();
            var cat1 = new Cat(12, "Pisana", 'F');
            var cat2 = new Cat(16, "Pijo", 'M');
            var cat3 = new Cat(1, "Puhi", 'M');
            listOfCats.Add(cat1);
            listOfCats.Add(cat2);
            listOfCats.Add(cat3);

            var listOfKitties = new List<Animal>();
            var kitty1 = new Kitten(9, "Jija");
            var kitty2 = new Kitten(6, "Machka");
            var kitty3 = new Kitten(4, "Pussy");
            var kitty4 = new Kitten(11, "Nastya");
            listOfKitties.Add(kitty1);
            listOfKitties.Add(kitty2);
            listOfKitties.Add(kitty3);
            listOfKitties.Add(kitty4);

            var listOfTomcats = new List<Animal>();
            var tomcat1 = new Tomcat(7, "Chochko");
            var tomcat2 = new Tomcat(12, "Jijo");
            var tomcat3 = new Tomcat(10, "Topcho");
            var tomcat4 = new Tomcat(4, "Myro");
            listOfTomcats.Add(tomcat1);
            listOfTomcats.Add(tomcat2);
            listOfTomcats.Add(tomcat3);
            listOfTomcats.Add(tomcat4);

            CalculateAverageAge(listOfDogs);
            CalculateAverageAge(listOfFrogs);
            CalculateAverageAge(listOfCats);
            CalculateAverageAge(listOfKitties);
            CalculateAverageAge(listOfTomcats);
        }

        private static void CalculateAverageAge(List<Animal> listOfAnimals)
        {
            var totalYears = 0.0;
            var currentAnimal = "";

            foreach (var animal in listOfAnimals)
            {
                totalYears += animal.Age;

                if (animal is Dog) currentAnimal = "Dog";
                else if (animal is Cat) currentAnimal = "Cat";
                else if (animal is Frog) currentAnimal = "Frog";
                else if (animal is Kitten) currentAnimal = "Kitten";
                else if (animal is Tomcat) currentAnimal = "Tomcat";
            }

            Console.WriteLine($"{currentAnimal}s average age: {(totalYears / listOfAnimals.Count):f2} years");
        }
    }
}
