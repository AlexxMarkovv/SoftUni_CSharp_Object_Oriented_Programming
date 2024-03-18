using System;

namespace SimpleSnake.GameObjects
{
    public class Wall : Point
    {
        private const char WallSymbol = '\u25A0';

        public Wall(int leftX, int topY) : base(leftX, topY)
        {
            this.InitializeBorders();
        }

        public bool IsPointOfWall(Point snakeHead)
            => snakeHead.LeftX == 0
            || snakeHead.TopY == 0
            || snakeHead.LeftX == this.LeftX - 1
            || snakeHead.TopY == this.TopY;


        private void InitializeBorders()
        {
            SetHorizontalBorder(0);

            SetVerticalBorder(0);
            SetVerticalBorder(this.LeftX - 1);

            SetHorizontalBorder(this.TopY);
        }

        private void SetHorizontalBorder(int y)
        {
            Console.SetCursorPosition(0, y);

            for (int i = 0; i < LeftX; i++)
            {
                Console.Write(WallSymbol);
            }
        }

        private void SetVerticalBorder(int x)
        {
            for (int i = 0; i < TopY; i++)
            {
                Console.SetCursorPosition(x, i);
                Console.Write(WallSymbol);
            }
        }
    }
}
