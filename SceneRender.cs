using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class SceneRender
    {
        int _screenWidth;
        int _screenHeight;

        char[,] _screenMatrix;

        public SceneRender(GameSettings gameSettings)
        {
            _screenWidth = gameSettings.ConsoleWidth ;
            _screenHeight = gameSettings.ConsoleHeight;
            _screenMatrix = new char[gameSettings.ConsoleHeight, gameSettings.ConsoleWidth];

            Console.WindowHeight = gameSettings.ConsoleHeight;
            Console.WindowWidth = gameSettings.ConsoleWidth;

            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);

        }

        public void Render (Scene scene)
        {
            Console.SetCursorPosition(0, 0);

            AddListForRendering(scene._swarm);
            AddListForRendering(scene._ground);
            AddListForRendering(scene._playerShipMissile);

            AddGameObjectForRendering(scene._playerShip);

            StringBuilder stringBuilder = new StringBuilder();

            for (int y = 0; y < _screenHeight; y++)
            {
                for (int x = 0; x < _screenWidth; x++)
                {
                    stringBuilder.Append(_screenMatrix[y, x]);
                }
                stringBuilder.Append(Environment.NewLine);
            }
            Console.WriteLine(stringBuilder.ToString());
            Console.SetCursorPosition(0, 0);
        }

        public void AddGameObjectForRendering(GameObject gameObject)
        {
            if (gameObject.gameObjectPlace.YCoordinate<_screenMatrix.GetLength(0) && 
                gameObject.gameObjectPlace.XCoordinate< _screenMatrix.GetLength(1))
            {
                _screenMatrix[gameObject.gameObjectPlace.YCoordinate, gameObject.gameObjectPlace.XCoordinate] = gameObject.Figure;
            }
            else
            {
                ;// _screenMatrix[gameObject.gameObjectPlace.YCoordinate, gameObject.gameObjectPlace.XCoordinate] = ' ';
            }

        }

        public void AddListForRendering(List<GameObject> gameObjects)
        {
            foreach (GameObject gameobject in gameObjects)
            {
                AddGameObjectForRendering(gameobject);
            }
        }

        public void ClearScreen()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int y = 0; y < _screenHeight; y++)
            {
                for (int x = 0; x < _screenWidth; x++)
                {
                    _screenMatrix[y, x] = ' ';
                    //stringBuilder.Append(' ');
                }
                stringBuilder.Append(Environment.NewLine);
            }
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(stringBuilder.ToString());
        }

        public void RenderGameOver()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Game Over !!!!!");
            Console.WriteLine(stringBuilder.ToString()); 
        }
    }
}
