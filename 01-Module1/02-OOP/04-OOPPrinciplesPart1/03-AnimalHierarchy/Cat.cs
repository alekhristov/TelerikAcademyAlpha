namespace _03_AnimalHierarchy
{
    class Cat : Animal
    {
        public Cat(int age, string name, char sex) : base(age, name, sex)
        {
            this.Sound = "Meoow-Meooow!";
        }

        public Cat(int age, string name) : base(age, name)
        {
            this.Sound = "Meoow-Meooow!";
        }
    }
}
