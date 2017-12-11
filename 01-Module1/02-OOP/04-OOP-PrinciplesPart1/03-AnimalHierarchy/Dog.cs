namespace _03_AnimalHierarchy
{
    class Dog : Animal
    {
        private const string sound = "Bau-Bau!";

        public Dog(uint age, string name, Sex sex) : base(age, name, sex)
        {
            this.Sound = sound;
        }
    }
}
