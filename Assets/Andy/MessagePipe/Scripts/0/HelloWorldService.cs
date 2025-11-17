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
        private readonly ReactiveProperty<string> _userNameRp = new();
        public ReadOnlyReactiveProperty<string> UserNameProperty => _userNameRp;

        readonly CompositeDisposable _disposable = new();

        [Inject]
        public HelloWorldService(ISubscriber<SendName_Signal> startSubscriber) //建構注入
        {
            _startSubscriber = startSubscriber;
        }

        public void Initialize() //start()
        {
            // Note: AddTo() 並不是 ISubscriber 的一部分，它也不來自 MessagePipe。它是一個來自 R3，專門針對 IDisposable 介面設計的工具。
            //  因為 MessagePipe 恰好回傳了 IDisposable，所以 R3 的 AddTo() 就能夠無縫地作用在 MessagePipe 的訂閱結果上，實現跨函式庫的資源集中管理。這是一種非常優雅且常見的設計模式。
            _startSubscriber.Subscribe(SayHello).AddTo(_disposable);
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