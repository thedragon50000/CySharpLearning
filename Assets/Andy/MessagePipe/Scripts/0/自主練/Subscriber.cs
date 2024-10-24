using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MessagePipe;
using R3;
using UnityEngine.Serialization;
using Zenject;

public class Subscriber : MonoBehaviour, IDisposable
{
    private ISubscriber<NoiseSingnal> _subscriber;
    public GameObject[] enemies;

    readonly CompositeDisposable _dispose = new();

    [Inject]
    void SetupZenject(ISubscriber<NoiseSingnal> sub)
    {
        _subscriber = sub;
    }

    private void Awake()
    {
        _subscriber.Subscribe(EnemiesNoticeYou).AddTo(_dispose);
    }

    public void EnemiesNoticeYou(NoiseSingnal args)
    {
        foreach (GameObject o in enemies)
        {
            if (Vector3.Distance(o.transform.position, args.Position) < args.Distance) // 玩家發出的噪音影響範圍超過玩家與敵人的距離
            {
                Debug.Log($"{o.name} has noticed the noise which is {args.Type}!");
            }
            else
            {
                Debug.Log($"{o.name} 沒聽到 {args.Type}!");
            }
        }
    }

    public void Dispose()
    {
        _dispose.Dispose();
    }
}