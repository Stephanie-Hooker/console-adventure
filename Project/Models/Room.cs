using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using System;

namespace ConsoleAdventure.Project.Models
{
  public class Room : IRoom
  {

    public string Name { get; set; }
    public string Description { get; set; }
    public List<Item> Items { get; set; }
    public Dictionary<string, IRoom> Exits { get; set; }
    public bool ItemUsed { get; set; } = false;
    public string AlteredDescription { get; set; }
    public Room(string name, string description, string alteredDescription = "")
    {
      Name = name;
      Description = description;
      AlteredDescription = alteredDescription;
      Items = new List<Item>();
      Exits = new Dictionary<string, IRoom>();
    }

    public void AddExit(string direction, IRoom room)
    {
      Exits.Add(direction, room);
    }
    public IRoom Go(string direction)
    {
      if (Exits.ContainsKey(direction))
      {
        return Exits[direction];
      }
      return this;
    }

    public string GetTemplate()
    {
      string template = $" Room: {Name} \n";
      if (ItemUsed)
      {
        template += $"{AlteredDescription} \n";
      }
      else
      {
        template += $"{Description}\n";
      }
      foreach (var item in Items)
      {
        template += $"\n Item(s) in room: {item.Name} \n {item.Description} \n";
      }
      foreach (var exit in Exits)
      {
        template += "\n go " + exit.Key + " -- brings you to the " + exit.Value.Name + Environment.NewLine;
      }
      return template;
    }
  }
}