using System;
using ConsoleAdventure.Project;
using ConsoleAdventure.Project.Controllers;

namespace ConsoleAdventure
{
  public class Program
  {
    public static void Main(string[] args)
    {
      StartQuestion();
    }
    public static void StartQuestion()
    {
      Console.WriteLine("Welome to the game, would you like to play? type y for yes, and n for no");
      switch (Console.ReadLine().ToLower())
      {
        case "y":
          new GameController().Run();
          break;
        case "n":
          Environment.Exit(0);
          break;
        default:
          Console.WriteLine("invalid choice");
          StartQuestion();
          break;
      }
    }
  }
}
