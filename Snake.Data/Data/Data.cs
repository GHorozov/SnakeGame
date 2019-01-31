namespace Snake.Data.Data
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Snake.Data.Data.Contracts;

    public class Data : IData
    {
        private string filePath = "./../../scores.txt";
        private Dictionary<string, int> players;

        public Data()
        {
            this.players = new Dictionary<string, int>();
        }

        public void AddNewData(string name, int points)
        {
            if (!File.Exists(filePath))
            {
                var file = File.Create(filePath);
                file.Close();
            }
            else
            {
                if (!players.ContainsKey(name))
                {
                    players.Add(name, points);
                    File.AppendAllLines(filePath, new List<string>() { $"{name}:{ points.ToString()}" });
                }
                else
                {
                    var currentValue = players[name];
                    if (currentValue < points)
                    {
                        players[name] = points;
                        var lines = new List<string>() { $"{name}:{ points.ToString()}" };
                        File.AppendAllLines(filePath, lines);
                    }
                }
            }
        }

        public KeyValuePair<string, int> ReturnBestScore()
        {
            if (!File.Exists(filePath))
            {
                var file = File.Create(filePath);
                file.Close();
            }

            var allLines = File.ReadAllLines(filePath);
            foreach (var line in allLines)
            {
                var input = line.Split(":");
                var name = input[0];
                var points = int.Parse(input[1]);

                if (!players.ContainsKey(name))
                {
                    
                }

                players[name] = points;
            }

            KeyValuePair<string, int> bestResult = players.OrderByDescending(x => x.Value).FirstOrDefault();

            return bestResult;
        }

        public KeyValuePair<string, int>[] ReturnTopFivePlayers()
        {
            var result = this.players.OrderByDescending(x => x.Value).Take(5).ToArray();

            return result;
        }
    }
}
