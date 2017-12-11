namespace _02_StudentsAndWorkers
{
    abstract class Human
    {
        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
