using UnityEngine;

public class DamageComponent : MonoBehaviour
{
    [SerializeField] int damage;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        var healthComponent = other.GetComponent<HealthComponent>();
        if (healthComponent != null)
        {
            healthComponent.TakeDamage(damage);
        }
    }

}
