namespace _03_AnimalHierarchy
{
    class Tomcat : Cat
    {
        private const string sound = "Tommy-tom!";

        public Tomcat(uint age, string name) : base(age, name, Sex.Male)
        {
            this.Sound = sound;
        }
    }
}
