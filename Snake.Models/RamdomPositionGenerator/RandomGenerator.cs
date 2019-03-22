namespace Snake.Models.RamdomPositionGenerator
{
    using System;
    using Snake.Models.GlobalConstants;
    using Snake.Models.Positions;

    public class RandomGenerator
    {
        private Random random;

        public RandomGenerator()
        {
            this.random = new Random();
        }

        public Position GetRandomPosition()
        {
            var position = new Position(
                this.random.Next(Constants.FrameworkBorderSideFour, Console.WindowHeight - Constants.FrameworkBorderSideFour),
                this.random.Next(Constants.FrameworkBorderSideThree, Console.WindowWidth - Constants.FrameworkBorderSideThree)
                );

            return position;
        }
    }
}
