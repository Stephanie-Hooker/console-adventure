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
      Room room1 = new Room("Bedroom", "It's morning, and your alarm clock just went off. You rub your eyes and look over to see an empty coffee mug sitting on your night stand. Time to get up and get some coffee in that mug!");
      Room room2 = new Room("Living room", "You have stumbled sleepily into the living room, the room is still dim as the sun is just starting to rise. You are starting to wake up as you make your way towards your goal...coffee!");
      Room room3 = new Room("Pantry", "You opened the door to the pantry, and the room is dark. How will you find your coffee beans?", "The light has been turned on and you now see 2 different bags of coffee beans. Choose a bag to take with you into the next room.");
      Room room4 = new Room("Dining room", "You have wandered into the dining room. There is nothing in this room, and no way to make the coffee. Keep going!");
      Room room5 = new Room("Office", "You went into the wrong room and waited too long to get caffeine. You DIED!");
      Room room6 = new Room("Kitchen", "You have found the right room to make coffee! Yay!");

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