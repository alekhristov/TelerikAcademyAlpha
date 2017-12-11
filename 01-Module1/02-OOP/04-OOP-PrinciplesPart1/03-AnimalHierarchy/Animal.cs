namespace _03_AnimalHierarchy
{
    abstract class Animal : ISound
    {
        public Animal(uint age, string name, Sex sex)
        {
            this.Age = age;
            this.Name = name;
            this.Sex = sex;
        }

        public uint Age { get; private set; }

        public string Name { get; private set; }

        public Sex Sex { get; private set; }

        protected string Sound { get; set; }

        public string MakesSound()
        {
            return this.Sound;
        }
    }
}
