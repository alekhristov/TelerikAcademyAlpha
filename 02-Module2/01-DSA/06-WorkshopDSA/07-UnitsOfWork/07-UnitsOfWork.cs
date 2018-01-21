using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07_UnitsOfWork
{
    public class Unit : IComparable<Unit>
    {
        public Unit(string name, string type, int attack)
        {
            this.Name = name;
            this.Type = type;
            this.Attack = attack;
        }

        public string Name { get; private set; }

        public string Type { get; private set; }

        public int Attack { get; private set; }

        public int CompareTo(Unit other)
        {
            if (this.Attack.CompareTo(other.Attack) == 0)
            {
                return this.Name.CompareTo(other.Name);
            }
            return -this.Attack.CompareTo(other.Attack);
        }

        public override string ToString()
        {
            return $"{this.Name}[{this.Type}]({this.Attack})";
        }
    }

    public class Program
    {
        const string END_COMMAND = "end";
        private static SortedSet<Unit> unitsByAttack = new SortedSet<Unit>();
        private static Dictionary<string, SortedSet<Unit>> unitsByType = new Dictionary<string, SortedSet<Unit>>();
        private static Dictionary<string, Unit> unitsByName = new Dictionary<string, Unit>();
        private static StringBuilder sb = new StringBuilder();


        static void Main(string[] args)
        {
            while (true)
            {
                var input = Console.ReadLine().Split().ToArray();
                var command = input[0];

                if (command == END_COMMAND)
                {
                    Console.Write(sb);
                    break;
                }

                switch (command)
                {
                    case "add":
                        var isAdded = Add(input[1], input[2], int.Parse(input[3]));

                        if (isAdded)
                        {
                            sb.AppendLine($"SUCCESS: {input[1]} added!");
                        }
                        else
                        {
                            sb.AppendLine($"FAIL: {input[1]} already exists!");
                        }
                        break;

                    case "remove":
                        var isRemoved = Remove(input[1]);

                        if (isRemoved)
                        {
                            sb.AppendLine($"SUCCESS: {input[1]} removed!");

                        }
                        else
                        {
                            sb.AppendLine($"FAIL: {input[1]} could not be found!");
                        }
                        break;

                    case "find":
                        var found = Find(input[1]);
                        sb.AppendLine($"RESULT: {string.Join(", ", found)}");
                        break;

                    case "power":
                        var mostPowerfulUnits = Power(int.Parse(input[1]));
                        sb.AppendLine($"RESULT: {string.Join(", ", mostPowerfulUnits)}");
                        break;

                    default: throw new InvalidOperationException("Invalid command!");
                }
            }
        }

        private static IEnumerable<Unit> Power(int numberOfUnits)
        {
            return unitsByAttack.Take(numberOfUnits);
        }

        private static IEnumerable<Unit> Find(string type)
        {
            if (unitsByType.ContainsKey(type))
            {
                return unitsByType[type].Take(10);
            }
            else
            {
                return Enumerable.Empty<Unit>();
            }
        }

        private static bool Remove(string name)
        {
            if (unitsByName.ContainsKey(name))
            {
                var unitByName = unitsByName[name];
                unitsByName.Remove(name);

                var unitsBySameType = unitsByType[unitByName.Type];
                unitsBySameType.Remove(unitByName);
                unitsByAttack.Remove(unitByName);

                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool Add(string name, string type, int attack)
        {
            var unit = new Unit(name, type, attack);

            if (unitsByName.ContainsKey(unit.Name))
            {
                return false;
            }

            unitsByName[name] = unit;

            if (!unitsByType.ContainsKey(unit.Type))
            {
                unitsByType[unit.Type] = new SortedSet<Unit>();
            }

            unitsByType[unit.Type].Add(unit);
            unitsByAttack.Add(unit);

            return true;
        }
    }
}
