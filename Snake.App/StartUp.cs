namespace Snake.App
{
    using System;
    using Snake.App.Engines;
    using Snake.App.Engines.Contracts;
    using Snake.App.Engines.Initializations;
    using Snake.App.InputProviders;
    using Snake.App.InputProviders.Contracts;
    using Snake.App.OutputProviders;
    using Snake.App.OutputProviders.Contracts;
    using Snake.App.Renderers;
    using Snake.App.Renderers.Contracts;
    using Snake.Data.Data.Contracts;
    using Snake.Data.Data;

    public class StartUp
    {
        static void Main(string[] args)
        {
            IData data = new Data();
            IRenderer renderer = new ConsoleRenderer();
            IInputProvider inputProvider = new ConsoleInputProvider();
            IOutputProvider outputProvider = new ConsoleOutputProvider();
            IGameInitializationStrategy gameInitializationStrategy = new StandardGameInitializationStrategy();

            var engine = new StandardOnePlayerEngine(inputProvider, outputProvider, renderer, data);

            renderer.RenderMainMenu();
            engine.Initialize(gameInitializationStrategy);
            engine.Run();
        }
    }
}
