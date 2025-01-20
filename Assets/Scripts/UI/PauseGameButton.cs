using UnityEngine;
using UnityEngine.UI;

public class PauseGameButton : MonoBehaviour
{
    [SerializeField] private GameObject _pauseCanvas;
    [SerializeField] private Button _pauseButton;

    private void Start()
    {
        _pauseCanvas.SetActive(false);
        _pauseButton.onClick.AddListener(() =>
        {
            PauseGame();
        });
    }

    public void PauseGame()
    {
        Time.timeScale = 0f; 
        _pauseCanvas.SetActive(true); 
    }
}
