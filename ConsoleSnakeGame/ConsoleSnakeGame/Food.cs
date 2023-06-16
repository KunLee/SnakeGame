using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSnakeGame
{
    public class Food
    {
        public string? Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public bool IsEaten = false;
        public Food()
        {
            (X, Y) = GetCoordinate();
        }
        public (int x, int y) GetCoordinate_bk() 
        {
            var rnd = new Random();

            List<int> boardX = new List<int>();
            List<int> boardY = new List<int>();

            for (int i = 1; i < GlobalStatus.BoardWidth - 1; i++) 
            {
                boardX.Add(i);
            }

            for (int i = 1; i < GlobalStatus.BoardHeight - 1; i++)
            {
                boardY.Add(i);
            }

            var snake = GlobalStatus.Snake;

            foreach (var node in snake.body) 
            {
                boardX.Remove(node.x);
                boardY.Remove(node.y);
            }

            var foodX = boardX.ToArray()[rnd.Next(1, boardX.Count)];
            var foodY = boardY.ToArray()[rnd.Next(1, boardY.Count)];

            return(foodX, foodY);
        }

        public (int x, int y) GetCoordinate()
        {
            var rnd = new Random();

            // 长度为 m * n 的一维棋盘
            int innerWidth = GlobalStatus.BoardWidth - 2;
            int innerHeight = GlobalStatus.BoardHeight - 2;
            bool[] board = new bool[innerWidth * innerHeight];
            var snake = GlobalStatus.Snake;

            foreach (var (x, y) in snake.body) 
            {
                board[(y - 1) * innerWidth + (x - 1)] = true;
            }

            int mark = 0, result = 0;

            for (int i = 0; i < board.Length; i++) 
            {
                if (board[i] == true) continue;

                mark++;
                // 生成一个 [0, i) 之间的整数
                // 这个整数等于 0 的概率就是 1/i
                var randomPick = rnd.Next(mark);
                if (0 == randomPick)
                {
                    result = i; // mark used for calculating probability, i used for recording the current position
                }
            }

            return (result % innerWidth, result / innerWidth);
        }

        int Encode(int x, int y)
        {
            return x * GlobalStatus.BoardWidth + y;
        }

        // 将一维数组中的索引转化为二维数组中的坐标 (x, y)
        int[] Decode(int index)
        {
            return new int[] { index / GlobalStatus.BoardWidth, index % GlobalStatus.BoardWidth };
        }
    }
}
