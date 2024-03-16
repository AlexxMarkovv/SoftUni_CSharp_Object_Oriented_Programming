using System;
using System.Drawing;
using System.Threading;
using SimpleSnake.Enums;
using SimpleSnake.GameObjects;
using Point = SimpleSnake.GameObjects.Point;

namespace SimpleSnake.Core
{
    public class Engine
    {
        private readonly Point[] pointDirections;
        private Direction direction;

        private readonly Wall wall;
        private readonly Snake snake;

        private float sleepTime;

        public Engine(Wall wall, Snake snake)
        {
            pointDirections = new Point[4];

            pointDirections[0] = new Point(1, 0);
            pointDirections[1] = new Point(-1, 0);

            pointDirections[2] = new Point(0, 1);
            pointDirections[3] = new Point(0, -1);

            this.wall = wall;
            this.snake = snake;

            sleepTime = 100;
        }

        public void Run()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    GetNextDirection();
                }

                bool isMoving = snake.IsMoving(pointDirections[(int)this.direction]);

                if (!isMoving)
                {
                    AskUserForRestart();
                }

                sleepTime -= 0.01f;

                Thread.Sleep((int)sleepTime);
            }
        }

        private void AskUserForRestart()
        {
            Console.SetCursorPosition(3, 3);
            Console.Write("Would you like to continue? y/n");

            string input = Console.ReadLine();

            if (input == "y")
            {
                Console.Clear();
                StartUp.Main();
            }
            else
            {
                Console.WriteLine("GameOver");
            }
        }

        private void GetNextDirection()
        {
            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.LeftArrow)
            {
                if (direction != Direction.Right)
                {
                    direction = Direction.Left;
                }
            }
            else if (key.Key == ConsoleKey.RightArrow)
            {
                if (direction != Direction.Left)
                {
                    direction = Direction.Right;
                }
            }
            else if (key.Key == ConsoleKey.UpArrow)
            {
                if (direction != Direction.Down)
                {
                    direction = Direction.Up;
                }
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                if (direction != Direction.Up)
                {
                    direction = Direction.Down;
                }
            }

            Console.CursorVisible = false;
        }
    }
}
