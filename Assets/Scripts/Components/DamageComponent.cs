using UnityEngine;

public class DamageComponent : MonoBehaviour
{
    [SerializeField] int damage;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<HealthComponent>(out var healthComponent))
        {
            healthComponent.TakeDamage(damage);
        }
    }

}
