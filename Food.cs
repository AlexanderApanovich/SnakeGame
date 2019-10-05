using System;

namespace Snake
{
    class Food
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public void CreateFood(int Width, int Height, Snake s)
        {
            bool correct = false;
            Random random = new Random();

            while (!correct)
            {
                correct = true;
                X = random.Next(1, Width);
                Y = random.Next(1, Height - 1);
                for (int i = 0; i < s.Length; i++)
                {
                    if ((s.queue[i].X == X) && (s.queue[i].Y == Y)) correct = false;
                }
                if ((s.SnakeHead.X == X) && (s.SnakeHead.Y == Y)) correct = false;
            }
        }

        public void Render()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write("*");
        }
    }
}
