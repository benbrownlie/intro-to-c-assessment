using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Creature : Player
    {
        private int _loot;
        private float _creatureHealth;
        private float _creatureDamageMult;
        private string _creatureName;

        public Creature()
        {
            _creatureName = "Monster";
            _loot = 20;
            _creatureHealth = 50;
            _creatureDamageMult = 10;
        }
        public Creature(int lootVal) : base()
        {
            //Initializes Creature variables
            _creatureName = "Monster";
            _loot = 20;
            _creatureHealth = 50;
            _creatureDamageMult = 10;
        }

        public Creature(float healthVal, string nameVal, int damageVal, int lootVal) : base(healthVal, nameVal, damageVal)
        {
            //Constructor for Creature
            _creatureName = nameVal;
            _loot = lootVal;
            _creatureHealth = healthVal;
            _creatureDamageMult = damageVal;
        }

        public override float Attack(Player player)
        {
            float damageTaken = 0.0f;
            if (_creatureHealth >= 0)
            {
                float totalDamage = _damage + _creatureDamageMult * 0.0f;
                _creatureDamageMult -= _creatureDamageMult * 0.0f;
                damageTaken = player.TakeDamage(totalDamage);
                return damageTaken;
            }
            base.Attack(player);
            return damageTaken;
        }

        public override float TakeDamage(float damageVal)
        {
            return base.TakeDamage(damageVal);
        }

        public bool GetCreatureAlive()
        {
            return _creatureHealth > 0;
        }
    }
}
