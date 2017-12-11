namespace _03_AnimalHierarchy
{
    class Animal : IAnimal, ISound
    {
        public Animal(int age, string name)
        {
            this.Age = age;
            this.Name = name;
        }

        public Animal(int age, string name, char sex)
        {
            this.Age = age;
            this.Name = name;
            this.Sex = sex;
        }

        public int Age { get; set; }

        public string Name { get; set; }

        public char Sex { get; set; }

        public string Sound { get; protected set; }

        public string MakesSound()
        {
            return this.Sound;
        }
    }
}
