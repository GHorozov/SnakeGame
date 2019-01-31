namespace Snake.Models.Players.Contracts
{
    public interface IPlayer
    {
        string Name { get; }

        int Points { get; }

        void AddPoints(int points);
    }
}
