namespace Snake.App.Engines.Initializations
{
    using System;
    using System.Collections.Generic;
    using Snake.App.Engines.Contracts;
    using Snake.Models.Players.Contracts;
    using Snake.Models.Positions;
    using Snake.Models.Snakes.Contracts;

    public class StandardGameInitializationStrategy : IGameInitializationStrategy
    {
        private const int StandardGameNumberOfPlayers = 1;
        private const int InitialSnakeLenght = 5;
        private const int SnakeStartPointCol = 2; 

        public void Initialize(IList<IPlayer> players, ISnake snake)
        {
            this.ValidatePlayers(players);

            for (int i = 1; i <= InitialSnakeLenght; i++)
            {
                var position = new Position(SnakeStartPointCol, i);
                snake.AddSegmentToSnake(position);
            }
        }

        private void ValidatePlayers(IList<IPlayer> players)
        {
            if(players.Count != StandardGameNumberOfPlayers)
            {
                throw new InvalidOperationException("Standard number of players in snake game is one!");
            }
        }
    }
}
