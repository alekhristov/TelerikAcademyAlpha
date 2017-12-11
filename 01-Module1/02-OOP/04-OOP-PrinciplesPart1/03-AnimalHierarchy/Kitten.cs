namespace _03_AnimalHierarchy
{
    class Kitten : Cat
    {
        private const string sound = "Kitty-Kit!";

        public Kitten(uint age, string name) : base(age, name, Sex.Female)
        {
            this.Sound = sound;
        }
    }
}
