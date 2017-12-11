using System;
using System.Linq;

namespace _01_SchoolClasses
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var schoolClass = new SchoolClass('A');
            schoolClass.Students.Add(new Student("Alek", "Hristov", 1));
            schoolClass.Students.Add(new Student("Sophia", "Kiryakova", 26));

            var teacher1 = new Teacher("Steven", "Tsvetkov");
            teacher1.Disciplines.Add(new Discipline("C# Advanced", 5, 5));
            teacher1.Disciplines.Add(new Discipline("DSA", 8, 12));
            schoolClass.Teachers.Add(teacher1);

            var teacher2 = new Teacher("Matrin", "Veshev");
            teacher2.Disciplines.Add(new Discipline("C# OOP", 6, 9));
            teacher2.Disciplines.Add(new Discipline("Databases", 10, 10));
            schoolClass.Teachers.Add(teacher2);

            foreach (var student in schoolClass.Students.OrderBy(s => s.ClassNumber))
            {
                Console.WriteLine($"Class number: {student.ClassNumber}");
                Console.WriteLine($"Student name: {student.FullName()}");
                Console.WriteLine("-----------------------------");
            }

            foreach (var teacher in schoolClass.Teachers.OrderBy(t => t.FirstName))
            {
                Console.WriteLine($"Teacher name: {teacher.FullName()}");
                foreach (var discipline in teacher.Disciplines)
                {
                    Console.WriteLine($"Discipline name: {discipline.DisciplineName}");
                    Console.WriteLine($"Number of lectures in discipline: {discipline.NumberOfLectures}");
                    Console.WriteLine($"Number of exercises in discipline: {discipline.NumberOfExercises}");
                    Console.WriteLine();
                }
                Console.WriteLine("-----------------------------");
            }
        }
    }
}
