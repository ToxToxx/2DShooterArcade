using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private PlayerStatsModel _playerStatsModel;
    [SerializeField] private PlayerHealthController _healthController;
    [SerializeField] private Image _heartPrefab; 
    [SerializeField] private int _initialPoolSize = 10; 

    private List<Image> _hearts = new List<Image>();
    private Queue<Image> _heartPool = new Queue<Image>(); 

    private void Start()
    {
        InitializeHealthUIPool();
        UpdateHealthUI(null, null); 
    }

    private void InitializeHealthUIPool()
    {
        for (int i = 0; i < _initialPoolSize; i++)
        {
            Image heart = CreateHeart();
            _heartPool.Enqueue(heart);
            heart.gameObject.SetActive(false);
        }
    }

    private Image CreateHeart()
    {
        Image heartImage = Instantiate(_heartPrefab, transform); 
        heartImage.transform.localScale = Vector3.one; 
        return heartImage;
    }

    private void UpdateHealthUI(object sender, System.EventArgs e)
    {
        int currentHealth = _playerStatsModel.PlayerHealth;

        for (int i = 0; i < currentHealth; i++)
        {
            if (i >= _hearts.Count) 
            {
                if (_heartPool.Count > 0) 
                {
                    Image heart = _heartPool.Dequeue();
                    heart.gameObject.SetActive(true);
                    _hearts.Add(heart);
                }
                else 
                {
                    Image heart = CreateHeart();
                    _hearts.Add(heart);
                }
            }
            _hearts[i].enabled = true; 
        }

        for (int i = currentHealth; i < _hearts.Count; i++)
        {
            _hearts[i].enabled = false;
            _hearts[i].gameObject.SetActive(false); 
            _heartPool.Enqueue(_hearts[i]);
            _hearts.RemoveAt(i);
            i--; 
        }
    }

    private void OnEnable()
    {
        _healthController.OnHealthChanged += UpdateHealthUI;
    }

    private void OnDisable()
    {
        _healthController.OnHealthChanged -= UpdateHealthUI;
    }
}
