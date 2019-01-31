namespace Snake.App.InputProviders
{
    using System;
    using System.Collections.Generic;
    using Snake.App.ConsoleHelpers;
    using Snake.App.InputProviders.Contracts;
    using Snake.Models.Players;
    using Snake.Models.Players.Contracts;

    public class ConsoleInputProvider : IInputProvider
    {
        private const string PlayerNameText = "Enter Player name: ";

        public ConsoleKeyInfo ReadKey()
        {
            var input = Console.ReadKey();

            return input;
        }

        public List<IPlayer> GetPlayers(int numberOfPlayers)
        {
            var players = new List<IPlayer>();

            for (int i = 0; i < numberOfPlayers; i++)
            {
                Console.Clear();
                ConsoleHelper.SetCursorAtCenter(PlayerNameText.Length);
                Console.Write(PlayerNameText);
                var name = Console.ReadLine();
                var player = new Player(name);
                players.Add(player);
                Console.Clear();
            }

            return players;
        }
    }
}
