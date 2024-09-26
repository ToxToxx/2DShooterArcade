using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private Button _changeSceneButton;
    [SerializeField] private Loader.Scene _concreteScene;
    private void LoadGame()
    {
        Loader.Load(_concreteScene);
        Time.timeScale = 1.0f;
    }

    private void OnEnable()
    {
        if (_changeSceneButton != null)
        {
            _changeSceneButton.onClick.AddListener(LoadGame);
        }
        else
        {
            Debug.LogError("No scene is existing");
        }
    }

    private void OnDisable()
    {
        if (_changeSceneButton != null)
        {
            _changeSceneButton.onClick.RemoveListener(LoadGame);
        }
    }
}
