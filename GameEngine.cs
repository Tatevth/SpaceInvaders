using SpaceInvaders.GameObjectFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class GameEngine
    {
        private bool _isNotOver;
        private Scene _scene;
        private SceneRender _sceneRender;

        private static GameEngine _gameEngine;
        private GameSettings _gameSettings;

        private GameEngine()
        {

        }

        public static GameEngine GetGameEngine(GameSettings gameSettings)
        {
            if (_gameEngine==null)
            {
                _gameEngine = new GameEngine(gameSettings);

            }
            return _gameEngine;
        }

        public GameEngine(GameSettings gameSettings)
        {
            _isNotOver = true;
            _scene = Scene.GetScene(gameSettings);
            _sceneRender = new SceneRender(gameSettings);
            _gameSettings = gameSettings;
        }

        public void Run()
        {
             int swarmMoveCounter = 0;
            int playerMissileCounter = 0;
            do
            {
                _sceneRender.ClearScreen();
                _sceneRender.Render(_scene);

                Thread.Sleep(_gameSettings.GameSpeed);


                if (swarmMoveCounter== _gameSettings.SwarmSpeed)
                {
                    CalculateSwarmMove();
                    swarmMoveCounter = 0;
                }
                swarmMoveCounter++;

                if (playerMissileCounter== _gameSettings.PlayerMissileSpeed)
                {
                    CalculateMissileMove();
                    playerMissileCounter = 0;
                }

                playerMissileCounter++;
            } while (_isNotOver);

            Console.ForegroundColor = ConsoleColor.Red;
            _sceneRender.RenderGameOver();
    {

            }
        }
        public void CalculateMovePlayerShipLeft()
        {
            if (_scene._playerShip.gameObjectPlace.XCoordinate > 1)
            {
                _scene._playerShip.gameObjectPlace.XCoordinate--;
            }
        }

        public void CalculateMovePlayerShipRight()
        {
            if (_scene._playerShip.gameObjectPlace.XCoordinate < _gameSettings.ConsoleWidth)
            {
                _scene._playerShip.gameObjectPlace.XCoordinate++;
            }
        }

        public void CalculateSwarmMove()
        {
            for (int i = 0; i < _scene._swarm.Count; i++)
            {
                GameObject alienShip = _scene._swarm[i];

                alienShip.gameObjectPlace.YCoordinate++;

                if (alienShip.gameObjectPlace.YCoordinate == _scene._playerShip.gameObjectPlace.YCoordinate)
                {
                    _isNotOver = false;
                }

              
            }
        }

        public void Shot()
        {

            PlayerShipMissileFactory missileFactory = new PlayerShipMissileFactory(_gameSettings);

            GameObject missile = missileFactory.GetGameObject(_scene._playerShip.gameObjectPlace) ;

            _scene._playerShipMissile.Add(missile);

            Console.Beep(1000, 200);
        }

        public void CalculateMissileMove()
        {
            if (_scene._playerShipMissile.Count==0)
            {
                return;
            }
            for (int x = 0; x < _scene._playerShipMissile.Count; x++)
            {
                GameObject missile = _scene._playerShipMissile[x];

                if (missile.gameObjectPlace.YCoordinate == 1)
                {
                    _scene._playerShipMissile.RemoveAt(x);
                }

                missile.gameObjectPlace.YCoordinate--;
                for (int i = 0; i < _scene._swarm.Count; i++)
                {
                    GameObject alienShip = _scene._swarm[i];

                    if (missile.gameObjectPlace.Equals(alienShip.gameObjectPlace))
                    {
                        _scene._swarm.RemoveAt(i);
                        _scene._playerShipMissile.RemoveAt(x);

                        break;
                    }
                }

            }
        }
    }

}
