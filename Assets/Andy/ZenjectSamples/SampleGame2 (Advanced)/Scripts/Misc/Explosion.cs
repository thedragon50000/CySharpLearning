using System;
using UnityEngine;
using R3;

#pragma warning disable 649

namespace Zenject.SpaceFighter
{
    public class Explosion : MonoBehaviour, IPoolable<IMemoryPool>
    {
        [SerializeField] float _lifeTime;

        [SerializeField] ParticleSystem _particleSystem;

        float _startTime;

        IMemoryPool _pool;

        // public void Update()
        // {
        //     if (Time.realtimeSinceStartup - _startTime > _lifeTime)
        //     {
        //         _pool.Despawn(this);
        //     }
        // }

        public void Start()
        {
            Observable.Timer(TimeSpan.FromSeconds(_lifeTime)).Subscribe(_ => _pool.Despawn(this));
        }

        public void OnDespawned()
        {
            print("OnDespawned();");
        }

        public void OnSpawned(IMemoryPool pool)
        {
            _particleSystem.Clear();
            _particleSystem.Play();

            _startTime = Time.realtimeSinceStartup;
            _pool = pool;
        }

        public class Factory : PlaceholderFactory<Explosion>
        {
        }
    }
}