using UnityEngine;
using Zenject;

namespace Andy.MessagePipe.Scripts._0.eroJiiJii
{
    public class EroJiiJiiManager : MonoBehaviour
    {
        [Inject] private Publisher publisher;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            publisher.SendInvitation();
        }
    }
}