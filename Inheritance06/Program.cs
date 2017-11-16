using System;
using System.Collections.Generic;

namespace Inheritance06
{
    class Program
    {
        static void Main(string[] args)
        {
            var player = new Player() { Name = "Bob", Strength = 20 };
            var warrior = new Warrior() { Name = "Baltek", Strength = 100, Bonus = 10 };
            var wizard = new Wizard() { Name = "Pentagorn", Strength = 50, Energy = 50 };

            var players = new List<Player>();
            players.Add(player);
            players.Add(warrior);
            players.Add(wizard);

            DoBattle(players);

            Console.ReadLine();
        }

        static void DoBattle(List<Player> players)
        {
            foreach (var player in players)
            {
                player.Attack();
                Console.WriteLine("");
            }
        }
    }

    class Player
    {
        public string Name { get; set; }
        public int Strength { get; set; }

        Random random = new Random();
        public virtual void Attack()
        {
            int damage = random.Next(1, this.Strength);
            Console.WriteLine($"{this.Name} attacked for {damage}.");
        }

    }

    class Warrior : Player
    {
        public int Bonus { get; set; }

        Random random = new Random();
        public override void Attack()
        {
            int damage = random.Next(1, this.Strength) + this.Bonus;
            Console.WriteLine($"{this.Name} charges for {damage} damage (includes +{this.Bonus} bonus)");
        }
    }

    class Wizard : Player
    {
        public int Energy { get; set; }

        Random random = new Random();
        public override void Attack()
        {
            int damage = random.Next(1, this.Strength);
            int energy = random.Next(1, this.Energy);

            Console.WriteLine($"{this.Name} attacked for {damage} damage.");
            Console.WriteLine($"\t(Wizard {this.Name} depleted {energy} energy.)");
        }
    }
}
