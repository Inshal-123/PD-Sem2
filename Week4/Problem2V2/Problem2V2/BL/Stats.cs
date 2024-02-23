using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3
{
    internal class Stats
    {
        public Stats()
        {

        }
        public Stats(string name, double damage, double penetration, int heal, int cost, string description)
        {
            this.SkillName = name;
            this.Damage = damage;
            this.Penetration = penetration;
            this.Heal = heal;
            this.Cost = cost;
            this.Description = description;
        }

        public double Penetration;
        public string SkillName;
        public double Damage;
        public string Description;
        public int Cost;
        public int Heal;
    }
}
