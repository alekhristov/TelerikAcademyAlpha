namespace _03_AnimalHierarchy
{
    class Dog : Animal
    {
        public Dog(int age, string name, char sex) : base(age, name, sex)
        {
            this.Sound = "Bau-Bau!";
        }
    }
}
