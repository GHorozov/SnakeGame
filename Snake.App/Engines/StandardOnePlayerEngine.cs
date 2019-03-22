namespace Snake.App.Engines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using Snake.App.Engines.Contracts;
    using Snake.App.InputProviders.Contracts;
    using Snake.App.Renderers.Contracts;
    using Snake.Models.Players.Contracts;
    using Snake.Models.Snakes.Contracts;
    using Snake.Models.Snakes;
    using Snake.App.OutputProviders.Contracts;
    using Snake.Models.Directions.Contracts;
    using Snake.Models.Directions;
    using Snake.Models.Positions;
    using Snake.Models.RamdomPositionGenerator;
    using Snake.Models.GlobalConstants;
    using Snake.Data.Data.Contracts;

    public class StandardOnePlayerEngine : IEngine
    {
        private IData data;
        private List<IPlayer> players;
        private IPlayer currentPlayer;
        private ISnake snake;
        private IInputProvider inputProvider;
        private IOutputProvider outputProvider;
        private IRenderer renderer;
        private IDirection direction;
        private int currentDirection;
        private RandomGenerator randomGenerator;
        private int sleepTime;

        public StandardOnePlayerEngine(IInputProvider inputProvider, IOutputProvider outputProvider, IRenderer renderer, IData data)
        {
            this.players = new List<IPlayer>();
            snake = new Snake();
            this.inputProvider = inputProvider;
            this.outputProvider = outputProvider;
            this.direction = new Direction();
            this.randomGenerator = new RandomGenerator();
            this.RandomPosition = this.randomGenerator.GetRandomPosition();
            this.sleepTime = 100;
            this.data = data;
            this.renderer = renderer;
        }

        public IReadOnlyCollection<IPlayer> Players => this.players.AsReadOnly();

        public Position RandomPosition { get; private set; }

        public void Initialize(IGameInitializationStrategy gameInitializationStrategy)
        {
            while (true)
            {
                if (this.Players.Count > 0) break;
                try
                {
                    this.players = this.inputProvider.GetPlayers(1);
                    this.currentPlayer = players.First();
                    gameInitializationStrategy.Initialize(this.players, this.snake);
                    this.renderer.RenderGame(this.snake);
                    this.renderer.RenderSnakeFood(this.RandomPosition);
                }
                catch (ArgumentException ex)
                {
                    this.outputProvider.WriteLine(ex.Message);
                    Thread.Sleep(2000);
                }
            }
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    if (Console.KeyAvailable)
                    {
                        var input = this.inputProvider.ReadKey();
                        if (input.Key == ConsoleKey.RightArrow)
                        {
                            if (this.currentDirection != Constants.Left)
                            {
                                this.currentDirection = Constants.Right;
                            }
                        }
                        else if (input.Key == ConsoleKey.LeftArrow)
                        {
                            if (this.currentDirection != Constants.Right)
                            {
                                this.currentDirection = Constants.Left;
                            }
                        }
                        else if (input.Key == ConsoleKey.DownArrow)
                        {
                            if (this.currentDirection != Constants.Up)
                            {
                                this.currentDirection = Constants.Down;
                            }
                        }
                        else if (input.Key == ConsoleKey.UpArrow)
                        {
                            if (this.currentDirection != Constants.Down)
                            {
                                this.currentDirection = Constants.Up;
                            }
                        }
                    }

                    var snakeHead = this.snake.Head;
                    var newDirection = this.direction.Directions[this.currentDirection];
                    var newSnakeHead = new Position(snakeHead.X + newDirection.X, snakeHead.Y + newDirection.Y);
                    Position.ValidatePosition(this.snake, newSnakeHead);
                    this.snake.AddSegmentToSnake(newSnakeHead);
                    var bestPlayer = this.data.ReturnBestPlayer();
                    var bestScore = "0";
                    
                    if (bestPlayer.Key != null)
                    {
                        bestScore = $"{bestPlayer.Value}";
                    }
                    renderer.RenderNewSnakeHead(this.currentPlayer, newSnakeHead, bestScore);

                    if (newSnakeHead.X == this.RandomPosition.X && newSnakeHead.Y == this.RandomPosition.Y)
                    {
                        this.RandomPosition = this.randomGenerator.GetRandomPosition();
                        this.currentPlayer.AddPoints(Constants.PointsConst);
                        this.sleepTime--;
                    }
                    else
                    {
                        this.renderer.RenderRemovalOfTail(this.snake.Tail);
                        this.snake.RemoveSegmentFromSnake();
                    }

                    this.renderer.RenderSnakeFood(this.RandomPosition);
                    Thread.Sleep(this.sleepTime);

                }
                catch (Exception ex)
                {
                    this.data.AddNewData(this.currentPlayer.Name, this.currentPlayer.Points);
                    this.outputProvider.WriteLine(ex.Message);
                    var bestPlayer = this.data.ReturnBestPlayer();
                    var bestScore = "0";
                    if (bestPlayer.Key != null)
                    {
                        bestScore = $"{bestPlayer.Key} => {bestPlayer.Value}";
                    }
                    var topPlayers = this.data.ReturnTopFivePlayers();
                    this.renderer.RenderFinalResults(this.currentPlayer, bestScore, topPlayers);
                    Environment.Exit(0);
                }
            }
        }
    }
}
