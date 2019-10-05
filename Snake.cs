using System;

namespace Snake
{
    class Snake : Queue
    {
        public Point SnakeHead = new Point(1, 1);
        public string Moving { get; set; } = "down";

        public Snake() : base() { }

        public void Render()
        {
            for (int i = 0; i < Length; i++)
            {
                Console.SetCursorPosition(queue[i].X, queue[i].Y);
                Console.Write("■");
            }
            Console.SetCursorPosition(SnakeHead.X, SnakeHead.Y);
            Console.Write("■");
        }

        public void SnakeHeadMove(ConsoleKey pressedKey)
        {
            switch (pressedKey)
            {
                case ConsoleKey.UpArrow: SnakeHead.Y--; Moving = "up"; break;
                case ConsoleKey.DownArrow: SnakeHead.Y++; Moving = "down"; break;
                case ConsoleKey.LeftArrow: SnakeHead.X--; Moving = "left"; break;
                case ConsoleKey.RightArrow: SnakeHead.X++; Moving = "right"; break;
            }
        }

        public bool FoodCollider(Food f)
        {
            for (int i = 0; i < Length; i++) if ((queue[i].X == f.X) && (queue[i].Y == f.Y)) return true;
            if ((SnakeHead.X == f.X) && (SnakeHead.Y == f.Y)) return true;
            return false;
        }
    }
}
