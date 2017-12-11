using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_StudentsAndWorkers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var listOfStudents = new List<Student>();

            var student1 = new Student("Alek", "Hristov");
            student1.Grade = 5.88;
            var student2 = new Student("Sophia", "Kiryakova", 6.00);
            var student3 = new Student("Nikolay", "Nikolov", 5.90);
            var student4 = new Student("Strahil", "Zahariev", 3.45);
            var student5 = new Student("Zhivka", "Ignatova", 5.88);
            var student6 = new Student("Petko", "Petkov");
            student6.Grade = 6.00;
            var student7 = new Student("Dobri", "Delev", 6.00);
            var student8 = new Student("Stefan", "Zhekov", 5.10);
            var student9 = new Student("Alexander", "Markov", 6.00);
            var student10 = new Student("Kiril", "Kirilov", 4.92);

            listOfStudents.Add(student1);
            listOfStudents.Add(student2);
            listOfStudents.Add(student3);
            listOfStudents.Add(student4);
            listOfStudents.Add(student5);
            listOfStudents.Add(student6);
            listOfStudents.Add(student7);
            listOfStudents.Add(student8);
            listOfStudents.Add(student9);
            listOfStudents.Add(student10);

            //foreach (var student in listOfStudents.OrderBy(s => s.Grade).ThenBy(s => s.FullName()))
            //{
            //    Console.WriteLine($"Student name: {student.FullName()}");
            //    Console.WriteLine($"OOP Exam grade: {student.Grade:f2}");
            //    Console.WriteLine("--------------------------");
            //}

            var listOfWorkers = new List<Worker>();

            var worker1 = new Worker("Pesho", "Peshev", 300, 8);
            var worker2 = new Worker("Sasho", "Sashev", 400, 10);
            var worker3 = new Worker("Pesho", "Peshev", 250, 6);
            var worker4 = new Worker("Ceco", "Canov", 350, 8);
            var worker5 = new Worker("Gosho", "Goshev", 288, 12);
            var worker6 = new Worker("Marusiya", "Cvetanova", 1200, 12);
            var worker7 = new Worker("Koce", "Kocev", 200, 8);
            var worker8 = new Worker("Misho", "Mishev", 508, 9);
            var worker9 = new Worker("Kircho", "Kirchev", 600, 8);
            var worker10 = new Worker("Desa", "Poetesa");
            worker10.WeekSalary = 800;
            worker10.WorkHoursPerDay = 4;

            listOfWorkers.Add(worker1);
            listOfWorkers.Add(worker2);
            listOfWorkers.Add(worker3);
            listOfWorkers.Add(worker4);
            listOfWorkers.Add(worker5);
            listOfWorkers.Add(worker6);
            listOfWorkers.Add(worker7);
            listOfWorkers.Add(worker8);
            listOfWorkers.Add(worker9);
            listOfWorkers.Add(worker10);

            //foreach (var worker in listOfWorkers.OrderByDescending(w => w.MoneyPerHour()).ThenBy(w => w.FullName()))
            //{
            //    Console.WriteLine($"Worker name: {worker.FullName()}");
            //    Console.WriteLine($"{worker.FirstName} makes ${worker.MoneyPerHour():f2} per hour");
            //    Console.WriteLine();
            //}

            var mergedList = new List<Human>();
            mergedList.AddRange(listOfStudents);
            mergedList.AddRange(listOfWorkers);

            var counter = 1;

            foreach (var human in mergedList.OrderBy(h => h.FullName()))
            {
                Console.WriteLine($"{counter}. {human.FullName()}");
                counter++;
            }
        }
    }
}
