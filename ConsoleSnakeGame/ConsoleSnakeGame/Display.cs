using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSnakeGame
{
    internal class Display
    {
        public static List<string> FrameChar { get; set; } = new List<string>();
        public static StringBuilder FrameString { get; set; } = new StringBuilder();
        public static StringBuilder DisplayFrame { get; set; } = new StringBuilder();
        public static ConsoleColor Color { get; set; } = ConsoleColor.White;
        public static int HighScore { get; set; } = 0;

        public static int FrameWidth = 0;

        public static int FrameHeight = 0;

        public static void Reset() 
        {
            DisplayFrame.Clear();
        }
        public static void SetFrame(int width, int height)
        {
            FrameString.Clear();
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i == 0)
                    {
                        if (j == 0)
                        {
                            FrameString.Append("╔");
                        }
                        else if (j == width - 1)
                        {
                            FrameString.Append("╗" + (Char)10);
                        }
                        else
                        {
                            FrameString.Append("═");
                        }
                    }
                    else if (i == height - 1)
                    {
                        if (j == 0)
                        {
                            FrameString.Append("╚");
                        }
                        else if (j == width - 1)
                        {
                            FrameString.Append("╝" + (Char)10);
                        }
                        else
                        {
                            FrameString.Append("═");
                        }
                    }
                    else
                    {
                        if (j == 0)
                        {
                            FrameString.Append("║");
                        }
                        else if (j == width - 1) 
                        {
                            FrameString.Append("║" + (Char)10);
                        }
                        else
                        {
                            FrameString.Append(" ");
                        }
                    }
                }
            }
            //FrameString.Append("╔═════════════════════════════════╗" + (Char)10);
            //FrameString.Append("║                                 ║" + (Char)10);
            //FrameString.Append("║                                 ║" + (Char)10);
            //FrameString.Append("║                                 ║" + (Char)10);
            //FrameString.Append("║                                 ║" + (Char)10);
            //FrameString.Append("║                                 ║" + (Char)10);
            //FrameString.Append("║                                 ║" + (Char)10);
            //FrameString.Append("║                                 ║" + (Char)10);
            //FrameString.Append("║                                 ║" + (Char)10);
            //FrameString.Append("║                                 ║" + (Char)10);
            //FrameString.Append("║                                 ║" + (Char)10);
            //FrameString.Append("║                                 ║" + (Char)10);
            //FrameString.Append("║                                 ║" + (Char)10);
            //FrameString.Append("║                                 ║" + (Char)10);
            //FrameString.Append("║                                 ║" + (Char)10);
            //FrameString.Append("║                                 ║" + (Char)10);
            //FrameString.Append("║                                 ║" + (Char)10);
            //FrameString.Append("║                                 ║" + (Char)10);
            //FrameString.Append("║                                 ║" + (Char)10);
            //FrameString.Append("╚═════════════════════════════════╝" + (Char)10);

            var lines = Display.FrameString.ToString().Split((Char)10);
            FrameHeight = lines.Length - 1; // 1 == char 10 with up and down borders
            FrameWidth = lines[0].Length; // contains the border, need to -1 when checkdeath 
        }

        public static void UpdateScreen(Snake snake, Food food) 
        {
            //Set the Values for Movement Calculations
            int width = FrameWidth;

            DisplayFrame.Clear();
            DisplayFrame.Append(FrameString);

            foreach (var (x, y) in snake.body) 
            {
                DisplayFrame[(width + 1) * y + x] = '#';
            }

            DisplayFrame[(width + 1) * (food.Y + 1) + (food.X + 1)] = '@';

            DisplayFrame.Append($"  Score: {snake.body.Count - 1}          Best: {HighScore}");
            DisplayFrame.Append(System.Environment.NewLine);
        }

        public static void GameOver(Snake snake) 
        {
            if (HighScore < (snake.body.Count - 1)) HighScore = snake.body.Count - 1;
            Reset();
        }
    }
}
