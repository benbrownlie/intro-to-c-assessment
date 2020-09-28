using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    struct Item
    {//Struct used for all items

        //Used for name of item
        public string name;
        //Used for whatever boost the item gives. Health, Damage, Defense etc...
        public int boost;
    }
    class Game
    {
        bool gameOver = false;
        Player player1;
        Player player2;
        Item knife;
        Item axe;
        Item rifle;
        Item bullet;
        Item molotov;
        Item medpack;

        public void InitializeItems()
        {
            knife.name = "Knife";
            knife.boost = 10;
            axe.name = "Axe";
            axe.boost = 15;
            rifle.name = "Rifle";
            rifle.boost = 20;
            bullet.name = "Rifle bullet";
            bullet.boost = 0;
            molotov.name = "Molotov";
            molotov.boost = 50;
            medpack.name = "Medpack";
            medpack.boost = 100;
        }

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

        public void ChooseDestination()
        {
            Console.WriteLine("You come to a crossroads");
            char input;
            GetInput(out input, "Survive", "Shop", "What will you do?");
            if (input == '1')
            {
                Console.WriteLine("You have chosen Survive, goodluck.");
            }
            else
            {
                Console.WriteLine("You have chosen Shop.");
            }
        }
        //Run the game
        public void Run()
        {
            Start();

            while (gameOver == false)
            {
                Update();
            }

            End();
            
        }

        //Performed once when the game begins
        public void Start()
        {
            
        }

        //Repeated until the game ends
        public void Update()
        {
            
        }

        //Performed once when the game ends
        public void End()
        {
            
        }
    }
}
