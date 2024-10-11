using UnityEngine;

public class HandleExplosion : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 5f;
    [SerializeField] private int _explosionDamage = 7;   
    [SerializeField] private LayerMask _damageLayerMask;    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(collision.transform.position, _explosionRadius, _damageLayerMask);

        /*
        foreach (Collider2D hit in hitObjects)
        {
            if (hit.TryGetComponent<Health>(out var healthComponent))
            {
                healthComponent.TakeDamage(_explosionDamage);
            }
        }*/

        Debug.Log($"Explosion at {collision.transform.position}, dealing {_explosionDamage} damage to {hitObjects.Length} objects.");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _explosionRadius);
    }
}
