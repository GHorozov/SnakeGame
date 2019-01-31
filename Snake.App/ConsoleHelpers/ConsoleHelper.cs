namespace Snake.App.ConsoleHelpers
{
    using System;

    public static class ConsoleHelper
    {
        public static void SetCursorAtCenter(int textLenght)
        {
            var centerRow = Console.WindowHeight / 2;
            var centerCol = Console.WindowWidth / 2 - (textLenght / 2);
            Console.SetCursorPosition(centerCol, centerRow);
        }
    }
}
