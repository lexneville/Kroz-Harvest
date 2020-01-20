using System;
using System.Collections.Generic;
using System.Text;

namespace Kroz.Classes
{
    class Enemy
    {
        private string name { get; set; }
        private int health { get; set; }
        private int mana { get; set; }

        public Enemy(string name, int health, int mana)
        {
            this.name = name;
            this.health = health;
            this.mana = mana;
        }
        public string GetName()
        {
            return this.name;
        }
        public int GetHealth(Enemy enemy)
        {
            return health;
        }

        public void TakeHealth(Enemy enemy, int healthChange)
        {

            health -= healthChange;
        }
        public void Heal(Enemy enemy, int healthChange)
        {
            health += healthChange;
        }
    }
}
