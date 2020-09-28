using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace HelloWorld
{
    class Player
    {
        private float _health;
        private string _name;
        private int _damage;
        private int _gold;
        private Item[] _inventory;

        public Player()
        {
            //Initializes Player variables
            _health = 100;
            _name = "Player";
            _damage = 10;
            _inventory = new Item[3];
            _gold = 100;
        }

        public Player(float healthVal, string nameVal, int damageVal, int goldVal, int inventorySize)
        {
            //Constructor for player
            _health = healthVal;
            _name = nameVal;
            _damage = damageVal;
            _gold = goldVal;
            _inventory = new Item[inventorySize];
        }

        //Getter Functions
        //Inventory Getter
        public Item[] GetInventory()
        {
            return _inventory;
        }

        //Name Getter
        public string GetName()
        {
            //Prints the player's name to the console
            return _name;
        }

        //Alive status Getter
        public bool GetPlayerAlive()
        {
            return _health > 0;
        }

        //Gold Getter
        public int GetGold()
        {
            return _gold;
        }

        public void AcquireItem(Item item, int index)
        {
            _inventory[index] = item;
        }

        public bool Buy(Item stock, int inventoryIndex)
        {
            if(_gold >= stock.cost)
            {
                _gold -= stock.cost;
                _inventory[inventoryIndex] = stock;
                return true;
            }
            return false;
        }

        //Prints player stats to the console
        public void PrintStats()
        {
            Console.WriteLine("Name: " + _name);
            Console.WriteLine("Health: " + _health);
            Console.WriteLine("Damage: " + _damage);
        }
    }
}
