using MessagePipe;
using UnityEngine;
using Zenject;

namespace Andy.MessagePipe.Scripts._0.eroJiiJii
{
    public class Publisher
    {
        IPublisher<PartyInvitation> _publisher;

        [Inject]
        public Publisher(IPublisher<PartyInvitation> publisher)
        {
            Debug.Log("publisher created");

            _publisher = publisher;
        }

        public void SendInvitation()
        {
            Debug.Log("Sending invitation");

            PartyInvitation invitation = new PartyInvitation("female", 17);
            _publisher.Publish(invitation);
        }
    }
}