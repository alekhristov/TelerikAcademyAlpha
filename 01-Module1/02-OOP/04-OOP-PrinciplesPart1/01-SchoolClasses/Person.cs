namespace _01_SchoolClasses
{
    abstract class Person : IPerson
    {
        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string FullName()
        {
            var fullName = $"{this.FirstName} {this.LastName}";
            return fullName;
        }
    }
}
