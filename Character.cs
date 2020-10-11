using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{//Class used to define what variables a character has
    class Character
    {//Default variables for a character
        private float _health;
        private string _name;
        protected int _damage;

        public Character()
        {//Default values for variables
            _health = 100;
            _name = "Default";
            _damage = 10;
        }

        public Character(float healthVal, string nameVal, int damageVal)
        {//Default constructor for a character
            _health = healthVal;
            _name = nameVal;
            _damage = damageVal;
        }

        public virtual float Attack(Character enemy)
        {//Runs the TakeDamage function on the "enemy"
            return enemy.TakeDamage(_damage);
        }

        public virtual float TakeDamage(float damageVal)
        {//Subtracts the attacker's damage value from the reciever's health
            _health -= damageVal;
            //If the reciever's health is less than or equal to 0. Set their health to 0.
            if (_health <= 0)
            {
                _health = 0;
            }
            //Return the value of damage
            return damageVal;

        }

        public string GetName()
        {//Returns the name set by the player
            return _name;
        }

        public bool GetAlive()
        {//Returns whether or not the character's health is greater than 0
            return _health > 0;
        }

        public void PrintStats()
        {//Prints the character's stats to the screen
            Console.WriteLine("Name: " + _name);
            Console.WriteLine("Health: " + _health);
            Console.WriteLine("Damage: " + _damage);
        }
    }

}
