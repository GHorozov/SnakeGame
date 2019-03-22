namespace Snake.App.Engines.Contracts
{
    using System.Collections.Generic;
    using Snake.Models.Players.Contracts;
    using Snake.Models.Snakes.Contracts;

    public interface IGameInitializationStrategy
    {
        void Initialize(IList<IPlayer> players, ISnake snake);
    }
}
