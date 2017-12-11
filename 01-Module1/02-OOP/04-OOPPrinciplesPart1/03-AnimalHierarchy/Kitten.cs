namespace _03_AnimalHierarchy
{
    class Kitten : Cat
    {
        public Kitten(int age, string name) : base(age, name)
        {
            this.Sex = 'F';
        }
    }
}
