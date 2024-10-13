using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private TimeManager _timeManager;
    private void Update()
    {
        _timerText.text = _timeManager.GetElapsedTime().ToString("F1");
    }
}
