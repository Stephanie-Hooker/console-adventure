using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project.Controllers
{

  public class GameController : IGameController
  {
    private GameService _gameService = new GameService();

    //NOTE Makes sure everything is called to finish Setup and Starts the Game loop
    // public bool playing = true;
    public void Run()
    {
      InitialSetup();
      //   Setup();
      //   _gameService.Playing = true;
      while (true)
      {
        Print();
        GetUserInput();

      }
    }

    //NOTE Gets the user input, calls the appropriate command, and passes on the option if needed.
    public void GetUserInput()
    {

      Console.WriteLine("What would you like to do?");
      Console.WriteLine("(go, look, help, quit)");
      string input = Console.ReadLine().ToLower() + " ";
      string command = input.Substring(0, input.IndexOf(" "));
      string option = input.Substring(input.IndexOf(" ") + 1).Trim();
      //NOTE this will take the user input and parse it into a command and option.
      //IE: take silver key => command = "take" option = "silver key"
      Console.WriteLine($"command: {command}");
      switch (command)
      {
        case "quit":
          Environment.Exit(0);
          break;
        case "go":
          Console.WriteLine("\n Which direction would you like to go?");
          _gameService.Go(option);
          break;
        case "use":
          Console.WriteLine("pick an item to use");
          _gameService.UseItem(option);
          break;
        case "help":
          _gameService.Help();
          break;






      }
    }

    //NOTE this should print your messages for the game.
    private void Print()
    {
      Console.Clear();
      foreach (var message in _gameService.Messages)
      {
        Console.WriteLine(message);
      }
      _gameService.Messages.Clear();
    }
    public void InitialSetup()
    {
      Console.WriteLine("what is your name?");
      _gameService.Setup(Console.ReadLine());

    }

  }
}