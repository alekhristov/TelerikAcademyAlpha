namespace _03_AnimalHierarchy
{
    public interface IAnimal
    {
        int Age { get; set; }

        string Name { get; set; }

        char Sex { get; set; }

        string Sound { get; }
    }
}
