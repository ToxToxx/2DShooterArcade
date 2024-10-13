using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private float _elapsedTime; 

    void Update()
    {
        _elapsedTime += Time.deltaTime; 
    }

    public float GetElapsedTime()
    {
        return _elapsedTime; 
    }
}
