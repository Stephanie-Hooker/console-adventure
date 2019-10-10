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
    public Room(string name, string description)
    {
      Name = name;
      Description = description;
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
      string template = $"Room: {Name}";
      foreach (var exit in Exits)
      {
        template += "\t" + "go " + exit.Key + " -- brings you to the " + exit.Value.Name + Environment.NewLine;
      }
      foreach (var item in Items)
      {
        template += $"Item: \n {item.Name} \t {item.Description} \n";
      }
      return template;
    }
  }
}