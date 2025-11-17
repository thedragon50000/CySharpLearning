using System;
using UnityEngine;
using System.Collections.Generic;
using MessagePipe;
using R3;
using Zenject;
using DisposableBag = MessagePipe.DisposableBag;
using Random = UnityEngine.Random;

namespace Andy.MessagePipe.Scripts._0.eroJiiJii
{
    public class Subscriber : MonoBehaviour,IDisposable
    {
        private readonly ISubscriber<PartyInvitation> _subscriber;

        readonly CompositeDisposable _dispose = new();
        List<Person> people = new();

        public Subscriber(ISubscriber<PartyInvitation> subscriber)
        {
            _subscriber = subscriber;
        }

        public void Start()
        {
            SpawnPeople();
            _subscriber.Subscribe(InvitationHandler).AddTo(_dispose);
        }

        private void SpawnPeople()
        {
            // todo: 總之生出20個人左右，存入people裡面
            Random.Range(10, 50);
        }

        public void Dispose()
        {
            _dispose.Dispose();
        }

        private void InvitationHandler(PartyInvitation invitation)
        {
            // todo: people 年紀過大的就不邀請
        }
    }
}