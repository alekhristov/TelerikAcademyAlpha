namespace _01_SchoolClasses
{
    interface IPerson
    {
        string FirstName { get; }

        string LastName { get; }

        string FullName();
    }
}
