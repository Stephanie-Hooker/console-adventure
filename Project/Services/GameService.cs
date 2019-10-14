using System.Collections.Generic;
using System.Linq;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project
{
  public class GameService : IGameService
  {
    public GameService(IGame _game, bool playing)
    {
      this._game = _game;
      // this.Playing = playing;

    }
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
      if (to == "Office")
      {
        Messages.Add("You waited to long to get caffeine, you DIE!\n");


      }
      Messages.Add($"You have left {from} and have now entered the {to}");
      Messages.Add(_game.CurrentRoom.GetTemplate());
    }

    public void Help()
    {
      Messages.Add(" Go - allows you to move between the rooms using north, east, south, west \n Inventory - allows you to see the list of items you have collected in the rooms \n Look - returns you back to your current room \n Take item - allows you to to take the item with you to the next room \n Use item - allows you to the use the item in current room \n Quit - allows you to quit the game\n");

    }

    public void Inventory()
    {
      if (_game.CurrentPlayer.Inventory.Count == 0)
      {
        Messages.Add($"There are no items in your Inventory list");
        return;
      }
      foreach (Item item in _game.CurrentPlayer.Inventory)
      {
        Messages.Add($"Item: {item.Name}");
      }
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
      Program.StartQuestion();
    }

    public void Setup(string playerName)
    {
      Messages.Add($"Hello {playerName}, you are now in the {_game.CurrentRoom.Name} \n");
      Messages.Add(_game.CurrentRoom.GetTemplate());
    }
    ///<summary>When taking an item be sure the item is in the current room before adding it to the player inventory, Also don't forget to remove the item from the room it was picked up in</summary>
    public void TakeItem(string itemName)
    {
      Item item = _game.CurrentRoom.Items
        .FirstOrDefault(x => x.Name.ToLower() == itemName);
      if (item == null)
      {
        Messages.Add($"No item to take");
        return;
      }
      if (item.TakableItem == false)
      {
        Messages.Add("This item cannot be taken, only used in current room");
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
      Item itemInInventory = _game.CurrentPlayer.Inventory
     .FirstOrDefault(i => i.Name.ToLower() == itemName);
      Item itemInRoom = _game.CurrentRoom.Items
      .FirstOrDefault(i => i.Name.ToLower() == itemName);

      if (itemInInventory == null && itemInRoom == null)
      {
        Messages.Add($"The {itemName} cannot be used unless it is in the room or added to your inventory list. Typing (take) {itemName} will add it to your inventory list");
        return;
      }
      switch (itemName)
      {
        case "coffee mug":
          Messages.Add($"The {itemName} cannot be used, only taken");
          break;
        case "light switch":
          _game.CurrentRoom.ItemUsed = true;
          _game.CurrentRoom.Items.Remove(itemInRoom);
          Messages.Add("The light has been turned on in the room. Type (look) to see the items in pantry");
          _game.CurrentRoom.Items.Add(new Item("Starbucks coffee", "It is the best coffee in the world, right?"));
          _game.CurrentRoom.Items.Add(new Item("generic coffee", "do you take a risk?"));
          break;
        case "Starbucks coffee":
          Messages.Add($"The {itemName} cannot be used, only taken");
          break;
        case "generic coffee":
          Messages.Add($"The {itemName} cannot be used, only taken");
          break;
        case "coffee maker":
          Messages.Add("You have chosen the right path and coffee beans to make the coffee. Life can continue on. You win!");
          break;
      }
    }

    public Item GetItemByName(string itemName, List<Item> items)
    {
      return items.FirstOrDefault(i => i.Name == itemName);
    }
  }
}