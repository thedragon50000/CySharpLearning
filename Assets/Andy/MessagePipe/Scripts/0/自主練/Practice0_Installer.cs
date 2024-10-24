using UnityEngine;
using Zenject;
using MessagePipe;

public class Practice0_Installer : MonoInstaller
{
    public override void InstallBindings()
    {
        MessagePipeOptions option = Container.BindMessagePipe();
        Container.BindMessageBroker<NoiseSingnal>(option);

        Container.Bind<Publisher>().FromComponentsInHierarchy().AsSingle();
        Container.Bind<Subscriber>().FromComponentsInHierarchy().AsSingle();
        
    }
}