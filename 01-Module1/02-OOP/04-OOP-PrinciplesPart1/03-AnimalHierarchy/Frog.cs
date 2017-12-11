namespace _03_AnimalHierarchy
{
    class Frog : Animal
    {
        private const string sound = "Kvak-Kvak";

        public Frog(uint age, string name, Sex sex) : base(age, name, sex)
        {
            this.Sound = sound;
        }
    }
}
