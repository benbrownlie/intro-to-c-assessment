
*Benjamin Brownlie* |
|--- |
First Year Game Programming |
Intro to C# Assessment |

## Program Requirements

Create a program based off a previous project that includes all subjects learned in intro to c#

***List of Requirements***

 >   -  Use of variables, operators and expressions
 >   -  Use of sequester, selection and iteration functions
 >   -  At least two instances of the use of arrays to store primitive or custom data types
 >   -  Reading and writing to a text file
 >   -  Two classes that each contain four instance variables
 >   -  Multiple options for object construction
 >   -  User-defined aggregation
 >   -  Use of polymorphism once for code extensibility
 >   -  Code documentation


## Program Structure
 
**Classes and Functions**

List of all the functions and classes that make up the program

#### Game Class
Holds the Run, Start, Update and End functions. Along with other valuable functions that partain to the main game loop

>   * Item Struct- Holds the definitions for items: string name and int boost(boost is the damage for weapons)
>
>   * CreateCharacter- Creates a new instance of player and enemy with default values.
>
>   * OpenMainMenu- Asks if the player would like to create a new game or load a previously saved game. If create character is selected, calls the CreateCharacter function. If Load Character is selected, calls the Load function.
>
>   * GetInput- Loops until a valid input is acquired.
>    Has an overloaded function that takes in three options instead of two.
>
>   * PrintInventory- Displays all the items in the player's inventory to the console.
>
>   * ChooseDestination- After creating your character you are given the option to either go to the shop or straight into combat.
>
>   * Combat- Runs while the player and enemy are still alive. Displays the options to fight, switch items or save. If fight is selected decrements both characters by their specified damage values. If switch item is selected displays the player's inventory and allows them to change to an item in it. If save is selected, calls the save function.
>
>   * OpenShopMenu- Displays all the items available for purchase, when one is selected subtracts the players gold by the item price and allows them to place it in an inventory slot.



#### Shop class 
Holds the functions used for the shop system

>   * Initializes the shops default stats and holds a shop constructor if more shops are desired in the future.
>
>   * Sell- After the player buys an item, adds the cost of that item to the shop's gold amount and returns true or false.



#### Player class
Holds the functions used for buying, selling, attacking, saving and loading as a player.

>   * Initializes the player's default stats and has a constructor to allow for more player's to be created.
>
  **Functions for reading and writing to a txt file**

>   * Save- Writes down all the player's stats to the text file (SaveData.txt).
>
>   * Load- Reads from the text files and converts the stats written down to be used.

 **Battle Functions** - Used during combat phase of program

>   * Attack- calls for the enemy to take damage and returns the value.
>
>   * TakeDamage- Checks if the player's health is 0. Returns the damage value.

**Inventory Functions** - Functions used for the player's inventory array

>   * SwitchItems- Displays the name and boost of all the items in the player's inventory. Gets the input of the desired item from the player.
>  
>   * GetInventory- Used to show all items in inventory.

**Getter Functions** - Various functions used to get information

>   * GetName- Used to show the player's name.
>
>   * GetPlayerAlive- returns whether the player's health is greater than 0.
>
>   * GetGold- returns the amount of gold the player has.
>
>   * Contains- Checks for an item.
>
>   * EquipItems- Uses contains to check for an item then equips it to the player.
>
>   * Buy- Checks if the player's amount of gold is equal to or greater than the cost of the item they want to buy. If true subtracts the cost from player's gold and adds the item to their inventory.
>
>   * PrintStats- prints the player's stats to the console.

#### Creature class 
A class that inherits from player

>   * Inherits stats from the player as well as adding its own such as loot.
>
>   * Attack- Used for attacking the player
>
>   * TakeDamage- returns the damage value.
>
>   * GetCreatureAlive- checks if the creature's health is equal to or above 0.