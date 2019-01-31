namespace Snake.Models.Directions.Contracts
{
    using Snake.Models.Positions;

    public interface IDirection
    {
        Position[] Directions { get; }
    }
}
