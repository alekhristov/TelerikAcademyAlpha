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

        public uint Age { get; protected set; }

        public string Name { get; protected set; }

        public Sex Sex { get; protected set; }

        protected string Sound { get; set; }

        public string MakesSound()
        {
            return this.Sound;
        }
    }
}
