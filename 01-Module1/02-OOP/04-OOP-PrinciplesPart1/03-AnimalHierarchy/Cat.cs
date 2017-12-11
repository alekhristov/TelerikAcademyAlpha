namespace _03_AnimalHierarchy
{
    class Cat : Animal
    {
        private const string sound = "Meoow-Meooow!";

        public Cat(uint age, string name, Sex sex) : base(age, name, sex)
        {
            this.Sound = sound;
        }
    }
}
