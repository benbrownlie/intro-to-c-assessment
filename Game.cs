using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HelloWorld
{
    struct Item
    {//Struct used for all items

        //Used for name of item
        public string name;
        //Used for whatever boost the item gives. Health, Damage, Defense etc...
        public int boost;
        public int cost;
    }
    class Game
    {
        bool gameOver = false;
        Player _player;
        Creature _enemy;
        Item knife;
        Item axe;
        Item rifle;
        Item bullet;
        Item molotov;
        Item medpack;
        Item[] shopInventory;
        Shop shop;

        public void InitializeItems()
        {
            knife.name = "Knife";
            knife.boost = 10;
            knife.cost = 5;
            axe.name = "Axe";
            axe.boost = 15;
            axe.cost = 10;
            rifle.name = "Rifle";
            rifle.boost = 20;
            rifle.cost = 20;
            bullet.name = "Rifle bullet";
            bullet.boost = 0;
            bullet.cost = 2;
            molotov.name = "Molotov";
            molotov.boost = 50;
            molotov.cost = 40;
            medpack.name = "Medpack";
            medpack.boost = 100;
            medpack.cost = 40;
            //
            shopInventory = new Item[6];
        }

        public Player CreateCharacter()
        {
            Console.WriteLine("Please enter a name");
            string name = Console.ReadLine();
            Player player = new Player(100, name, 5, 100, 3);
            return player;
        }

        //Save, Load and MainMenu functions
        public void Save()
        {
            StreamWriter writer = new StreamWriter("SaveData.txt");
            _player.Save(writer);
            _enemy.Save(writer);
            writer.Close();
        }

        public void Load()
        {
            StreamReader reader = new StreamReader("SaveData.txt");
            _player.Load(reader);
            _enemy.Load(reader);
            reader.Close();
        }

        public void OpenMainMenu()
        {
            char input;
            GetInput(out input, "Create Character", "Load Character", "What would you like to do?");
            if (input == '2')
            {
                _player = new Player();
                _enemy = new Creature();
                Load();
                return;
            }
            _player = CreateCharacter();

        }
        //
        public void GetInput(out char input, string option1, string option2, string query)
        {
            //Prints question or task to console
            Console.WriteLine(query);
            //Displays your options
            Console.WriteLine(option1);
            Console.WriteLine(option2);

            input = ' ';
            //Loops until a valid input is recieved
            while (input != '1' && input != '2')
            {
                input  = Console.ReadKey().KeyChar;
                if (input != '1' && input != '2')
                {
                    Console.WriteLine("Invalid input, please try again.");
                }
            }
        }

        public void GetInput(out char input, string option1, string option2, string option3, string query)
        {
            //Prints question or task to console
            Console.WriteLine(query);
            //Displays your options
            Console.WriteLine(option1);
            Console.WriteLine(option2);

            input = ' ';
            //Loops until a valid input is recieved
            while (input != '1' && input != '2' && input != '3')
            {
                input = Console.ReadKey().KeyChar;
                if (input != '1' && input != '2' && input != '3')
                {
                    Console.WriteLine("Invalid input, please try again.");
                }
            }
        }
        public void PrintInventory(Item[] inventory)
        {
            for (int i = 0; i < inventory.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + inventory[i].name + inventory[i].cost);
            }
        }

        public void ChooseDestination()
        {
            Console.WriteLine("You come to a crossroads");
            char input;
            GetInput(out input, "Fight", "Shop", "What will you do?");
            if (input == '1')
            {
                Console.WriteLine("You have chosen Fight, goodluck.");
                Combat();
            }
            else
            {
                Console.WriteLine("You have chosen Shop.");
                OpenShopMenu();
            }
        }

        public void Combat()
        {
            Console.Clear();
            Console.WriteLine("You approach the battle arena");
            Console.WriteLine("The enemy monster attacks");

            while(_player.GetPlayerAlive() && _enemy.GetCreatureAlive())
            {
                Console.WriteLine("Player: ");
                _player.PrintStats();
                Console.WriteLine("Monster: ");
                _enemy.PrintStats();
                char input;
                GetInput(out input, "Attack", "Switch Item", "Save", "What will you do Player?");

                if (input == '1')
                {
                    float damageTaken = _player.Attack(_enemy);
                    Console.WriteLine("You attacked the enemy for " + damageTaken + " damage.");
                }
                else if (input == '2')
                {
                    _player.SwitchItem(_player);
                }
                else
                {
                    Save();
                }
            }
        }

        public void OpenShopMenu()
        {
            Console.WriteLine("Welcome survivor! What are you looking for?");
            //Prints the shop's inventory to the console
            PrintInventory(shopInventory);
            int itemIndex = -1;
            char input = Console.ReadKey().KeyChar;

            //Index for all shop items
            switch (input)
            {
                case '1':
                    {
                        itemIndex = 0;
                        break;
                    }
                case '2':
                    {
                        itemIndex = 1;
                        break;
                    }
                case '3':
                    {
                        itemIndex = 2;
                        break;
                    }
                case '4':
                    {
                        itemIndex = 3;
                        break;
                    }
                case '5':
                    {
                        itemIndex = 4;
                        break;
                    }
                case '6':
                    {
                        itemIndex = 5;
                        break;
                    }
                default:
                    {
                        return;
                    }
            }
            //Checks to see if the player has enough gold to purchase the item
            if (_player.GetGold() < shopInventory[itemIndex].cost)
            {
                //If the gold requirement is not met, this message will display 
                Console.WriteLine("\nSorry pal, you don't have enough for that.");
                return;

            }
            //If the requirement is met, the function will continue and allow you to replace and inventory slot
            Console.WriteLine("\nChoose a inventory slot to replace for this item");
            PrintInventory(_player.GetInventory());
            input = Console.ReadKey().KeyChar;
            int playerIndex = -1;

            //Index for player inventory index
            switch (input)
            {
                case '1':
                    {
                        playerIndex = 0;
                        break;
                    }
                case '2':
                    {
                        playerIndex = 1;
                        break;
                    }
                case '3':
                    {
                        playerIndex = 2;
                        break;

                    }
                case '4':
                    {
                        playerIndex = 3;
                        break;
                    }
                case '5':
                    {
                        playerIndex = 4;
                        break;
                    }
                case '6':
                    {
                        playerIndex = 5;
                        break;
                    }
                default:
                    {
                        return;
                    }
            }
            shop.Sell(_player, itemIndex, playerIndex);

        }
        //Run the game
        public void Run()
        {
            Start();
            //While the bool "gameOver" is false the game will continue to play
            while (gameOver == false)
            {
                Update();
            }

            End();
            
        }

        //Performed once when the game begins
        public void Start()
        {
            gameOver = false;
            _player = new Player();
            InitializeItems();
            shopInventory = new Item[] { knife, axe, rifle, bullet, molotov, medpack };
            shop = new Shop(shopInventory);
        }

        //Repeated until the game ends
        public void Update()
        {
            OpenMainMenu();
            ChooseDestination();
            
        }

        //Performed once when the game ends
        public void End()
        {
            
        }
    }
}
