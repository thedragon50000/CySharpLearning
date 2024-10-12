using UnityEngine;
using System.Collections;
using R3;
using UnityEngine.UI;

namespace UniRxWorkBook.Operators
{
    public class Lesson_8_Repeat : MonoBehaviour
    {
        [SerializeField] private Text resultLabel;
        [SerializeField] private Button buttonLeft;
        [SerializeField] private Button buttonRight;

        private void Start()
        {
            var rightStream = buttonRight.OnClickAsObservable();
            var leftStream = buttonLeft.OnClickAsObservable();

            // _____を書き換え、LeftとRightを交互に1回ずつ押した時にOKが表示されるようにしよう
            // 
            // First()を外すだけではLeftとRightを連打した時の挙動が怪しいのでダメである
            // 適切なオペレータをFirstの後ろに入れよう
            leftStream
                .Zip(rightStream, (l, r) => Unit.Default)
                // Warning: 這是分開計算的，所以按兩下左再按兩下右也會成功，應避免達成一次以上
                .Take(2) //最多添加兩次"OK"
                // ._____() 
                .SubscribeToText(resultLabel, _ => resultLabel.text += "OK\n");
        }
    }
}