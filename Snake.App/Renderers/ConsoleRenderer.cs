namespace Snake.App.Renderers
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using Snake.App.ConsoleHelpers;
    using Snake.App.Renderers.Contracts;
    using Snake.Models.Players.Contracts;
    using Snake.Models.Positions;
    using Snake.Models.Snakes.Contracts;

    public class ConsoleRenderer : IRenderer
    {
        private const int WindowDividerByTwo = 2;
        private const int WindowWidthMultiplier = 4;
        private const int WindowWidthDivider = 10;
        private const string GameLogo = "SNAKE GAME";
        private const string SnakeSymbol = "*";
        private const string FoodSymbol = "@";
        private const int OffsetPointsLenght = 10;
       
        public ConsoleRenderer()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();

            Console.WindowWidth = Console.LargestWindowWidth * WindowWidthMultiplier / WindowWidthDivider;
            Console.BufferHeight = Console.WindowHeight;
        }

        public void RenderGame(ISnake snake)
        {
            Console.Clear();
            Console.CursorVisible = false;

            for (int i = 1; i <= Console.BufferWidth - 1; i++)
            {
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.SetCursorPosition(i, 2);
                Console.Write(" ");
                Console.SetCursorPosition(i, Console.BufferHeight - 1);
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.Black;
            }
            for (int i = 1; i < Console.BufferHeight - 1; i++)
            {
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.SetCursorPosition(0, i);
                Console.Write(" ");
                Console.SetCursorPosition(Console.BufferWidth - 1, i);
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.Black;
            }

            foreach (var position in snake.Body)
            {
                Console.SetCursorPosition(position.Y, position.X);
                Console.Write(SnakeSymbol);
            }
        }

        public void RenderMainMenu()
        {
            ConsoleHelper.SetCursorAtCenter(GameLogo.Length);
            Console.WriteLine(GameLogo);
            Thread.Sleep(1500);
        }

        public void RenderSnakeFood(Position position)
        {
            Console.SetCursorPosition(position.Y, position.X);
            Console.Write(FoodSymbol);
        }

        public void RenderNewSnakeHead(IPlayer player, Position newSnakeHead, string bestScore)
        {
            Console.SetCursorPosition(0, 0);
            Console.Write($"Player: {player.Name}");

            Console.SetCursorPosition(Console.WindowWidth / WindowDividerByTwo - OffsetPointsLenght, 0);
            Console.Write($"Points: {player.Points}");

            Console.SetCursorPosition(Console.WindowWidth - 20, 0);
            Console.Write($"Best Score: {bestScore}");

            Console.SetCursorPosition(newSnakeHead.Y, newSnakeHead.X);
            Console.Write(SnakeSymbol);
        }

        public void RenderRemovalOfTail(Position snakeTail)
        {
            Console.SetCursorPosition(snakeTail.Y, snakeTail.X);
            Console.Write(" ");
        }

        public void RenderFinalResults(IPlayer player, string bestScore, KeyValuePair<string, int>[] topPlayers)
        {
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / WindowDividerByTwo - OffsetPointsLenght, Console.WindowHeight / WindowDividerByTwo);
            Console.Write($"Your score: {player.Name} => {player.Points}");
            Console.SetCursorPosition(Console.WindowWidth / WindowDividerByTwo - OffsetPointsLenght, Console.WindowHeight / WindowDividerByTwo + 1);
            Console.WriteLine($"BestScore: {bestScore}");
            Console.SetCursorPosition(Console.WindowWidth / WindowDividerByTwo - OffsetPointsLenght, Console.WindowHeight / WindowDividerByTwo + 2);
            Console.WriteLine($"-----Top5-----");
            for (int i = 1; i <= topPlayers.Length; i++)
            {
                var currenPlayer = topPlayers[i-1];
                Console.SetCursorPosition(Console.WindowWidth / WindowDividerByTwo - OffsetPointsLenght, Console.WindowHeight / WindowDividerByTwo + 2 + i);
                Console.WriteLine($"{i}. {currenPlayer.Key} -> {currenPlayer.Value}");
            }

            Console.SetCursorPosition(0,0);
        }
    }
}
