using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private bool isPlayer;
    private float currentHealth;

    public float CurrentHealth => currentHealth;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (isPlayer)
        {
            var updatedHealth = currentHealth / maxHealth;
            EventManager.UpdateHealth(updatedHealth);
        }
        

        if (currentHealth <= 0)
        {
            if (isPlayer)
            {
                EventManager.GameOver();
            }
            
            Destroy(gameObject);
        }
    }
}
