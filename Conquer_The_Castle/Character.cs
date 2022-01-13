using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conquer_The_Castle
{
    class Character
    {
        protected int healthy = 100;
        protected int attackDamage;
        protected int attackRange = 1;
        protected bool alive = true;

        public int Healthy { get { return healthy; } }
        public int AttackRange { get { return attackRange; } }

        public virtual int Attack()
        {
            Random rand = new Random();
            attackDamage = rand.Next(1, 50);
            return attackDamage;
        }

        public void GetDamage(int damage)
        {
            healthy -= damage;
            if (healthy <= 0)
                alive = false;
        }

        public bool IsAlive()
        {
            return alive;
        }
    }

    class Archer : Character
    {
        public Archer()
        {
            attackRange = 3;
        }

        public override int Attack()
        {
            Random rand = new Random();
            attackDamage = rand.Next(1, 30);
            return attackDamage;
        }
    }

    class Melee : Character
    {

    }

    class Player : Character
    {
        public override int Attack()
        {
            Random rand = new Random();
            attackDamage = rand.Next(1, 100);
            return attackDamage;
        }

        public void GetHeal(int heal)
        {
            healthy += heal;
          
            if (healthy > 100)
                healthy = 100;
        }
    }

    class Heal : Character
    {
        private int heal;

        public Heal()
        {
            Random rand = new Random();
            heal = rand.Next(1, 100);
        }

        public int Healing()
        {
            return heal;
        }
    }
}
