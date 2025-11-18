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
    public class Subscriber : MonoBehaviour, IDisposable
    {
        private ISubscriber<PartyInvitation> _subscriber;

        readonly CompositeDisposable _dispose = new();
        [SerializeField] private List<Person> people = new();

        [Inject]
        public void Init(ISubscriber<PartyInvitation> subscriber)
        {
            _subscriber = subscriber;
        }

        public void Awake()
        {
            SpawnPeople();
            _subscriber.Subscribe(InvitationHandler).AddTo(_dispose);
        }

        private void SpawnPeople()
        {
            for (int i = 0; i < 20; i++)
            {
                int age = Random.Range(10, 25);
                string sex = "male";
                if (age % 2 == 0)
                {
                    sex = "female";
                }

                Person p = new Person(sex, age);
                people.Add(p);
            }
        }

        public void Dispose()
        {
            _dispose.Dispose();
        }

        private void InvitationHandler(PartyInvitation invitation)
        {
            // todo: people 年紀過大的就不邀請
            foreach (var p in people)
            {
                if (p.Sexual == invitation.Sexual)
                {
                    if (p.Age <= invitation.Age)
                    {
                        Debug.Log($"受邀，{p.Age}歲");
                    }
                }
            }
        }
    }
}