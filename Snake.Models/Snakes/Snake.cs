namespace Snake.Models.Snakes
{
    using System.Collections.Generic;
    using System.Linq;
    using global::Snake.Models.Positions;
    using global::Snake.Models.Snakes.Contracts;

    public class Snake : ISnake
    {
        public Snake()
        {
            this.Body = new Queue<Position>();
        }

        public Queue<Position> Body { get; private set; }

        public int Lenght => this.Body.Count;

        public Position Head => this.Body.Last();

        public Position Tail => this.Body.Peek();

        public void AddSegmentToSnake(Position position)
        {
            this.Body.Enqueue(position);
        }

        public void RemoveSegmentFromSnake()
        {
            this.Body.Dequeue();
        }
    }
}
