using UnityEngine;
using UnityEngine.UI;

public class ResumeGameButton : MonoBehaviour
{
    [SerializeField] private GameObject _pauseCanvas;
    [SerializeField] private Button _resumeButton;

    private void Start()
    {
        _resumeButton.onClick.AddListener(() =>
        {
            ResumeGame();
        });
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        _pauseCanvas.SetActive(false);
    }
}
