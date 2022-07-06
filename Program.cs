using System;
using System.Threading;

namespace SpaceInvaders
{
    class Program
    {
        static GameEngine gameEngine;

        static GameSettings GameSettings;

        static UIController UIController;

        static MusicController MusicController;
        
        static void Main(string[] args)
        {
            Initialize();

          gameEngine.Run();
        }

        public static void Initialize()
        {
            GameSettings = new GameSettings();

            gameEngine = GameEngine.GetGameEngine(GameSettings);

            UIController = new UIController();

            UIController.OnAPressed += (obj, arg) => gameEngine.CalculateMovePlayerShipLeft();
            UIController.OnDPressed += (obj, arg) => gameEngine.CalculateMovePlayerShipRight();
            UIController.OnSpacePressed += (obj,arg) => gameEngine.Shot();
            Thread uIthread = new Thread(UIController.StartListening);

            uIthread.Start();
            Thread.CurrentThread.Priority = ThreadPriority.AboveNormal;

            MusicController = new MusicController();
            Thread musicThread = new Thread(MusicController.PlayBackgroundMusic);
            musicThread.Start();

             
        }
    }
}
