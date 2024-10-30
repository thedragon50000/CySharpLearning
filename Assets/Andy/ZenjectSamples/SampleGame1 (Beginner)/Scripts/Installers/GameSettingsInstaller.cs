using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Zenject.Asteroids
{
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {
        public ShipSettings Ship;
        public AsteroidSettings Asteroid;
        public AudioHandler.Settings AudioHandler;
        public Settings GameInstaller;

        // We use nested classes here to group related settings together
        [Serializable]
        public class ShipSettings
        {
            public ShipStateMoving.Settings StateMoving;
            public ShipStateDead.Settings StateDead;
            public ShipStateWaitingToStart.Settings StateStarting;
        }

        [Serializable]
        public class AsteroidSettings
        {
            public AsteroidManager.Settings Spawner;
            public Asteroid.Settings General;
        }

        public override void InstallBindings()
        {
            Container.BindInstance(Ship.StateMoving);
            Container.BindInstance(Ship.StateDead);
            Container.BindInstance(Ship.StateStarting);
            Container.BindInstance(Asteroid.Spawner);
            Container.BindInstance(Asteroid.General);
            Container.BindInstance(AudioHandler);
            // Container.BindInstance(GameInstaller);
            Container.BindInstance(GameInstaller);
        }
    }
    [Serializable]
    public class Settings
    {
        public GameObject ExplosionPrefab;
        public GameObject BrokenShipPrefab;
        public GameObject AsteroidPrefab;
        public GameObject ShipPrefab;
    }
}

