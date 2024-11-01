using Andy.Zenject_LoadScene.Scripts;
using Andy.Zenject_LoadScene.Scripts.Send;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Andy.Zenject_LoadScene.Scripts
{
    [CreateAssetMenu(fileName = "PlayerStatsSO", menuName = "Installers/PlayerStatsSO")]
    public class PlayerStatsSO : ScriptableObjectInstaller<PlayerStatsSO>
    {
        public PlayerStats playerStats;

        public override void InstallBindings()
        {
            
            Container.BindInterfacesAndSelfTo<PlayerStats>().AsSingle().IfNotBound();
            Container.BindInterfacesAndSelfTo<Tests>().AsSingle();
        }
    }
}