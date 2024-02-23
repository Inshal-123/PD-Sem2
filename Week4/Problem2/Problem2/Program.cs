using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player alice = new Player("Alice", 110, 50, 10);
            Player bob = new Player("Bob", 100, 60, 20);
            Stats fireball = new Stats("fireball", 23, 1.2, 5, 15, "a firey magical attack");
            alice.learnSkill(fireball);
            double damage = alice.attack(bob);
            Console.WriteLine(alice.lowEnergy());
            if (alice.lowEnergy() == "")
            {
                bob.damagePlayer(damage);
                alice.healPlayer();
                Console.WriteLine(alice.attackMessage(bob, damage));
            }

            Stats superbeam = new Stats("superbeam", 200, 50, 50, 75, "an overpowered attack, pls nerf");
            bob.learnSkill(superbeam);
            damage  =bob.attack(alice);
            Console.WriteLine(bob.lowEnergy());
            if (bob.lowEnergy() == "")
            {
                alice.damagePlayer(damage);
                bob.healPlayer();
                Console.WriteLine(bob.attackMessage(alice, damage));
            }
            Console.Read();
        }
    }
}
