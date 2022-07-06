using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.GameObjectFactories
{
    class PlayerShipFactory : GameObjectFactory
    {
        public PlayerShipFactory(GameSettings gameSettings): base(gameSettings)
        {

        }
        public override GameObject GetGameObject(GameObjectPlace objectPlace) 
        {
           
            GameObject gameObject = new PlayerShip() { Figure = GameSettings.PlayerShip, gameObjectPlace = objectPlace, gameObjectType = GameObjectType.PlayerShip };
            return gameObject;
        }

        public GameObject GetGameObject()
        {
            GameObjectPlace place = new GameObjectPlace() { XCoordinate = GameSettings.PlayerShipStartXcoordinate, YCoordinate = GameSettings.PlayerShipStartYcoordinate };
            GameObject gameObject = GetGameObject(place);
            return gameObject;
        }
    }
}
