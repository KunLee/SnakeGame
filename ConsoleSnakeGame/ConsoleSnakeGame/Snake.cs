using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSnakeGame
{
    public class Snake
    {
        public int Speed;
        public bool IsAlive = true;
        public LinkedList<(int x, int y)> body = new LinkedList<(int x, int y)> ();
        public Snake(int initX, int initY, int speed = 100, int length = 1)
        {
            this.Speed = speed;

            for (int i = 0; i < length; i++) 
            {
                body.AddLast((initX + i, initY));
            }
        }
        public void Move(Directions direction) 
        {
            if (body.Count == 0) return;

            var (x, y) = body.First();

            switch (direction) 
            { 
                case Directions.None:
                    return;
                case Directions.Up:
                    {
                        y -= 1;
                        break;
                    }
                case Directions.Down:
                    {
                        y += 1;
                        break;
                    }
                case Directions.Left:
                    {
                        x -=1;
                        break;
                    }
                case Directions.Right:
                    {
                        x += 1;
                        break;
                    }
            }
            if (!CheckDeath((x, y))) body.AddFirst((x, y));
            else 
            { 
                IsAlive = false;
            }

            if (!IsFoodEaten(x, y)) body.RemoveLast();
        }

        public bool CheckDeath((int x, int y) head) 
        {
            foreach (var (x, y) in body) 
            {
                if (x == head.x && y == head.y) return true;
            }

            if (head.x <= 0 || head.x >= (GlobalStatus.BoardWidth - 1) || 
                head.y <= 0 || head.y >= (GlobalStatus.BoardHeight - 1)) return true;

            return false;
        }
        public bool IsFoodEaten(int x, int y) 
        {
            var food = GlobalStatus.CurrentFood;
            if (x == (food.X + 1) && y == (food.Y + 1)) 
            {
                food.IsEaten = true;
                GlobalStatus.Score++;
                return true; 
            }
            return false;
        }
    }
}
