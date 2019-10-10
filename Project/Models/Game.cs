using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Game : IGame
  {

    public IRoom CurrentRoom { get; set; }
    public IPlayer CurrentPlayer { get; set; }

    public Game()
    {

      CurrentPlayer = new Player();
      Setup();
    }
    //NOTE Make yo rooms here...
    public void Setup()
    {
      //create rooms
      Room room1 = new Room("Bedroom", "1");
      Room room2 = new Room("Dinning room", "2");
      Room room3 = new Room("Pantry", "3");
      Room room4 = new Room("Kitchen", "4");
      Room room5 = new Room("Room5", "5");
      Room room6 = new Room("Room6", "6");

      //create relationships between rooms
      room1.Exits.Add("north", room2);
      room2.Exits.Add("south", room1);

      room2.Exits.Add("west", room3);
      room3.Exits.Add("east", room2);

      room2.Exits.Add("north", room4);
      room4.Exits.Add("south", room2);

      room4.Exits.Add("west", room5);

      room4.Exits.Add("east", room6);

      //   create items for rooms
      Item I1 = new Item("coffee mug", "your mug is empty. find your way through the rooms to fill your mug.");
      Item I2 = new Item("bag of Starbucks coffee", "It is the best coffee in the world, right?");
      Item I3 = new Item("bag of non-name branded coffee", "do you take a risk?");
      Item I4 = new Item("coffee maker", "you found the item needed to make the magic bean juice");

      room1.Items.Add(I1);
      room3.Items.Add(I2);
      room3.Items.Add(I3);
      room4.Items.Add(I4);


      CurrentRoom = room1;


    }
  }
}