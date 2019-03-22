namespace Snake.App.OutputProviders
{
    using System;
    using Snake.App.OutputProviders.Contracts;

    public class ConsoleOutputProvider : IOutputProvider
    {
        public void WriteLine(string text)
        {
            ConsoleHelpers.ConsoleHelper.SetCursorAtCenter(text.Length);
            Console.WriteLine(text);
        }
    }
}
