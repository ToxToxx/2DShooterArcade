using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    public EnemyStatsSO EnemyStats;
    [SerializeField] private float _lifetime = 5f;      

    private void OnEnable()
    {
        StartCoroutine(DisableAfterLifetime());
    }

    private void Update()
    {
        MoveLeft();
    }

    private void MoveLeft()
    {
        transform.Translate(EnemyStats.EnemySpeed * Time.deltaTime * Vector3.left);
    }

    private IEnumerator DisableAfterLifetime()
    {
        yield return new WaitForSeconds(_lifetime);
        gameObject.SetActive(false);
        Debug.Log($"{EnemyStats.EnemyName} disappeared from the screen.");
    }
}
