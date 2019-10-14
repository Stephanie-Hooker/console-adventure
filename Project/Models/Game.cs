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
      Room room1 = new Room("Bedroom", "");
      Room room2 = new Room("Living room", "2");
      Room room3 = new Room("Pantry", "The pantry is dark", "The light has been turned on and you see 2 different bags of coffee. Choose one bag to take with you onto the next room.");
      Room room4 = new Room("Dining room", "4");
      Room room5 = new Room("Office", "5");
      Room room6 = new Room("Kitchen", "6");

      //create relationships between rooms
      room1.Exits.Add("north", room2);
      room2.Exits.Add("south", room1);

      room2.Exits.Add("west", room3);
      room3.Exits.Add("east", room2);

      room2.Exits.Add("north", room4);
      room4.Exits.Add("south", room2);

      room3.Exits.Add("north", room5);

      room4.Exits.Add("west", room5);

      room4.Exits.Add("east", room6);
      room6.Exits.Add("west", room4);

      //   create items for rooms
      Item I1 = new Item("coffee mug", "your mug is empty. find your way through the rooms to fill your mug.");
      Item I2 = new Item("Light switch", "Use the light switch to brighten the room", false);
      Item I3 = new Item("coffee maker", "you found the item needed to make the magic bean juice", false);

      room1.Items.Add(I1);
      room3.Items.Add(I2);

      room6.Items.Add(I3);


      CurrentRoom = room1;


    }
  }
}