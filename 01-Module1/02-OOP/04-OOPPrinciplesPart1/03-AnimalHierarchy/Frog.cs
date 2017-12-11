namespace _03_AnimalHierarchy
{
    class Frog : Animal
    {
        public Frog(int age, string name, char sex) : base(age, name, sex)
        {
            this.Sound = "Kvak-Kvak";
        }
    }
}
