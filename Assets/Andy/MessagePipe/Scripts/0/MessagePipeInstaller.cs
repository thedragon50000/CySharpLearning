using Zenject;
using MessagePipe;

namespace Andy.MessagePipe.Scripts._0
{
    public class MessagePipeInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            /*
            使用 BindMessageBroker() 的好处
            解耦：对象之间不需要直接引用，可以通过 MessageBroker 传递消息，减少耦合。
            方便管理：可以集中处理消息的发布和订阅，提高代码的可维护性。
            灵活配置：可以为不同类型的消息绑定多个 MessageBroker，适应不同的需求。
                结论
            BindMessageBroker() 是一种将消息发布/订阅模式与依赖注入结合的方法，能够简化事件驱动的应用程序开发。通过在 Zenject 容器中绑定 MessageBroker，开发者可以轻松管理消息传递和对象间的通信。
             */
            // Signal
            var option = Container.BindMessagePipe();
            Container.BindMessageBroker<SendName_Signal>(option);
            
            // Service
            Container.BindInterfacesAndSelfTo<HelloWorldService>().AsSingle();
            // View
            // Note: 在Hierarchy尋找腳本，是遍歷? 消耗資源嗎?
            Container.Bind<PublishView>().FromComponentInHierarchy().AsCached();
            // // Presenter
            Container.BindInterfacesAndSelfTo<PubSubPresenter>().AsSingle();

        }
    }
}