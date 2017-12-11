using System.Collections.Generic;

namespace _01_SchoolClasses
{
    class SchoolClass : ISchoolClass
    {
        public SchoolClass(char identifier)
        {
            this.Identifier = identifier;
            this.Students = new List<Student>();
            this.Teachers = new List<Teacher>();
        }

        public char Identifier { get; private set; }

        public List<Student> Students { get; private set; }

        public List<Teacher> Teachers { get; private set; }
    }
}
