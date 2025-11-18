using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Andy.Zenject_LoadScene1.Scripts
{
    public class PreManager : MonoBehaviour
    {
        public GameObject plane;

        [Inject] ZenjectSceneLoader sceneLoader;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("毀了飛機！");

                plane.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                bool b = plane.activeSelf;
                LastSceneSettings settings = new LastSceneSettings(b);
                sceneLoader.LoadScene("lastScene", LoadSceneMode.Single, container => container.BindInstance(settings));
            }
        }
    }
}