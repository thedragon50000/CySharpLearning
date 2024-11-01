using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Andy.Zenject_LoadScene.Scripts.Send;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using R3;
using UnityEngine.SceneManagement;

public class SendHP2NextScene : MonoBehaviour
{
    public TMP_InputField InputField;
    public Button btn;
    public PlayerStats tempStat = new();
    [Inject] public ZenjectSceneLoader SceneLoader;

    void Start()
    {
        btn.onClick.AddListener(delegate
        {
            float i = float.Parse(InputField.text);
            tempStat.HpValue = i;
            // Bug: container.BindInstance(tempStat) 抓不到正確的型別
            // SceneLoader.LoadScene("NextScene", LoadSceneMode.Single, container => container.BindInstance(tempStat));
            try
            {
                SceneLoader.LoadScene("NextScene", LoadSceneMode.Single,
                    container => container.Bind<PlayerStats>().FromInstance(tempStat));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
    }
}