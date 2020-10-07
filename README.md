
## Intro to C# Assessment
By- Benjamin Brownlie |
--|
Game Programming Year One |

### How to play

**Shop**-
Starting off with 100 gold, you are tasked with purchasing equipment before fighting an enemy. After purchasing said item you can place it in your inventory
(``If you run out of gold you will not be able to purchase more items``)

**Fighting**-
During this phase you have several options:

> - (Attack) Pressing '1' will attack the enemy dealing damage equal to the "boost" of your current equipped item.
>
> -  (Switch Item) Pressing '2' will open your inventory, here you can select from a previously purchased item and equip it to your hands. This will change your attack stat based off the boost value of said item.
>
> - (Save) Pressing '3' will save your game data so you can come back and play later from the point where you saved.

**Post Game**- If you win your fight you will be awarded with gold, from here you will be taken back to the shop to purchase more items and start again.

### Gameplay Features

**Boost**- Your "boost" is a term used for the status boost a given item has. (``Example: The knife gives you a boost of 10, giving you 10 damage``)

**Gold**- Ingame currency gained by defeating the enemy, can be used at the shop to purchase equipment/items.

**Items**- Weapons and equipment that can be equipped to your character to change your stats and increase your odds of survival.

### BUGS
``All currently known in game bugs.``

> - Loading without a previous save file will crash the game.
>
> - Switching your items does not change your attack boost.