namespace Snake.Data.Data.Contracts
{
    using System.Collections.Generic;

    public interface IData
    {
        void AddNewData(string name, int points);

        KeyValuePair<string, int> ReturnBestPlayer();

        KeyValuePair<string, int>[] ReturnTopFivePlayers();
    }
}
