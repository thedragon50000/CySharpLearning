using MessagePipe;
using Zenject;

namespace Andy.MessagePipe.Scripts._0.eroJiiJii
{
    public class Publisher
    {
        IPublisher<PartyInvitation> _publisher;

        [Inject]
        public Publisher(IPublisher<PartyInvitation> publisher)
        {
            _publisher = publisher;
        }

        public void SendInvitation()
        {
            PartyInvitation invitation = new PartyInvitation("female", 17);
            _publisher.Publish(invitation);
        }
    }
}