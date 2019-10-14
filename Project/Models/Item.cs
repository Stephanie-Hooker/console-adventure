using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Item : IItem
  {

    public string Name { get; set; }
    public string Description { get; set; }
    public bool TakableItem { get; set; } = true;
    public Item(string name, string description, bool takableItem = true)
    {
      Name = name;
      Description = description;
      TakableItem = takableItem;
    }
  }
}