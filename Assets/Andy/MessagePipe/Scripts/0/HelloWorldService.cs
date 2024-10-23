using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using MessagePipe;
using R3;
using Zenject;

namespace Andy.MessagePipe.Scripts._0
{
    public class HelloWorldService : IInitializable, IDisposable
    {
        // 訂閱者
        readonly ISubscriber<SendName_Signal> _startSubscriber;

        // 值有變動就觸發
        readonly ReactiveProperty<string> _userNameRp = new();
        public ReadOnlyReactiveProperty<string> UserNameProperty => _userNameRp;

        readonly CompositeDisposable _disposable = new();

        [Inject]
        public HelloWorldService(ISubscriber<SendName_Signal> startSubscriber) //建構注入
        {
            _startSubscriber = startSubscriber;
        }

        public void Initialize()        //start()
        {
            _startSubscriber.Subscribe(SayHello)
                .AddTo(_disposable);
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }

        void SayHello(SendName_Signal args)
        {
            Debug.Log($"Hello {args.UserName}!");
            _userNameRp.Value = $"Hello {args.UserName}!";
        }
    }
}