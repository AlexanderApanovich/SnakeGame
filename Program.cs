using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int Width = 40;
            int Height = 20;

            int delay = Width * Height / 100;

            int Score = 1;

            Console.SetWindowSize(Width, Height);
            Console.SetBufferSize(Width, Height);
            Console.CursorVisible = false;
            Console.Title = "Счет : 0";

            Snake snake = new Snake();
            Food food = new Food();
            ConsoleKey key;

            snake.Render();
            food.CreateFood(Width, Height, snake);
            food.Render();

            do
            {
                while (!Console.KeyAvailable)
                {
                    if (snake.SnakeHead.X == 0 || snake.SnakeHead.X == Width || snake.SnakeHead.Y == 0 || snake.SnakeHead.Y == Height) return;

                    if (snake.FoodCollider(food))
                    {
                        food.CreateFood(Width, Height, snake);
                        Console.Title = "Счет: " + Score;
                        Score++;
                    }

                    snake.Push(snake.SnakeHead);
                    if (snake.Length >= Score)
                    {
                        snake.RemoveFirst();
                    }

                    Thread.Sleep(500);
                    switch (snake.Moving)
                    {
                        case "left": snake.SnakeHead.X--; break;
                        case "right": snake.SnakeHead.X++; break;
                        case "up": snake.SnakeHead.Y--; break;
                        case "down": snake.SnakeHead.Y++; break;
                    }

                    Console.Clear();
                    food.Render();
                    snake.Render();

                }

                key = Console.ReadKey(true).Key;

                snake.SnakeHeadMove(key);

                Thread.Sleep(delay);
                Console.Clear();
                food.Render();
                snake.Render();

            } while (key != ConsoleKey.Escape);
        }
    }
}