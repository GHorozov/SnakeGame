namespace Snake.Models.Snakes.Contracts
{
    using System.Collections.Generic;
    using global::Snake.Models.Positions;

    public interface ISnake
    {
        Queue<Position> Body { get; }

        int Lenght { get; }

        Position Head { get; }

        Position Tail { get; }

        void AddSegmentToSnake(Position position);

        void RemoveSegmentFromSnake();
    }
}
