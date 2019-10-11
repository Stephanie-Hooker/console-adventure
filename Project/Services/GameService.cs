using System.Collections.Generic;
using System.Linq;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project
{
  public class GameService : IGameService
  {
    private IGame _game { get; set; }

    public List<string> Messages { get; set; }
    // public bool Playing { get; set; }
    public GameService()
    {
      _game = new Game();
      Messages = new List<string>();
    }
    public void Go(string direction)
    {
      // change rooms
      string from = _game.CurrentRoom.Name;
      _game.CurrentRoom = _game.CurrentRoom.Go(direction);
      string to = _game.CurrentRoom.Name;

      // if failed to change rooms, stop code execution
      if (from == to)
      {
        Messages.Add("Invalid Choice");
        return;
      }
      Messages.Add($"You have left {from} and have now entered the {to}");
      Messages.Add(_game.CurrentRoom.GetTemplate());
    }

    public void Help()
    {
      Messages.Add(" Go - allows you to move between the rooms, \n Inventory - allows you to see the list of items you have collected, \n Look - returns you back to your current room from the help menu, \n Take item - allows you to to take the item with you to the next room, \n Use item - allows you to the use the item in current room \n Quit - allows you to quit the game.");
      Messages.Add(_game.CurrentRoom.GetTemplate());
    }

    public void Inventory()
    {
      throw new System.NotImplementedException();
    }

    public void Look()
    {
      Messages.Add(_game.CurrentRoom.GetTemplate());
    }

    public void Quit()
    {
      //   Playing = false;

    }
    ///<summary>
    ///Restarts the game 
    ///</summary>
    public void Reset()
    {
      throw new System.NotImplementedException();
    }

    public void Setup(string playerName)
    {
      Messages.Add($" You are now in the {_game.CurrentRoom.Name} \n");
      Messages.Add(_game.CurrentRoom.GetTemplate());
    }
    ///<summary>When taking an item be sure the item is in the current room before adding it to the player inventory, Also don't forget to remove the item from the room it was picked up in</summary>
    public void TakeItem(string itemName)
    {
      Item item = _game.CurrentRoom.Items
        .FirstOrDefault(x => x.Name == itemName);

      if (item == null)
      {
        Messages.Add($"No item to take");
        return;
      }
      Messages.Add($"taking {item.Name} and adding to inventory list");
      _game.CurrentPlayer.Inventory.Add(item);
      _game.CurrentRoom.Items.Remove(item);
      Messages.Add(_game.CurrentRoom.GetTemplate());
    }

    ///<summary>
    ///No need to Pass a room since Items can only be used in the CurrentRoom
    ///Make sure you validate the item is in the room or player inventory before
    ///being able to use the item
    ///</summary>
    public void UseItem(string itemName)
    {
      Messages.Add(itemName);
      Item itemToUse = _game.CurrentPlayer.Inventory
        .FirstOrDefault(i => i.Name.ToLower() == itemName);
      Item itemInRoom = _game.CurrentRoom.Items
      .FirstOrDefault(i => i.Name.ToLower() == itemName);

      if (itemToUse == null && itemInRoom == null)
      {
        Messages.Add($"Can't use the {itemName} unless it is in your inventory list or in the room.");
        return;
      }
      // if item is named Starbucks player dies
      switch (itemName)
      {
        case "coffee mug":
          Messages.Add("You can not use the coffee mug without first finding the coffee.");
          break;
        case "bag of Starbucks coffee":
          Messages.Add("You have chosen the Starbucks coffee which was poisened and you DIE!!");
          //Program.StartQuestion();
          break;
        case "bag of non-name brand coffee":
          Messages.Add("You have chosen the non-name brand coffee and may continue on your journey to fill your coffee mug");
          break;
        case "coffee maker":
          Messages.Add("You have chosen the right path to make the coffee. Life can continue on. You win!");
          //Program.StartQuestion();
          break;


      }


    }

    public Item GetItemByName(string itemName, List<Item> items)
    {
      return items.FirstOrDefault(i => i.Name == itemName);
    }
  }
}