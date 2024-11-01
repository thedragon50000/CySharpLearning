using System;
using UnityEngine;
using Zenject;

namespace Andy.Zenject_LoadScene.Scripts.Send
{
    [Serializable]
    public class PlayerStats : IInitializable
    {
        public float HpValue = 0;

        public void Initialize()
        {
            Debug.Log("PlayerStats created. ");
        }
    }
}