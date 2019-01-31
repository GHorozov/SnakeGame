namespace Snake.Models.Directions
{
    using Snake.Models.Directions.Contracts;
    using Snake.Models.Positions;

    public class Direction : IDirection
    {
        public Direction()
        {
            this.Directions = new Position[4]
            {
                new Position(0, 1),  //right
                new Position(0, -1), //left
                new Position(1, 0),  //down
                new Position(-1, 0), //up
            };
        }

        public Position[] Directions { get; private set; }
    }
}
