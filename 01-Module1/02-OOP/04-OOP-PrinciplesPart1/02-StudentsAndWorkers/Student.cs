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
    }
}
