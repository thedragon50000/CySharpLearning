using System.Collections;
using System.Collections.Generic;
using Andy.MessagePipe.Scripts._0;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using MessagePipe;
using R3;
using TMPro;
using UnityEngine.Serialization;
using Zenject;

namespace Andy.MessagePipe.Scripts._0
{
    public class PublishView : MonoBehaviour
    {
        [SerializeField] string inputMessage;
        [SerializeField] Button button;
        [SerializeField] TMP_Text text;

        // 發送者
        IPublisher<SendName_Signal> _startPublisher;

        [Inject]
        public void Construct(IPublisher<SendName_Signal> startPublisher)
        {
            _startPublisher = startPublisher;
        }

        void Awake()
        {
            button.OnClickAsObservable()
                                    // 按下按鈕 發送一個string為 inputMessage 的SendName_Signal類給訂閱者
                .Subscribe(_ => _startPublisher.Publish(new SendName_Signal { UserName = inputMessage }))
                .AddTo(this);
        }

        public void ShowMessage(string message)
        {
            text.DOText(message,2.5f);
            
            // text.text = message;
        }
    }
}