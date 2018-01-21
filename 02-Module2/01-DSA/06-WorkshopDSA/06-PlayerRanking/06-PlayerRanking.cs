using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

namespace _06_PlayerRanking
{
    class Player : IComparable<Player>
    {
        public Player(string name, string type, int age, int position)
        {
            this.Name = name;
            this.Type = type;
            this.Age = age;
            this.Position = position;
        }

        public string Name { get; private set; }

        public string Type { get; private set; }

        public int Age { get; private set; }

        public int Position { get; private set; }

        public int CompareTo(Player other)
        {
            if (this.Name.CompareTo(other.Name) == 0)
            {
                return -this.Age.CompareTo(other.Age);
            }
            return this.Name.CompareTo(other.Name);
        }

        public override string ToString()
        {
            return $"{this.Name}({this.Age})";
        }
    }

    class Program
    {
        const string END_COMMAND = "end";
        private static BigList<Player> players = new BigList<Player>();
        private static Dictionary<string, OrderedSet<Player>> playersByType = new Dictionary<string, OrderedSet<Player>>();
        private static StringBuilder result = new StringBuilder();

        static void Main(string[] args)
        {
            while (true)
            {
                var input = Console.ReadLine().Split().ToArray();
                var command = input[0];

                if (command == END_COMMAND)
                {
                    break;
                }

                switch (command)
                {
                    case "add":
                        var player = new Player(input[1], input[2], int.Parse(input[3]), int.Parse(input[4]));
                        AddPlayer(player);
                        break;

                    case "find":
                        // calling this method is slower, it gets 10/11 AC
                       // var foundPlayers = FindPlayersByType(input[1]);
                        var type = input[1];
                        if (playersByType.ContainsKey(type) && playersByType[type].Count > 0)
                        {
                            result.Append($"Type {type}: ");
                            for (int i = 0; i < playersByType[type].Count; i++)
                            {
                                if (i == playersByType[type].Count - 1)
                                {
                                    result.AppendLine($"{playersByType[type][i]}");
                                    break;
                                }

                                result.Append($"{playersByType[type][i]}; ");
                            }
                        }
                        else
                        {
                            result.AppendLine($"Type {type}: ");
                        }
                        // FindPlayersByType(input[1]) solution
                        //result.AppendLine($"Type {input[1]}: {string.Join("; ", foundPlayers)}");
                        break;

                    case "ranklist":
                        var startFrom = int.Parse(input[1]);
                        Ranklist(startFrom, int.Parse(input[2]));
                        break;

                    default: throw new InvalidOperationException("Invalid command!");
                }

            }
            Console.Write(result);
        }

        private static void Ranklist(int startValue, int end)
        {
            int length = end - startValue + 1;
            var range = players.Range(startValue - 1, length);

            for (int i = 0; i < range.Count; i++)
            {
                if (i == range.Count - 1)
                {
                    result.AppendLine($"{startValue + i}. {range[i]}");
                    break;
                }
                result.Append($"{startValue + i}. {range[i]}; ");
            }
        }

        // slower than iteration
        //private static IEnumerable<Player> FindPlayersByType(string type)
        //{
        //    if (!playersByType.ContainsKey(type) || playersByType[type].Count == 0)
        //    {
        //        return Enumerable.Empty<Player>();
        //    }
        //    return playersByType[type];
        //}

        private static void AddPlayer(Player player)
        {
            players.Insert(player.Position - 1, player);

            if (!playersByType.ContainsKey(player.Type))
            {
                playersByType[player.Type] = new OrderedSet<Player>();
            }
            if (playersByType[player.Type].Count >= 5)
            {
                var lastPlayer = playersByType[player.Type][4];

                if (lastPlayer.CompareTo(player) > 0)
                {
                    playersByType[player.Type].RemoveLast();
                    playersByType[player.Type].Add(player);
                }
            }
            else
            {
                playersByType[player.Type].Add(player);
            }
            result.AppendLine($"Added player {player.Name} to position {player.Position}");
        }
    }
}