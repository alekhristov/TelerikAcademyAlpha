namespace _01_SchoolClasses
{
    class Student : Person, IPerson
    {
        public Student(string firstName, string LastName, int classNumber) : base(firstName, LastName)
        {
            this.ClassNumber = classNumber;
        }

        public int ClassNumber { get; private set; }
    }
}