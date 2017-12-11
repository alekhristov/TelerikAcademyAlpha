using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_StudentsAndWorkers
{
    class Student : Human
    {
        public Student(string firstName, string lastName) : base(firstName, lastName)
        {
        }

        public Student(string firstName, string lastName, double grade) : base(firstName, lastName)
        {
            this.Grade = grade;
        }

        public double Grade { get; set; }

        public override string FullName()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
