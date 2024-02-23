using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Problem3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string option;
            Player newPlayer = new Player();
            Stats newSkill = new Stats();
            List<Player> players = new List<Player>();
            List<Stats> skills = new List<Stats>();
            while (true)
            {
                Console.Clear();
                option = menu();
                Console.Clear();
                if (option == "1")
                {
                    newPlayer = takePlayerInput();
                    addPlayer(players, newPlayer);
                }
                else if (option == "2")
                {
                    newSkill = getSkillsInput();
                    addSkill(skills, newSkill);
                }
                else if (option == "3")
                {
                    displayPlayers(players);
                    Console.ReadKey();
                }
                else if (option == "4")
                {
                    Console.Write("Enter player name: ");
                    string playerName = Console.ReadLine();
                    Console.Write("Enter skill name: ");
                    string skillName = Console.ReadLine();
                    learnSkill(players, skills, playerName, skillName);
                }
                else if (option == "5")
                {
                    Console.Write("Enter attacker name: ");
                    string attackerName = Console.ReadLine();
                    Console.Write("Enter defender name: ");
                    string defenderName = Console.ReadLine();
                    attack(players, attackerName ,defenderName );

                }
                else if (option == "6")
                {
                    Environment.Exit(0);
                }
                else
                {
                    continue;
                }
            }
        }

        static string menu()
        {
            Console.WriteLine("1. Add Player\n2. Add Skills\n3. Display Player\n4. Learn a skill\n5. Attack\n6. Exit");
            Console.Write("Enter any option: ");
            string input = Console.ReadLine();
            return input;
        }

        static Player takePlayerInput()
        {
            string Name;
            double HP, Armor;
            int MaxHealth, Energy, MaxEnergy;

            Console.Write("Enter player name: ");
            Name = Console.ReadLine();

            Console.Write("Enter player health: ");
            HP = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter player max health: ");
            MaxHealth = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter player energy: ");
            Energy = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter player max energy: ");
            MaxEnergy = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter player armor: ");
            Armor = Convert.ToDouble(Console.ReadLine());

            Player player = new Player(Name, HP, Energy, Armor, MaxHealth, MaxEnergy);
            return player;
        }

        static void addPlayer(List<Player> players, Player player)
        {
            players.Add(player);
        }

        static Stats getSkillsInput()
        {
            string Name;
            double Damage, Penetration;
            int Heal, Cost;
            string Description;

            Console.Write("Enter skill name: ");
            Name = Console.ReadLine();

            Console.Write("Enter skill damage: ");
            Damage = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter skill penetration: ");
            Penetration = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter skill heal: ");
            Heal = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter skill cost: ");
            Cost = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter skill description: ");
            Description = Console.ReadLine();

            Stats skill = new Stats(Name, Damage, Penetration, Heal, Cost, Description);
            return skill;
        }

        static void addSkill(List<Stats> skills, Stats skill)
        {
            skills.Add(skill);
        }

        static void displayPlayers(List<Player> players)
        {
            foreach(Player player in players)
            {
                Console.WriteLine("Name: " + player.Name);
                Console.WriteLine("Health: " + player.HP);
                Console.WriteLine("Max Health: " + player.MaxHealth);
                Console.WriteLine("Energy: " + player.Energy);
                Console.WriteLine("Max Energy: " + player.MaxEnergy);
                Console.WriteLine("Armor: " + player.Armor);
            }
        }

        static void learnSkill(List<Player> players, List<Stats> skills, string playerName, string skillName)
        {
            Player player = players.Find(x => x.Name == playerName);
            Stats skill = skills.Find(x => x.SkillName == skillName);
            player.learnSkill(skill);
        }

        static void attack(List<Player> players, string attackerName, string defenderName)
        {
            Player attacker = players.Find(x => x.Name == attackerName);
            Player defender = players.Find(x => x.Name == defenderName);
            double damage = attacker.attack(defender);
            if (attacker.lowEnergy() == "" && defender.HP<=defender.MaxHealth)
            {
                defender.damagePlayer(damage);
                attacker.healPlayer();
                Console.WriteLine(attacker.attackMessage(defender, damage));
                Console.ReadKey();
            }
        }


    }
}
