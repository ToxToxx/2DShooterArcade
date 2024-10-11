using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float _speed = 0.5f;

    private Material _material;
    private Vector2 _offset;

    void Start()
    {
        _material = GetComponent<SpriteRenderer>().material;

        _offset = new Vector2(_speed, 0);
    }

    void Update()
    {
        _material.mainTextureOffset += _offset * Time.deltaTime;
    }
}
