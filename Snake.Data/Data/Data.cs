namespace Snake.Data.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using Snake.Data.Data.Contracts;

    public class Data : IData
    {
        private string filePath = "./../../scores.txt";
        private Dictionary<string, int> players;

        public Data()
        {
            this.players = new Dictionary<string, int>();
            this.players = GetReultsFromFile();
        }

        public void AddNewData(string name, int points)
        {
            if (!File.Exists(filePath))
            {
                var file = File.Create(filePath);
                file.Close();
            }

            if (!this.players.ContainsKey(name))
            {
                this.players[name] = 0;
            }

            this.players[name] = points;

            string stringResult = $"{name}:{points}" + Environment.NewLine;
            File.AppendAllText(filePath, stringResult);
        }

        public KeyValuePair<string, int> ReturnBestPlayer()
        {
            var bestPlayer = this.players.OrderByDescending(x => x.Value).First();

            return bestPlayer;
        }

        public KeyValuePair<string, int>[] ReturnTopFivePlayers()
        {
            var orderResults = this.players.OrderByDescending(x => x.Value).Take(5).ToArray();

            return orderResults;
        }

        private Dictionary<string, int> GetReultsFromFile()
        {
            var resultDict = new Dictionary<string, int>();
            if (this.players.Count == 0)
            {
                if (File.Exists(filePath))
                {
                    var lines = File.ReadAllLines(filePath);
                    foreach (var line in lines)
                    {
                        var parts = line.Split(":");
                        var name = parts[0];
                        var points = int.Parse(parts[1]);

                        if (!resultDict.ContainsKey(name))
                        {
                            resultDict[name] = 0;
                        }

                        resultDict[name] = points;
                    }
                }
            }

            return resultDict;
        }
    }
}
