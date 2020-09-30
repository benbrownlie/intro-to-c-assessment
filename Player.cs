using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Text;

namespace HelloWorld
{
    class Player
    {
        private float _health;
        private string _name;
        protected int _damage;
        private int _gold;
        private Item[] _inventory;
        private Item _currentItem;

        public Player()
        {
            //Initializes Player variables
            _health = 100;
            _name = "Player";
            _damage = 10;
            _inventory = new Item[3];
            _gold = 100;
        }

        public Player (float healthVal, string nameVal, int damageVal)
        {
            _health = healthVal;
            _name = nameVal;
            _damage = damageVal;
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

        //Save and Load Functions

        public virtual void Save(StreamWriter writer)
        {
            //Saves all stats by writing to a text file
            writer.WriteLine(_health);
            writer.WriteLine(_name);
            writer.WriteLine(_damage);
            writer.WriteLine(_gold);
            writer.WriteLine(_inventory);
            writer.WriteLine(_currentItem);
        }

        public virtual bool Load(StreamReader reader)
        {
            string name = reader.ReadLine();
            float health = 0;
            int damage = 0;
            int gold = 0;
            if (float.TryParse(reader.ReadLine(), out health) == false)
            {
                return false;
            }
            if (int.TryParse(reader.ReadLine(), out damage) == false)
            {
                return false;
            }
            if (int.TryParse(reader.ReadLine(), out gold) == false)
            {
                return false;
            }
            _name = name;
            _health = health;
            _damage = damage;
            _gold = gold;
            return true;
        }

        //Combat functions
        public virtual float Attack(Player enemy)
        {
            return enemy.TakeDamage(_damage);
        }

        public virtual float TakeDamage(float damageVal)
        {
            _health -= damageVal;
            if (_health <= 0)
            {
                _health = 0;
            }
            return damageVal;
        }

        public void SwitchItem(Player player)
        {
            Item[] inventory = player.GetInventory();
            char input = ' ';
            for (int i = 0; i < inventory.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + inventory[i].name + "\nBoost: " + inventory[i].boost);
            }
            Console.WriteLine("> ");
            input = Console.ReadKey().KeyChar;

            switch(input)
            {
                case '1':
                    {
                        player.EquipItem(0);
                        Console.WriteLine("You equipped the " + inventory[0].name);
                        Console.WriteLine("Boost increased by " + inventory[0].boost);
                        break;
                    }
                case '2':
                    {
                        player.EquipItem(1);
                        Console.WriteLine("You equipped the " + inventory[1].name);
                        Console.WriteLine("Boost increased by " + inventory[1].boost);
                        break;
                    }
                case '3':
                    {
                        player.EquipItem(2);
                        Console.WriteLine("You equipped the " + inventory[2].name);
                        Console.WriteLine("Boost increased by " + inventory[2].boost);
                        break;
                    }

            }
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

        //Inventory Functions
        public void AcquireItem(Item item, int index)
        {
            _inventory[index] = item;
        }

        public bool Contains(int itemIndex)
        {
            if (itemIndex > 0 && itemIndex < _inventory.Length)
            {
                return true;
            }
            return false;
        }

        public void EquipItem(int itemIndex)
        {
            if (Contains(itemIndex))
            {
                _currentItem = _inventory[itemIndex];
            }
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
