using System;
using System.Collections;
using System.Collections.Generic;
using MessagePipe;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

/// <summary>
/// 發送訊息者
/// </summary>
public class Publisher : MonoBehaviour
{
    private IPublisher<NoiseSingnal> _publisher;
    [SerializeField] private GameObject player;

    [Inject]
    void SetupZenject(IPublisher<NoiseSingnal> pub)
    {
        _publisher = pub;
    }

    private void Awake()
    {
        // 發送一個距離500內都會注意到的槍聲
        _publisher.Publish(new NoiseSingnal { Type = "槍聲", Distance = 500, Position = player.transform.position });
    }
}