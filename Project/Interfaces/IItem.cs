using System.Collections.Generic;

namespace ConsoleAdventure.Project.Interfaces
{
  public interface IItem
  {
    string Name { get; set; }
    string Description { get; set; }
    public bool TakableItem { get; set; }
  }
}