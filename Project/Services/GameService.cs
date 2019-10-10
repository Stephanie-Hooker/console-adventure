using System.Collections.Generic;
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
      throw new System.NotImplementedException();
    }
    ///<summary>
    ///No need to Pass a room since Items can only be used in the CurrentRoom
    ///Make sure you validate the item is in the room or player inventory before
    ///being able to use the item
    ///</summary>
    public void UseItem(string itemName)
    {
      throw new System.NotImplementedException();
    }
  }
}