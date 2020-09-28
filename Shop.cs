using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Shop
    {
        private int _gold;
        private Item[] _inventory;

        public Shop()
        {//Default shop stats
            _gold = 100;
            _inventory = new Item[5];
        }

        public Shop(Item[] items)
        {
            //Allows for multiple shops to be created
            _gold = 100;
            _inventory = items;
        }

        public bool Sell(Player player, int shopIndex, int playerIndex)
        {
            Item itemToBuy = _inventory[shopIndex];
            if(player.Buy(itemToBuy, playerIndex))
            {
                _gold += itemToBuy.cost;
                return true;
            }
            return false;
        }
    }
}
