using UnityEngine;
using Zenject;

namespace Andy.Zenject_LoadScene.Scripts.Send
{
    public class Tests : IInitializable
    {
        public void Initialize()
        {
            Debug.Log("Tests Created");
        }
    }
}