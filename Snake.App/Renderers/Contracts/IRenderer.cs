namespace Snake.App.Renderers.Contracts
{
    using Snake.Models.Players.Contracts;
    using Snake.Models.Positions;
    using Snake.Models.Snakes.Contracts;
    using System.Collections.Generic;

    public interface IRenderer
    {
        void RenderMainMenu();

        void RenderGame(ISnake snake);

        void RenderSnakeFood(Position position);

        void RenderNewSnakeHead(IPlayer player, Position newsnakeHead, string bestScore);

        void RenderRemovalOfTail(Position snakeTail);

        void RenderFinalResults(IPlayer player, string bestScore, KeyValuePair<string, int>[] topPlayers);
    }
}
