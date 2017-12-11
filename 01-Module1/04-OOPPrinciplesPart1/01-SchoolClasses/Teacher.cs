using System.Collections.Generic;

namespace _01_SchoolClasses
{
    class Teacher : Person, IPerson
    {
        public Teacher(string firstName, string LastName) : base(firstName, LastName)
        {
            this.Disciplines = new List<Discipline>();
        }

        public List<Discipline> Disciplines { get; private set; }
    }
}