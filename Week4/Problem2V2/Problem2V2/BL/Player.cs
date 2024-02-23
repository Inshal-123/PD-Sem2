using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3
{
    internal class Player
    {
        public Player()
        {

        }
        public Player(string name, double health, int energy, double armor, int maxHealth, int maxEnergy)
        {
            this.Name = name;
            this.HP = health;
            this.MaxHealth = maxHealth;
            this.Energy = energy;
            this.MaxEnergy = maxEnergy;
            this.Armor = armor;
            this.GameOver = false;
        }

        public string Name;
        public double HP;
        public int MaxHealth;
        public int Energy;
        public int MaxEnergy;
        public double Armor;
        public Stats SkillStatistics;
        public bool GameOver;


        public void damagePlayer(double damage)
        {
            if (this.HP > 0 && this.HP <= this.MaxHealth)
                this.HP = this.HP - damage;
            else
                this.GameOver = true;
        }

        public void healPlayer()
        {
            if (this.SkillStatistics.Heal + this.HP <= this.MaxHealth)
                this.HP = this.HP + this.SkillStatistics.Heal;
        }

        public void updateEnergy()
        {
            if (this.Energy >= 0 && this.Energy <= this.MaxEnergy)
                this.Energy = this.Energy - this.SkillStatistics.Cost;
        }

        public void updateName(string name)
        {
            this.Name = name;
        }

        public void learnSkill(Stats Skill)
        {
            this.SkillStatistics = Skill;
        }

        public double attack(Player player)
        {
            player.Armor = player.Armor - this.SkillStatistics.Penetration;
            return player.Armor;
        }

        public string lowEnergy()
        {
            if (SkillStatistics.Cost > Energy)
            {
                return Name + " attempted to use " + SkillStatistics.SkillName + ", but didn't have enough Energy!";
            }
            else
            {
                return "";
            }
        }

        public string damage()
        {
            SkillStatistics.Damage = SkillStatistics.Penetration * ((MaxHealth - Armor) / MaxHealth);
            return Name + $" did {SkillStatistics.Damage} damage";
        }

        public string attackMessage(Player opponet, double damage)
        {
            string value = "";
            value = Name + " used skill " + SkillStatistics.SkillName + ", " + SkillStatistics.Description + ", against " + opponet.Name + " doing " + damage.ToString() + " Damage!";
            if (SkillStatistics.Heal > 0)
            {
                value += Name + " healed for " + SkillStatistics.Heal + " Health! ";
            }
            if (opponet.HP > 100)
            {
                value += opponet.Name + "died!";
            }
            else
            {
                value += opponet.Name + " at " + opponet.HP + "%Health!";
            }
            return value;
        }
    }
}

