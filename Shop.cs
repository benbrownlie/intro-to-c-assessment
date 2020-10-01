using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{

    class Shop
    {
        private int _gold;
        private Item[] _shopinventory;
        Player player;

        public Shop()
        {//Default shop stats
            _gold = 100;
            _shopinventory = new Item[5];
        }

        public Shop(Item[] items)
        {
            //Allows for multiple shops to be created
            _gold = 100;
            _shopinventory = items;
        }

        public bool Sell(Player player, int shopIndex, int playerIndex)
        {//If the player buys an item, add the cost of the item to the shops gold
            Item itemToBuy = _shopinventory[shopIndex];
            if(player.Buy(itemToBuy, playerIndex))
            {
                _gold += itemToBuy.cost;
                return true;
            }
            return false;
        }

    }
}
