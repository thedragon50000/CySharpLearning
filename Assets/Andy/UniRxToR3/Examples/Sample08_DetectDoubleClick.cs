using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using R3;
using UnityEngine;

namespace UniRx.Examples
{
    public class Sample08_DetectDoubleClick : MonoBehaviour
    {
        void Start()
        {
            // Global event handling is very useful.
            // UniRx can handle there events.
            // Observable.EveryUpdate/EveryFixedUpdate/EveryEndOfFrame
            // Observable.EveryApplicationFocus/EveryApplicationPause
            // Observable.OnceApplicationQuit

            // This DoubleCLick Sample is from
            // The introduction to Reactive Programming you've been missing
            // https://gist.github.com/staltz/868e7e9bc2a7b8c1f754

            var clickStream = Observable.EveryUpdate()
                .Where(_ => Input.GetMouseButtonDown(0));

            clickStream.Chunk(clickStream.ThrottleFirst(TimeSpan.FromMilliseconds(250)))
                .Scan(0, (count, e) => count+=1)
                .Where(count => count >= 2)
                .Subscribe(count => Debug.Log("DoubleClick Detected! Count:" + count));
        }
    }
}