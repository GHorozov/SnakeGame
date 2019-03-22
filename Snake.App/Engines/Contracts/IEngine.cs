namespace Snake.App.Engines.Contracts
{
    using System.Collections.Generic;
    using Snake.Models.Players.Contracts;

    public interface IEngine
    {
        IReadOnlyCollection<IPlayer> Players { get; }

        void Initialize(IGameInitializationStrategy gameInitializationStrategy);

        void Run();
    }
}
