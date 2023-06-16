using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSnakeGame
{
    public enum Directions { None, Up, Down, Left, Right }

    public static class GlobalStatus
    {
        public static Directions CurrentDirection = Directions.None;
        public static Food CurrentFood = null!;
        public static Snake Snake = null!;
        public static int Score = 0;
        public static int BoardWidth = 0;
        public static int BoardHeight = 0;
        public static ConsoleColor Color = ConsoleColor.Green;

        public static void Reset() 
        {
            CurrentDirection = Directions.None;
            CurrentFood = null!;
            Score = 0;
        }
    }
}
