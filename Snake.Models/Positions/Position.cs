namespace Snake.Models.Positions
{
    using System;
    using System.Linq;
    using Snake.Models.GlobalConstants;
    using Snake.Models.Snakes.Contracts;

    public class Position
    {
        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; private set; }
        public int Y { get; private set; }

        public static void ValidatePosition(ISnake snake, Position newSnakeHead)
        {
            if (newSnakeHead.X >= Console.WindowHeight - Constants.FrameworkBorderSideFour ||
                newSnakeHead.X < Constants.FrameworkBorderSideThree ||
                newSnakeHead.Y >= Console.WindowWidth - Constants.FrameworkBorderSideTwo ||
                newSnakeHead.Y <= Constants.FrameworkBorderSideOne
               )
            {
                throw new InvalidOperationException(Constants.GameOverMessage);
            }

            var isValid = snake.Body.Where(x => x.X == newSnakeHead.X && x.Y == newSnakeHead.Y).FirstOrDefault();
            if (isValid != null)
            {
                throw new InvalidOperationException(Constants.GameOverMessage);
            }
        }
    }
}
