using MessagePipe;
using Zenject;

namespace Andy.MessagePipe.Scripts._0.eroJiiJii
{
    public partial class EroJiiJiiInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            MessagePipeOptions option = Container.BindMessagePipe();
            Container.BindMessageBroker<PartyInvitation>(option);

            Container.Bind<Subscriber>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<Publisher>().AsSingle();
        }
    }
}