using System;
using UnityEngine;
using Zenject.SpaceFighter;

namespace Zenject.Asteroids
{
    public class GameInstaller : MonoInstaller
    {
        [Inject] Settings _settings = null;

        public override void InstallBindings()
        {
            // Install the main game
            InstallAsteroids();
            InstallShip();
            InstallMisc();
            InstallSignals();
            InstallExecutionOrder();
        }

        void InstallAsteroids()
        {
            //  Note: 下面兩行效果相同
            // Container.Bind(typeof(ITickable), typeof(IFixedTickable), typeof(AsteroidManager)).To<AsteroidManager>.AsSingle();
            Container.BindInterfacesAndSelfTo<AsteroidManager>().AsSingle();

            // 綁定 隕石工廠
            Container.BindFactory<Asteroid, Asteroid.Factory>()
                //Create()時會產生 _settings.AsteroidPrefab 這個Prefab
                .FromComponentInNewPrefab(_settings.AsteroidPrefab)
                // 可以命名
                .WithGameObjectName("Asteroid")
                // 創造一個父物件(可自行命名)，把所有生成的物件放到裡面以方便管理
                .UnderTransformGroup("Asteroids");
        }

        void InstallMisc()
        {
            Container.BindInterfacesAndSelfTo<GameController>().AsSingle();
            Container.Bind<LevelHelper>().AsSingle();

            Container.BindInterfacesTo<AudioHandler>().AsSingle();

            Container.BindFactory<Transform, ExplosionFactory>()
                .FromComponentInNewPrefab(_settings.ExplosionPrefab);

            Container.BindFactory<Transform, BrokenShipFactory>()
                .FromComponentInNewPrefab(_settings.BrokenShipPrefab);
        }

        // todo: 使用MessagePipe替代
        void InstallSignals()
        {
            // Every scene that uses signals needs to install the built-in installer SignalBusInstaller
            // Or alternatively it can be installed at the project context level (see docs for details)
            SignalBusInstaller.Install(Container);

            // Signals can be useful for game-wide events that could have many interested parties
            Container.DeclareSignal<ShipCrashedSignal>();
        }

        void InstallShip()
        {
            Container.Bind<ShipStateFactory>().AsSingle();

            // Note: 船的本身的Ship腳本在物件上，在場景中的物件已經新增了Zenject 內建的 ZenjectBinding 腳本
            // 拖拉一下即可設定，可實現不需Installer的自動綁定

            Container.BindFactory<ShipStateWaitingToStart, ShipStateWaitingToStart.Factory>().WhenInjectedInto<ShipStateFactory>();
            Container.BindFactory<ShipStateDead, ShipStateDead.Factory>().WhenInjectedInto<ShipStateFactory>();
            Container.BindFactory<ShipStateMoving, ShipStateMoving.Factory>().WhenInjectedInto<ShipStateFactory>();
        }

        void InstallExecutionOrder()
        {
            // 若要確保 AsteroidManager.Initialize 總是在 GameController.Initialize 之前被呼叫
            // 在()內田入參數，數字越小越優先
            Container.BindExecutionOrder<AsteroidManager>(-20);
            Container.BindExecutionOrder<GameController>(-10);

            // Note that they will be disposed of in the reverse order given here
        }

        // Note: 其實這個沒必要寫在這，不知道在想什麼
        // [Serializable]
        // public class Settings
        // {
        //     public GameObject ExplosionPrefab;
        //     public GameObject BrokenShipPrefab;
        //     public GameObject AsteroidPrefab;
        //     public GameObject ShipPrefab;
        // }
    }
}