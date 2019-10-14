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
      Console.WriteLine("Would you like to play Fill your Coffee Mug? type either (y)es to play or (n)o to quit.");
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
