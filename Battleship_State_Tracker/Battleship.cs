using System;
namespace Battleship_State_Tracker
{
    public class Battleship
    {
        public string name { get; set; }
        public int xPos { get; set; }
        public int yPos { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int health { get; set; }
        public bool isDestroyed { get; set; }
    }
}
