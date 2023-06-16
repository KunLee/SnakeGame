using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace ConsoleSnakeGame
{
    
    
    class Key
    {
        public static void Press()
        {
            do
            {
                var Key = Console.ReadKey().Key;

                switch (Key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        GlobalStatus.CurrentDirection = Directions.Up;
                        break;

                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.A:
                        GlobalStatus.CurrentDirection = Directions.Left;
                        break;

                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        GlobalStatus.CurrentDirection = Directions.Down;
                        break;

                    case ConsoleKey.RightArrow:
                    case ConsoleKey.D:
                        GlobalStatus.CurrentDirection = Directions.Right;
                        break;

                    case ConsoleKey.Delete:
                        GlobalStatus.Score = 0;
                        break;

                    case ConsoleKey.Q:
                        Environment.Exit(-1);
                        break;

                    case ConsoleKey.R:
                        if (GlobalStatus.Color != ConsoleColor.Red)
                        {
                            GlobalStatus.Color = ConsoleColor.Red;
                        }
                        else
                        {
                            GlobalStatus.Color = ConsoleColor.White;
                        }
                        break;

                    case ConsoleKey.G:
                        if (GlobalStatus.Color != ConsoleColor.Green)
                        {
                            GlobalStatus.Color = ConsoleColor.Green;
                        }
                        else
                        {
                            GlobalStatus.Color = ConsoleColor.White;
                        }
                        break;

                    case ConsoleKey.B:
                        if (GlobalStatus.Color != ConsoleColor.Blue)
                        {
                            GlobalStatus.Color = ConsoleColor.Blue;
                        }
                        else
                        {
                            GlobalStatus.Color = ConsoleColor.White;
                        }
                        break;

                    case ConsoleKey.C:
                        if (GlobalStatus.Color != ConsoleColor.Cyan)
                        {
                            GlobalStatus.Color = ConsoleColor.Cyan;
                        }
                        else
                        {
                            GlobalStatus.Color = ConsoleColor.White;
                        }
                        break;

                    case ConsoleKey.M:
                        if (GlobalStatus.Color != ConsoleColor.Magenta)
                        {
                            GlobalStatus.Color = ConsoleColor.Magenta;
                        }
                        else
                        {
                            GlobalStatus.Color = ConsoleColor.White;
                        }
                        break;

                    case ConsoleKey.Y:
                        if (GlobalStatus.Color != ConsoleColor.Yellow)
                        {
                            GlobalStatus.Color = ConsoleColor.Yellow;
                        }
                        else
                        {
                            GlobalStatus.Color = ConsoleColor.White;
                        }
                        break;
                }

                Thread.Sleep(1);

            } while (true);
        }
    }
}
