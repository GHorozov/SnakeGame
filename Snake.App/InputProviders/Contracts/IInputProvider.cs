namespace Snake.App.InputProviders.Contracts
{
    using System;
    using System.Collections.Generic;
    using Snake.Models.Players.Contracts;

    public interface IInputProvider
    {
        List<IPlayer> GetPlayers(int numberOfPlayers);

        ConsoleKeyInfo ReadKey();
    }
}
