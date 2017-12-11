using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_AnimalHierarchy
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var listOfAnimals = new List<Animal>()
            {
            new Dog(6, "Sharo", Sex.Male),
            new Dog(14, "Reks", Sex.Male),
            new Dog(13, "Bari", Sex.Male),
            new Dog(6, "Ayra", Sex.Female),
            new Frog(2, "Jaborana", Sex.Female),
            new Frog(5, "Jabcho", Sex.Male),
            new Frog(2, "Giolcho", Sex.Male),
            new Cat(12, "Pisana", Sex.Female),
            new Cat(16, "Pijo", Sex.Male),
            new Cat(1, "Puhi", Sex.Male),
            new Kitten(9, "Jija"),
            new Kitten(6, "Machka"),
            new Kitten(4, "Pussy"),
            new Kitten(11, "Nastya"),
            new Tomcat(7, "Chochko"),
            new Tomcat(12, "Jijo"),
            new Tomcat(10, "Topcho"),
            new Tomcat(4, "Myro")
            };

            //var dog = new Dog(1, "Pesho", Sex.Male);
            //Console.WriteLine(dog.Age);
            //Console.WriteLine(dog.Name);
            //Console.WriteLine(dog.Sex);
            //Console.WriteLine(dog.MakesSound());

            CalculateAverageAge(listOfAnimals);
        }

        private static void CalculateAverageAge(List<Animal> listOfAnimals)
        {
            var dogAvg = listOfAnimals.Where(a => a.GetType() == typeof(Dog)).Average(a => a.Age);
            var frogAvg = listOfAnimals.Where(a => a.GetType() == typeof(Frog)).Average(a => a.Age);
            var catAvg = listOfAnimals.Where(a => a.GetType() == typeof(Cat)).Average(a => a.Age);
            var kittenAvg = listOfAnimals.Where(a => a.GetType() == typeof(Kitten)).Average(a => a.Age);
            var tomcatAvg = listOfAnimals.Where(a => a.GetType() == typeof(Tomcat)).Average(a => a.Age);

            Console.WriteLine($"Dogs average age: {dogAvg:f2} years");
            Console.WriteLine($"Cats average age: {catAvg:f2} years");
            Console.WriteLine($"Frogs average age: {frogAvg:f2} years");
            Console.WriteLine($"Kittens average age: {kittenAvg:f2} years");
            Console.WriteLine($"Tomcats average age: {tomcatAvg:f2} years");
        }
    }
}
